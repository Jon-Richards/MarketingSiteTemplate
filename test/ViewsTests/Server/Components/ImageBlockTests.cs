using Bunit;
using Views.Server.Components;
using Xunit;

namespace ViewsTests.Server.Components;

public class ImageBlockTests : TestContext
{
    [Fact]
    public void Renders_WithBackgroundImageUrl()
    {
        // Arrange
        var imageUrl = "https://example.com/image.jpg";
        var component = RenderComponent<ImageBlock>(parameters => parameters
            .Add(i => i.BackgroundImage, imageUrl)
            .AddChildContent("Test Content"));

        // Act & Assert
        var div = component.Find("div[style*=\"background-image\"]");
        Assert.Contains(imageUrl, div.GetAttribute("style"));
    }

    [Fact]
    public void Renders_ChildContent()
    {
        // Arrange
        var childContent = "Image Block Content";
        var component = RenderComponent<ImageBlock>(parameters => parameters
            .Add(i => i.BackgroundImage, "url.jpg")
            .AddChildContent(childContent));

        // Act & Assert
        Assert.Contains(childContent, component.Markup);
    }

    [Fact]
    public void AppliesCorrectCssClasses()
    {
        // Arrange & Act
        var component = RenderComponent<ImageBlock>(parameters => parameters
            .Add(i => i.BackgroundImage, "test.jpg")
            .AddChildContent("Test"));

        // Assert
        Assert.Contains("w-full", component.Markup);
        Assert.Contains("max-w-6xl", component.Markup);
        Assert.Contains("p-8", component.Markup);
        Assert.Contains("border", component.Markup);
    }

    [Fact]
    public void Renders_WithoutImageUrl()
    {
        // Arrange & Act
        var component = RenderComponent<ImageBlock>(parameters => parameters
            .AddChildContent("Content"));

        // Assert
        Assert.Contains("w-full", component.Markup);
    }
}
