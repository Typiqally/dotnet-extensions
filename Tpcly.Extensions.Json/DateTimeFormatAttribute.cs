using System.Text.Json.Serialization;

namespace Tpcly.Extensions.Json;

public class DateTimeFormatAttribute(string format) : JsonConverterAttribute
{
    public override JsonConverter CreateConverter(Type typeToConvert)
    {
        return new DateTimeOffsetFormatJsonConverter(format);
    }
}