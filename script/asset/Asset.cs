public static class Asset
{
    public enum UItype
    {
        ui,
        game,
    }
    public readonly static string[] ui = new[]
    {
            "res://scene/ui/Home.res",
            "res://scene/ui/About.res",
        };
    public readonly static string[] game = new[]
    {
            "res://scene/ui/GameContext.tscn",
        };
}