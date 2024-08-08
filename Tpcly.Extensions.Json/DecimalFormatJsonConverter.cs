using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tpcly.Extensions.Json;

public class DecimalFormatJsonConverter(string format, CultureInfo? cultureInfo = null) : JsonConverter<decimal>
{
    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetDecimal();
    }

    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(format, cultureInfo));
    }
}