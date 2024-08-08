using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tpcly.Extensions.Json;

public class DateTimeFormatJsonConverter(string format, IFormatProvider? provider = null) : JsonConverter<DateTime>
{
    private readonly IFormatProvider _provider = provider ?? CultureInfo.CurrentCulture;

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.ParseExact( reader.GetString()!, format, _provider);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(format));
    }
}