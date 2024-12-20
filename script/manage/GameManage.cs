using System.Collections.Generic;
using Godot;

public class GameManage : AssetLoadBase, Manage
{
    private readonly Node context;

    public override Dictionary<string, object> Assets { get; } = new();
    public GameManage(Node context)
    {
        this.context = context;
        Init(Asset.game);
    }
    public void Show(string name)
    {
        Get(name, out var scene);
        if (scene != null)
        {
            context.AddChild(scene);
        }
    }
}