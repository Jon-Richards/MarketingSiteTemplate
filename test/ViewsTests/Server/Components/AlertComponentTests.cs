namespace ViewsTests.Server.Components;

public class AlertComponentTests : TestContext
{
    [Fact]
    public void AlertComponent_WithDefaultMessage_RendersProperly()
    {
        // Arrange & Act
        var cut = RenderComponent<Views.Server.Components.Alert>();

        // Assert
        cut.Find("p").TextContent.Should().Contain("This is an informational message.");
    }

    [Fact]
    public void AlertComponent_WithCustomMessage_RendersMessageCorrectly()
    {
        // Arrange
        var customMessage = "Custom Alert Message";

        // Act
        var cut = RenderComponent<Views.Server.Components.Alert>(
            parameters => parameters.Add(a => a.Message, customMessage)
        );

        // Assert
        cut.Find("p").TextContent.Should().Contain(customMessage);
    }

    [Fact]
    public void AlertComponent_ContainsInfoIcon_InMarkup()
    {
        // Arrange & Act
        var cut = RenderComponent<Views.Server.Components.Alert>();

        // Assert
        cut.Markup.Should().Contain("ℹ️");
    }

    [Fact]
    public void AlertComponent_HasCorrectStyling_ContainerClasses()
    {
        // Arrange & Act
        var cut = RenderComponent<Views.Server.Components.Alert>();

        // Assert
        var alertDiv = cut.Find("div");
        alertDiv.ClassList.Should().Contain("bg-blue-50");
        alertDiv.ClassList.Should().Contain("border-l-4");
        alertDiv.ClassList.Should().Contain("border-blue-500");
    }

    [Fact]
    public void AlertComponent_HasCorrectStyling_MessageClasses()
    {
        // Arrange & Act
        var cut = RenderComponent<Views.Server.Components.Alert>();

        // Assert
        var messageElement = cut.Find("p");
        messageElement.ClassList.Should().Contain("text-blue-700");
        messageElement.ClassList.Should().Contain("font-semibold");
    }

    [Fact]
    public void AlertComponent_WithDifferentMessages_UpdatesCorrectly()
    {
        // Arrange
        var message1 = "First Message";
        var message2 = "Second Message";

        // Act
        var cut = RenderComponent<Views.Server.Components.Alert>(
            parameters => parameters.Add(a => a.Message, message1)
        );
        cut.SetParametersAndRender(
            parameters => parameters.Add(a => a.Message, message2)
        );

        // Assert
        cut.Find("p").TextContent.Should().Contain(message2);
        cut.Find("p").TextContent.Should().NotContain(message1);
    }
}
