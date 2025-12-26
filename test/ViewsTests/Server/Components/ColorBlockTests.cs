using Bunit;
using Views.Server.Components;
using Xunit;

namespace ViewsTests.Server.Components;

public class ColorBlockTests : TestContext
{
    [Fact]
    public void Renders_WithDefaultColors()
    {
        // Arrange
        var component = RenderComponent<ColorBlock>(parameters => parameters
            .AddChildContent("Test Content"));

        // Act & Assert
        var div = component.Find("div.w-full");
        Assert.Contains("background-color: #000", div.GetAttribute("style"));
    }

    [Fact]
    public void Renders_WithCustomBackgroundColor()
    {
        // Arrange
        var customColor = "#ff0000";
        var component = RenderComponent<ColorBlock>(parameters => parameters
            .Add(c => c.BackgroundColor, customColor)
            .AddChildContent("Test Content"));

        // Act & Assert
        var div = component.Find("div.w-full");
        Assert.Contains($"background-color: {customColor}", div.GetAttribute("style"));
    }

    [Fact]
    public void Renders_WithCustomForegroundColor()
    {
        // Arrange
        var customColor = "#00ff00";
        var component = RenderComponent<ColorBlock>(parameters => parameters
            .Add(c => c.ForegroundColor, customColor)
            .AddChildContent("Test Content"));

        // Act & Assert
        var innerDiv = component.Find("div.w-full.max-w-6xl");
        Assert.Contains($"color: {customColor}", innerDiv.GetAttribute("style"));
    }

    [Fact]
    public void Renders_ChildContent()
    {
        // Arrange
        var childContent = "Custom Child Content";
        var component = RenderComponent<ColorBlock>(parameters => parameters
            .AddChildContent(childContent));

        // Act & Assert
        Assert.Contains(childContent, component.Markup);
    }

    [Fact]
    public void AppliesCorrectCssClasses()
    {
        // Arrange
        var component = RenderComponent<ColorBlock>(parameters => parameters
            .AddChildContent("Test"));

        // Act & Assert
        Assert.Contains("w-full", component.Markup);
        Assert.Contains("max-w-6xl", component.Markup);
        Assert.Contains("mx-auto", component.Markup);
        Assert.Contains("p-8", component.Markup);
    }
}
