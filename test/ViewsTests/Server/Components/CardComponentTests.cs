namespace ViewsTests.Server.Components;

public class CardComponentTests : TestContext
{
    [Fact]
    public void CardComponent_WithDefaultParameters_RendersProperly()
    {
        // Arrange & Act
        var cut = RenderComponent<Views.Server.Components.Card>();

        // Assert
        cut.MarkupMatches(
            @"<div class=""bg-blue-50 rounded-lg shadow-md p-6 border border-blue-200"">
                <h2 class=""text-2xl font-bold text-blue-900 mb-2"">Card Title</h2>
                <p class=""text-blue-700"">Card content goes here.</p>
            </div>"
        );
    }

    [Fact]
    public void CardComponent_WithCustomTitle_RendersTitleCorrectly()
    {
        // Arrange
        var customTitle = "Custom Title";

        // Act
        var cut = RenderComponent<Views.Server.Components.Card>(
            parameters => parameters.Add(c => c.Title, customTitle)
        );

        // Assert
        cut.Find("h2").TextContent.Should().Be(customTitle);
    }

    [Fact]
    public void CardComponent_WithCustomContent_RendersContentCorrectly()
    {
        // Arrange
        var customContent = "This is custom content";

        // Act
        var cut = RenderComponent<Views.Server.Components.Card>(
            parameters => parameters.Add(c => c.Content, customContent)
        );

        // Assert
        cut.Find("p").TextContent.Should().Be(customContent);
    }

    [Fact]
    public void CardComponent_WithBothCustomParameters_RendersBothCorrectly()
    {
        // Arrange
        var title = "Test Title";
        var content = "Test Content";

        // Act
        var cut = RenderComponent<Views.Server.Components.Card>(
            parameters => parameters
                .Add(c => c.Title, title)
                .Add(c => c.Content, content)
        );

        // Assert
        cut.Find("h2").TextContent.Should().Be(title);
        cut.Find("p").TextContent.Should().Be(content);
    }

    [Fact]
    public void CardComponent_HasCorrectStyling_Classes()
    {
        // Arrange & Act
        var cut = RenderComponent<Views.Server.Components.Card>();

        // Assert
        var cardDiv = cut.Find("div");
        cardDiv.ClassList.Should().Contain("bg-blue-50");
        cardDiv.ClassList.Should().Contain("rounded-lg");
        cardDiv.ClassList.Should().Contain("shadow-md");
        cardDiv.ClassList.Should().Contain("border");
        cardDiv.ClassList.Should().Contain("border-blue-200");
    }

    [Fact]
    public void CardComponent_TitleHasCorrectStyling_Classes()
    {
        // Arrange & Act
        var cut = RenderComponent<Views.Server.Components.Card>();

        // Assert
        var titleElement = cut.Find("h2");
        titleElement.ClassList.Should().Contain("text-2xl");
        titleElement.ClassList.Should().Contain("font-bold");
        titleElement.ClassList.Should().Contain("text-blue-900");
    }
}
