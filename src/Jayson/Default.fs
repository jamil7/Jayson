namespace System.Text.Json

open System.Text.Json.Serialization

module Default =
    let serializationOptions =
        JsonSerializerOptions(PropertyNamingPolicy = JsonNamingPolicy.CamelCase)

    do serializationOptions.Converters.Add(JsonFSharpConverter(unionTagName = "tag", unionFieldsName = "value"))
    do serializationOptions.Converters.Add(Int64StringConverter())
