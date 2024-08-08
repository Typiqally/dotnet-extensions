using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tpcly.Extensions.Json;

public class JsonStringEnumMemberConverter(
    JsonNamingPolicy? namingPolicy,
    bool allowIntegerValues = true
) : JsonConverterFactory
{
    private readonly JsonStringEnumConverter _baseConverter = new(namingPolicy, allowIntegerValues);

    public JsonStringEnumMemberConverter() : this(null)
    {
    }

    public override bool CanConvert(Type typeToConvert) => _baseConverter.CanConvert(typeToConvert);

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var query = from field in typeToConvert.GetFields(BindingFlags.Public | BindingFlags.Static)
            let attribute = field.GetCustomAttribute<EnumMemberAttribute>()
            where attribute is { Value: not null }
            select (field.Name, attribute.Value);

        var dictionary = query.ToDictionary(p => p.Item1, p => p.Item2);
        if (dictionary.Count == 0)
        {
            return _baseConverter.CreateConverter(typeToConvert, options);
        }

        var dictionaryNamingPolicy = new DictionaryLookupNamingPolicy(dictionary, namingPolicy);
        return new JsonStringEnumConverter(dictionaryNamingPolicy).CreateConverter(typeToConvert, options);
    }
}