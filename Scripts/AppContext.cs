using Godot;
using System;

public partial class AppContext : Node
{
    [Export] public Node uiNode;
    [Export] public Node mainNode;
    public UIManage uManage;
    public SceneManage sManage = new();
    private static AppContext I;
    public static AppContext GetApp()
    {
        return I;
    }

    public override void _Ready()
    {
        I = this;
        uManage = new();
        uManage.ShowControl("Home");
        GD.Print("AppContext初始化完成");
    }
}
