using System.Collections.Generic;
using Godot;

public class UiManage : AssetLoadBase
{
    private readonly Node ui;

    public override Dictionary<string, object> Assets { get; } = new();
    public UiManage(Node ui)
    {
        this.ui = ui;
        Init(Asset.ui);
    }
    public void Show(string name)
    {
        Get(name, out Node node);
        GD.Print($"显示ui:{name} _ {node}");
        ui.AddChild(node);
    }
}