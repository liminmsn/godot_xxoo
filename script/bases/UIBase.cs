using System.Linq;
using Godot;

public abstract partial class UIBase : Control
{
    public abstract string UName { get; }
    public void OnStartButtonUp()
    {
        var nodes = GameMain.uiManage.Assets.ToArray();
        GD.Print(nodes[0],nodes[1]);
    }
}