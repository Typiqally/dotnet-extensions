using System.Text.Json;

namespace Tpcly.Extensions.Json;

public class JsonNamingPolicyDecorator(JsonNamingPolicy? underlyingNamingPolicy) : JsonNamingPolicy
{
    public override string ConvertName(string name) => underlyingNamingPolicy?.ConvertName(name) ?? name;
}