using System.Runtime.Serialization;
using System.Text.Json;

namespace Tpcly.Extensions.Json.Tests;

public class JsonStringEnumMemberConverterTests
{
    private enum TestEnumValue
    {
        [EnumMember(Value = "one")]
        ValueOne,
        [EnumMember(Value = "two")]
        ValueTwo,
        [EnumMember(Value = "three")]
        ValueThree
    }
    
    [Test]
    public void Test_JsonStringEnumMemberConverter_Serialize()
    {
        // Arrange
        var enumValue = TestEnumValue.ValueOne;
        var serializerOptions = new JsonSerializerOptions { Converters = { new JsonStringEnumMemberConverter() } };
        // Act
        var json = JsonSerializer.Serialize(enumValue, serializerOptions);

        //Assert
        Assert.That(json, Is.EqualTo("\"one\""));
    }
    
    [Test]
    public void Test_JsonStringEnumMemberConverter_Deserialize()
    {
        // Arrange
        var serializerOptions = new JsonSerializerOptions { Converters = { new JsonStringEnumMemberConverter() } };

        // Act
        var enumValue = JsonSerializer.Deserialize<TestEnumValue>("\"one\"", serializerOptions);

        //Assert
        Assert.That(enumValue, Is.EqualTo(TestEnumValue.ValueOne));
    }
}