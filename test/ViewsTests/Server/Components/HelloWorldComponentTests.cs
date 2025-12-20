namespace ViewsTests.Server.Components;

public class HelloWorldComponentTests : TestContext
{
    [Fact]
    public void HelloWorldComponent_WithDefaultMessage_RendersProperly()
    {
        // Arrange & Act
        var cut = RenderComponent<Views.Server.Components.HelloWorld>();

        // Assert
        cut.Find("h2").TextContent.Should().Be("Hello World Component");
        var paragraphs = cut.FindAll("p").ToList();
        paragraphs[1].TextContent.Should().Be("I'm just the default message.");
    }

    [Fact]
    public void HelloWorldComponent_WithCustomMessage_RendersMessageCorrectly()
    {
        // Arrange
        var customMessage = "This is a custom message";

        // Act
        var cut = RenderComponent<Views.Server.Components.HelloWorld>(
            parameters => parameters.Add(hw => hw.Message, customMessage)
        );

        // Assert
        var paragraphs = cut.FindAll("p").ToList();
        paragraphs[1].TextContent.Should().Be(customMessage);
    }

    [Fact]
    public void HelloWorldComponent_ContainsCorrectHeading()
    {
        // Arrange & Act
        var cut = RenderComponent<Views.Server.Components.HelloWorld>();

        // Assert
        var heading = cut.Find("h2");
        heading.TextContent.Should().Be("Hello World Component");
    }

    [Fact]
    public void HelloWorldComponent_ContainsIntroductionText()
    {
        // Arrange & Act
        var cut = RenderComponent<Views.Server.Components.HelloWorld>();

        // Assert
        cut.Markup.Should().Contain("The following message was passed in...");
    }

    [Fact]
    public void HelloWorldComponent_HasAlertClass()
    {
        // Arrange & Act
        var cut = RenderComponent<Views.Server.Components.HelloWorld>();

        // Assert
        var alertDiv = cut.Find("div");
        alertDiv.ClassList.Should().Contain("alert");
    }

    [Fact]
    public void HelloWorldComponent_RendersMultipleParagraphs()
    {
        // Arrange & Act
        var cut = RenderComponent<Views.Server.Components.HelloWorld>(
            parameters => parameters.Add(hw => hw.Message, "Test Message")
        );

        // Assert
        var paragraphs = cut.FindAll("p").ToList();
        paragraphs.Count.Should().Be(2);
    }

    [Fact]
    public void HelloWorldComponent_WithDifferentMessages_UpdatesCorrectly()
    {
        // Arrange
        var message1 = "Original Message";
        var message2 = "Updated Message";

        // Act
        var cut = RenderComponent<Views.Server.Components.HelloWorld>(
            parameters => parameters.Add(hw => hw.Message, message1)
        );
        cut.SetParametersAndRender(
            parameters => parameters.Add(hw => hw.Message, message2)
        );

        // Assert
        var paragraphs = cut.FindAll("p").ToList();
        paragraphs[1].TextContent.Should().Be(message2);
    }
}
