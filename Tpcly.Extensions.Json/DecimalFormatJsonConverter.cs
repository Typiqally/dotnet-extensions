using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tpcly.Extensions.Json;

public class DecimalFormatJsonConverter : JsonConverter<decimal>
{
    private readonly string? _format;
    private readonly CultureInfo _cultureInfo;

    public DecimalFormatJsonConverter(string format, CultureInfo cultureInfo)
    {
        _format = format;
        _cultureInfo = cultureInfo;
    }

    public DecimalFormatJsonConverter(CultureInfo cultureInfo)
    {
        _cultureInfo = cultureInfo;
    }

    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetDecimal();
    }

    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_format, _cultureInfo));
    }
}