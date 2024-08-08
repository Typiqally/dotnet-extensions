using System.Text.Json.Serialization;

namespace Tpcly.Extensions.Json;

public class DateTimeOffsetFormatAttribute(string format) : JsonConverterAttribute
{
    public override JsonConverter CreateConverter(Type typeToConvert)
    {
        return new DateTimeFormatJsonConverter(format);
    }
}