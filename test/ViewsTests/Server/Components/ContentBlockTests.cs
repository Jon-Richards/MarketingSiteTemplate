using Bunit;
using Views.Server.Components;
using Xunit;

namespace ViewsTests.Server.Components;

public class ContentAreaTests : TestContext
{
    [Fact]
    public void Renders_ContainerWithCorrectStructure()
    {
        // Arrange & Act
        var component = RenderComponent<ContentArea>(parameters => parameters
            .AddChildContent("Test Content"));

        // Assert
        Assert.Contains("w-full", component.Markup);
        Assert.Contains("max-w-6xl", component.Markup);
    }

    [Fact]
    public void Renders_ChildContent()
    {
        // Arrange
        var childContent = "Custom Content Area";
        var component = RenderComponent<ContentArea>(parameters => parameters
            .AddChildContent(childContent));

        // Act & Assert
        Assert.Contains(childContent, component.Markup);
    }

    [Fact]
    public void AppliesCorrectCssClasses()
    {
        // Arrange & Act
        var component = RenderComponent<ContentArea>(parameters => parameters
            .AddChildContent("Test"));

        // Assert
        Assert.Contains("w-full", component.Markup);
        Assert.Contains("max-w-6xl", component.Markup);
        Assert.Contains("mx-auto", component.Markup);
    }

    [Fact]
    public void Renders_WithMultipleChildren()
    {
        // Arrange & Act
        var component = RenderComponent<ContentArea>(parameters => parameters
            .AddChildContent("<span>Child 1</span><span>Child 2</span>"));

        // Assert
        Assert.Contains("Child 1", component.Markup);
        Assert.Contains("Child 2", component.Markup);
    }
}
