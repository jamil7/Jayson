namespace System.Text.Json.Serialization

open System
open System.Text.Json

type Int64StringConverter(?encodeInt64AsString: bool) =
    inherit JsonConverter<int64>()

    override this.Read(reader, _type, _options) : int64 =
        if reader.TokenType = JsonTokenType.String then
            Int64.Parse(reader.GetString())
        else
            reader.GetInt64()

    override this.Write(writer, value, _options) : unit =
        let writeAsString' = defaultArg encodeInt64AsString false

        if writeAsString' then
            writer.WriteStringValue(value.ToString())
        else
            writer.WriteNumberValue(value)
