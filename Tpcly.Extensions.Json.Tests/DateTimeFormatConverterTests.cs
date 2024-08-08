using System.Text.Json;

namespace Tpcly.Extensions.Json.Tests;

public class DatetimeFormatConverterTests
{
    [TestCase("dd-MM-yyyy", "01-01-2024")]
    [TestCase("dd-MM", "01-01")]
    [TestCase("yyyy-M-d dddd", "2024-1-1 Monday")]
    public void Test_DateTimeFormatConverter_Serialize(string format, string expectedResult)
    {
        // Arrange
        var dateTime = new DateTime(2024, 1, 1);
        var serializerOptions = new JsonSerializerOptions { Converters = { new DateTimeFormatJsonConverter(format) } };
        // Act
        var json = JsonSerializer.Serialize(dateTime, serializerOptions);

        //Assert
        Assert.That(json, Is.EqualTo($"\"{expectedResult}\""));
    }

    [TestCase("\"01-01-2024\"", "dd-MM-yyyy")]
    [TestCase("\"01-01\"", "dd-MM")]
    [TestCase("\"2024-1-1 Monday\"", "yyyy-M-d dddd")]
    public void Test_DateTimeFormatConverter_Deserialize(string json, string format)
    {
        // Arrange
        var serializerOptions = new JsonSerializerOptions { Converters = { new DateTimeFormatJsonConverter(format) } };

        // Act
        var dateTime = JsonSerializer.Deserialize<DateTime>(json, serializerOptions);

        //Assert
        Assert.That(dateTime, Is.EqualTo(new DateTime(2024, 1, 1)));
    }
}