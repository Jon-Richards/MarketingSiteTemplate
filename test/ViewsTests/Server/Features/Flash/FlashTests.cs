using Bunit;
using Views.Server.Features;
using Xunit;

namespace ViewsTests.Server.Features;

public class FlashTests : TestContext
{
    [Fact]
    public void Renders_WithDefaultLevel()
    {
        // Arrange & Act
        var component = RenderComponent<Flash>(parameters => parameters
            .AddChildContent("Test Message"));

        // Assert
        Assert.Contains("flash", component.Markup);
        Assert.Contains("flash--info", component.Markup);
        Assert.Contains("data-feature=\"flash\"", component.Markup);
    }

    [Fact]
    public void Renders_WithWarningLevel()
    {
        // Arrange & Act
        var component = RenderComponent<Flash>(parameters => parameters
            .Add(f => f.Level, "warning")
            .AddChildContent("Warning"));

        // Assert
        Assert.Contains("flash--warning", component.Markup);
    }

    [Fact]
    public void Renders_WithErrorLevel()
    {
        // Arrange & Act
        var component = RenderComponent<Flash>(parameters => parameters
            .Add(f => f.Level, "error")
            .AddChildContent("Error"));

        // Assert
        Assert.Contains("flash--error", component.Markup);
    }

    [Fact]
    public void Renders_ChildContent()
    {
        // Arrange
        var childContent = "Flash Message Content";
        var component = RenderComponent<Flash>(parameters => parameters
            .AddChildContent(childContent));

        // Act & Assert
        Assert.Contains(childContent, component.Markup);
    }

    [Fact]
    public void Renders_CloseButton_WhenDismissible()
    {
        // Arrange & Act
        var component = RenderComponent<Flash>(parameters => parameters
            .Add(f => f.IsDismissible, true)
            .AddChildContent("Test"));

        // Assert
        var button = component.Find("button");
        Assert.NotNull(button);
        Assert.Contains("x", button.TextContent);
    }

    [Fact]
    public void DoesNotRender_CloseButton_WhenNotDismissible()
    {
        // Arrange & Act
        var component = RenderComponent<Flash>(parameters => parameters
            .Add(f => f.IsDismissible, false)
            .AddChildContent("Test"));

        // Assert
        var buttons = component.FindAll("button");
        Assert.Empty(buttons);
    }

    [Fact]
    public void HasDataServerComponentAttribute()
    {
        // Arrange & Act
        var component = RenderComponent<Flash>(parameters => parameters
            .AddChildContent("Test"));

        // Assert
        var div = component.Find("[data-feature=\"flash\"]");
        Assert.NotNull(div);
    }

    [Fact]
    public void AppliesCorrectCssClasses()
    {
        // Arrange & Act
        var component = RenderComponent<Flash>(parameters => parameters
            .AddChildContent("Test"));

        // Assert
        Assert.Contains("flash", component.Markup);
        Assert.Contains("flex", component.Markup);
        Assert.Contains("columns-2", component.Markup);
        Assert.Contains("w-full", component.Markup);
        Assert.Contains("max-w-6xl", component.Markup);
    }
}
