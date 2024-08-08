using System.Text.Json;

namespace Tpcly.Extensions.Json;

public class DictionaryLookupNamingPolicy(
    Dictionary<string, string> dictionary,
    JsonNamingPolicy? underlyingNamingPolicy
) : JsonNamingPolicyDecorator(underlyingNamingPolicy)
{
    private readonly Dictionary<string, string> _dictionary = dictionary ?? throw new ArgumentNullException(nameof(dictionary));

    public override string ConvertName(string name) => _dictionary.TryGetValue(name, out var value) ? value : base.ConvertName(name);
}