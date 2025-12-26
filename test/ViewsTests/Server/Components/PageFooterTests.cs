using Bunit;
using Views.Server.Components;
using Xunit;

namespace ViewsTests.Server.Components;

public class PageFooterTests : TestContext
{
    [Fact]
    public void Renders_SocialsLabel()
    {
        // Arrange & Act
        var component = RenderComponent<PageFooter>();

        // Assert
        Assert.Contains("Socials", component.Markup);
    }

    [Fact]
    public void Renders_CopyrightText()
    {
        // Arrange & Act
        var component = RenderComponent<PageFooter>();

        // Assert
        Assert.Contains("&copy;2026 Jonathan Richards", component.Markup);
    }

    [Fact]
    public void Renders_RightsReservedText()
    {
        // Arrange & Act
        var component = RenderComponent<PageFooter>();

        // Assert
        Assert.Contains("All rights reserved", component.Markup);
    }

    [Fact]
    public void AppliesCorrectCssClasses()
    {
        // Arrange & Act
        var component = RenderComponent<PageFooter>();

        // Assert
        Assert.Contains("w-full", component.Markup);
        Assert.Contains("border", component.Markup);
        Assert.Contains("max-w-6xl", component.Markup);
        Assert.Contains("mx-auto", component.Markup);
        Assert.Contains("p-8", component.Markup);
        Assert.Contains("text-center", component.Markup);
    }

    [Fact]
    public void HasResponsiveLayout()
    {
        // Arrange & Act
        var component = RenderComponent<PageFooter>();

        // Assert
        Assert.Contains("sm:inline-block", component.Markup);
    }

    [Fact]
    public void ContainsStructuredLayout()
    {
        // Arrange & Act
        var component = RenderComponent<PageFooter>();

        // Assert
        Assert.Contains("mb-2", component.Markup);
    }
}
