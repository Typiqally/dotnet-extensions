using System.Text.Json.Serialization;

namespace Tpcly.Extensions.Json;

public class DecimalFormatAttribute(string format, IFormatProvider? provider = null) : JsonConverterAttribute
{
    public override JsonConverter CreateConverter(Type typeToConvert)
    {
        return new DateTimeFormatJsonConverter(format, provider);
    }
}