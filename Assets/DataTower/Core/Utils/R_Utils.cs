/*
 * Created by zhangwei on 2020/8/6.
 * Copyright 2015－2021 Sensors Data Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *       http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace DataTower.Core
{
    public class R_Utils
    {
        private static readonly Regex KEY_PATTERN =
            new Regex(
                @"^((?!^distinct_id$|^original_id$|^time$|^properties$|^id$|^first_id$|^second_id$|^users$|^events$|^event$|^user_id$|^date$|^datetime$)[a-zA-Z_$][a-zA-Z\\d_$]{0,99})$");

        /// <summary>
        ///     将字符串转换成 Java JSONObject 对象
        /// </summary>
        /// <param name="jsonStr">json 字符串</param>
        /// <returns>AndroidJavaObject，如果不能成功转换则会返回 null</returns>
        public static AndroidJavaObject Parse2JavaJSONObject(string jsonStr)
        {
            if (jsonStr == null || "null".Equals(jsonStr)) return null;
            try
            {
                return new AndroidJavaObject("org.json.JSONObject", jsonStr);
            }
            catch (Exception e)
            {
                R_Log.Error("Can not parse " + jsonStr + "to JSONObject: " + e);
            }

            return null;
        }

        /// <summary>
        ///     将字典转换成 Json 字符串
        /// </summary>
        /// <param name="dictionary">字典</param>
        /// <returns>json 字符串，如果字典不能转换成字符串那么会返回 null。</returns>
        public static string Parse2JsonStr(Dictionary<string, object> dictionary)
        {
            if (dictionary == null) return "{}";
            try
            {
                return Json.Serialize(dictionary);
            }
            catch (Exception e)
            {
                R_Log.Error(e.Message);
            }

            return "{}";
        }

        public static string ParseList2JsonStr(List<string> listStr)
        {
            if (listStr == null) return "[]";
            try
            {
                return Json.Serialize(listStr);
            }
            catch (Exception e)
            {
                R_Log.Error(e.Message);
            }

            return "[]";
        }

        /// <summary>
        ///     将 json 字符串转换成字典
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns>字典对象，如果不能转换则返回 null。</returns>
        public static Dictionary<string, object> Parse2Dictionary(string jsonStr)
        {
            if (jsonStr == null) return null;
            try
            {
                return Json.Deserialize(jsonStr) as Dictionary<string, object>;
            }
            catch (Exception ex)
            {
                R_Log.Error(ex.Message);
            }

            return null;
        }

        /// <summary>
        ///     判断事件的 key 值是否合规
        /// </summary>
        /// <param name="key">event key</param>
        /// <returns>合规就返回 true，否则返回 false</returns>
        public static bool AssertKey(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                R_Log.Error("The key is empty.");
                return false;
            }

            if (key.Length > 255)
            {
                R_Log.Error("The key [" + key + "] is too long, max length is 255.");
                return false;
            }

            if (KEY_PATTERN.IsMatch(key))
            {
                return true;
            }

            R_Log.Error("The key [" + key + "] is invalid.");
            return false;
        }

        /// <summary>
        ///     判断字典的 value 是否为支持的类型，当前支持 string,number,DateTime
        /// </summary>
        /// <param name="dic">event properties dictionary</param>
        /// <returns>合规就返回 true，否则返回 false</returns>
        public static bool AssertValue(Dictionary<string, object> dic)
        {
            if (dic == null) return true;
            foreach (var value in dic.Values)
                if (!(value is string || IsNumeric(value) || value is DateTime)) //TODO 此处校验不全
                {
                    R_Log.Error("The property values must be an instance of string, number or DateTime");
                    return false;
                }

            return true;
        }

        public static string ToDebugString(Dictionary<string, object> dictionary)
        {
            if (dictionary == null) return null;
            var sb = new StringBuilder();
            sb.Append("[");
            foreach (var item in dictionary) sb.Append("").Append(item.Key).Append(",").Append(item.Value).Append("),");
            sb.Append("]");
            return sb.ToString();
        }


        public static bool IsNumeric(object obj)
        {
            return obj is sbyte
                   || obj is byte
                   || obj is short
                   || obj is ushort
                   || obj is int
                   || obj is uint
                   || obj is long
                   || obj is ulong
                   || obj is double
                   || obj is decimal
                   || obj is float;
        }

        public static AndroidJavaObject ParseDic2Map(Dictionary<string, object> dictionary)
        {
            if (dictionary == null)
            {
                return new AndroidJavaObject("java.util.HashMap");
            }

            AndroidJavaObject map = new AndroidJavaObject("java.util.HashMap");
            foreach (KeyValuePair<string, object> pair in dictionary)
            {
                map.Call<string>("put", pair.Key, pair.Value);
            }

            return map;
        }

        private static readonly Regex KeyRegex = new Regex("^[a-zA-Z][a-zA-Z\\d_#]{0,49}", RegexOptions.IgnoreCase);
        public static void ValidateJsonDictionary(Dictionary<string, object> dictionary)
        {
            R_Log.Debug("Validating given dictionary...");
            if (dictionary == null)
            {
                R_Log.Debug("Given dictionary is null, skipped!");
                return;
            }

            // json string check
            var jsonStr = Parse2JsonStr(dictionary);
            if (jsonStr == null)
            {
                throw new ArgumentException($"Json check failed (cannot convert to json string) for @{dictionary}");
            }

            R_Log.Debug("Received dictionary w/ jsonified: " + PrettyJson(jsonStr));

            // key & value check
            foreach (KeyValuePair<string, object> entry in dictionary)
            {
                // check for key
                ValidateJsonKey(entry.Key);

                // check for value
                ValidateJsonValue(entry.Value, entry.Key);
            }

            R_Log.Debug("No issue found in preset validation, " +
                        "BUT: pls check the printed jsonified dictionary is the same as you expect!");
        }

        private static void ValidateJsonKey(object obj)
        {
            if (!(obj is string key))
            {
                throw new ArgumentException($"Json check failed (key must be a string, given: {obj})");
            }

            if (key.Length == 0)
            {
                throw new ArgumentException("Json check failed (key is empty)");
            }

            if (key.StartsWith("#") || key.StartsWith("$"))
            {
                throw new ArgumentException($"Json check failed (key cannot starts with '#' or '$') for {key}");
            }

            if (!KeyRegex.IsMatch(key))
            {
                throw new ArgumentException(
                    $"Json check failed (key must starts with english letter, and only contains letter, number, and '_', with maximum length 50) for {key}");
            }
        }

        private static void ValidateJsonValue(object value, string key)
        {
            if (!(value is string || IsNumeric(value) || value is bool || value is IList ||
                  value is IDictionary || value == null))
            {
                throw new ArgumentException(
                    $"Property value must be type String, Number, Boolean, List, Dictionary or null. Invalid pair: \"{key}\" = {value}");
            }

            if (value is IList list)
            {
                foreach (var obj in list)
                {
                    ValidateJsonValue(obj, key);
                }
            }

            if (value is IDictionary dict)
            {
                foreach (var k in dict.Keys)
                {
                    ValidateJsonKey(k);
                    ValidateJsonValue(dict[k], key);
                }
            }

            if (value != null && IsNumeric(value))
            {
                var d = double.Parse(value.ToString());
                if (d > 9999999999999.999 || d < -9999999999999.999)
                {
                    throw new ArgumentException($"The number value ({value}) is invalid for key ({key}).");
                }
            }
        }

        public static void ValidateListOnlyProp(Dictionary<string, object> properties)
        {
            foreach (KeyValuePair<string, object> entry in properties)
            {
                ValidateJsonKey(entry.Key);

                if (!(entry.Value is ICollection))
                {
                    throw new ArgumentException($"Given properties is not valid, only subtype of ICollection is acceptable. Given: \"{entry.Key}\" = {entry.Value}");
                }
            }
        }

        private const string IndentString = "    ";
        public static string PrettyJson(string json)
        {
            var indent = 0;
            var quoted = false;
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < json.Length; i++)
            {
                var ch = json[i];
                switch (ch)
                {
                    case '{':
                    case '[':
                        stringBuilder.Append(ch);
                        if (!quoted)
                        {
                            stringBuilder.AppendLine();
                            Enumerable.Range(0, ++indent).ForEach(item => stringBuilder.Append(IndentString));
                        }
                        break;
                    case '}':
                    case ']':
                        if (!quoted)
                        {
                            stringBuilder.AppendLine();
                            Enumerable.Range(0, --indent).ForEach(item => stringBuilder.Append(IndentString));
                        }
                        stringBuilder.Append(ch);
                        break;
                    case '"':
                        stringBuilder.Append(ch);
                        bool escaped = false;
                        var index = i;
                        while (index > 0 && json[--index] == '\\')
                            escaped = !escaped;
                        if (!escaped)
                            quoted = !quoted;
                        break;
                    case ',':
                        stringBuilder.Append(ch);
                        if (!quoted)
                        {
                            stringBuilder.AppendLine();
                            Enumerable.Range(0, indent).ForEach(item => stringBuilder.Append(IndentString));
                        }
                        break;
                    case ':':
                        stringBuilder.Append(ch);
                        if (!quoted)
                            stringBuilder.Append(" ");
                        break;
                    default:
                        stringBuilder.Append(ch);
                        break;
                }
            }
            return stringBuilder.ToString();
        }
    }



    static class Extensions
    {
        internal static void ForEach<T>(this IEnumerable<T> ie, Action<T> action)
        {
            foreach (var i in ie)
            {
                action(i);
            }
        }
    }
}