using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tpcly.Extensions.Json;

public class DateTimeOffsetFormatJsonConverter(string format, IFormatProvider? provider = null) : JsonConverter<DateTimeOffset>
{
    private readonly IFormatProvider _provider = provider ?? CultureInfo.CurrentCulture;
    
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTimeOffset.ParseExact(reader.GetString()!, format, _provider);
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}