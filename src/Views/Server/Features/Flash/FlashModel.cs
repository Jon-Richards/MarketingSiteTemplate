namespace Views.Server.Features;

public class FlashModel
{
    public string Modifier { get; set; }

    public FlashModel(string level)
    {
       SetModifier(level); 
    }   

    private void SetModifier(string level)
    {
        switch (level)
        {
            case "warning":
                Modifier = "warning";
                break;
            case "error":
                Modifier = "error";
                break;
            default:
                Modifier = "info";
                break;
        }
    }
}
