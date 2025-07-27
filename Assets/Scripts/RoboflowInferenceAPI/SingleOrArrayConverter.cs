using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

public class SingleOrArrayConverter<T> : JsonConverter
{
    public override bool CanConvert(Type objectType) => (objectType == typeof(List<T>));

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        JToken token = JToken.Load(reader);
        if (token.Type == JTokenType.Array)
            return token.ToObject<List<T>>(serializer);
        return new List<T> { token.ToObject<T>(serializer) };
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }
}