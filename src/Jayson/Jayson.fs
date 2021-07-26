[<RequireQualifiedAccess>]
module Jayson

open FSharp.Prelude
open System.Text.Json

let encode<'a> (a: 'a) : string =
    JsonSerializer.Serialize<'a>(a, Default.serializationOptions)

let decode<'a> (str: string) : 'a =
    JsonSerializer.Deserialize<'a>(str, Default.serializationOptions)

let optionEncode<'a> (a: 'a) : string option = Option.ofThrowable encode<'a> a

let optionDecode<'a> (str: string) : 'a option = Option.ofThrowable decode<'a> str

let resultEncode<'a> (a: 'a) : Result<string, exn> = Result.ofThrowable encode<'a> a

let resultDecode<'a> (str: string) : Result<'a, exn> = Result.ofThrowable decode<'a> str
