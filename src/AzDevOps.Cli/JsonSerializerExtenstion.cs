﻿using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AzDevOps.Cli;

public class DateTimeOffsetConverterUsingDateTimeParse : JsonConverter<DateTimeOffset> {
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        Debug.Assert(typeToConvert == typeof(DateTimeOffset));
        return DateTimeOffset.Parse(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options) {
        writer.WriteStringValue(value.ToString());
    }
}