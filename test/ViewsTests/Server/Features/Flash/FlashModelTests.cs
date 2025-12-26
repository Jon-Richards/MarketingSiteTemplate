using Views.Server.Features;
using Xunit;

namespace ViewsTests.Server.Features;

public class FlashModelTests
{
    [Fact]
    public void Constructor_WithWarningLevel_SetsModifierToWarning()
    {
        // Arrange & Act
        var model = new FlashModel("warning");

        // Assert
        Assert.Equal("warning", model.Modifier);
    }

    [Fact]
    public void Constructor_WithErrorLevel_SetsModifierToError()
    {
        // Arrange & Act
        var model = new FlashModel("error");

        // Assert
        Assert.Equal("error", model.Modifier);
    }

    [Fact]
    public void Constructor_WithInfoLevel_SetsModifierToInfo()
    {
        // Arrange & Act
        var model = new FlashModel("info");

        // Assert
        Assert.Equal("info", model.Modifier);
    }

    [Fact]
    public void Constructor_WithUnrecognizedLevel_DefaultsToInfo()
    {
        // Arrange & Act
        var model = new FlashModel("unknown");

        // Assert
        Assert.Equal("info", model.Modifier);
    }

    [Fact]
    public void Constructor_WithNullLevel_DefaultsToInfo()
    {
        // Arrange & Act
        var model = new FlashModel(null);

        // Assert
        Assert.Equal("info", model.Modifier);
    }

    [Theory]
    [InlineData("warning")]
    [InlineData("error")]
    [InlineData("info")]
    public void Constructor_WithValidLevel_SetsModifierCorrectly(string level)
    {
        // Arrange & Act
        var model = new FlashModel(level);

        // Assert
        Assert.NotNull(model.Modifier);
    }
}
