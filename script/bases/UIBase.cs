using System.Linq;
using Godot;

public abstract partial class UIBase : Control
{
    public abstract string UName { get; }
    public void OnBtoonDown()
    {
        var nodes = GameMain.uiManage.Assets.ToArray();
        GD.Print(nodes[0]);
    }
}