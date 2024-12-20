using System.Collections.Generic;
using Godot;

public class UiManage : AssetLoadBase<PackedScene>
{
    private readonly Node ui;

    public override Dictionary<string, PackedScene> Assets { get; } = new();
    public UiManage(Node ui)
    {
        this.ui = ui;
        Init(Asset.ui);
    }
    public void Show(string name)
    {
        Get(name);
        // Get(name, out var scene);
        // if (scene != null)
        // {
        //     ui.AddChild(scene);
        // }
    }
}