﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NGitLab.Json {
    public class Sha1Converter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(Sha1);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            return new Sha1((string)reader.Value);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            JToken token = JToken.FromObject(value.ToString());
            token.WriteTo(writer);
        }
    }
}
