// -----------------------------------------------------------------------
//  <copyright file="JsonHelpers.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.DataLayer
{
    using Newtonsoft.Json;

    /// <summary> Provides helper methods for JSON injection logic. </summary>
    public static class JsonHelpers
    {
        /// <summary> The default Json serializer's setting for the application. </summary>
        public static JsonSerializerSettings DefaultJsonSettings = new JsonSerializerSettings
                                                                   {
                                                                       Formatting = Formatting.None,
                                                                       NullValueHandling = NullValueHandling.Ignore
                                                                   };

        /// <summary> Serializes object to Json representation as string. </summary>
        /// <param name="value"> The object to serialize. </param>
        /// <returns> A string representation the Json object. </returns>
        public static string Serialize(object value) => JsonConvert.SerializeObject(value, DefaultJsonSettings);

        /// <summary> Deserializes Json string representation to object. </summary>
        /// <param name="value"> The object to deserialize. </param>
        /// <returns> A object obtained from Json string. </returns>
        public static T Deserialize<T>(string value) => JsonConvert.DeserializeObject<T>(value, DefaultJsonSettings);
    }
}