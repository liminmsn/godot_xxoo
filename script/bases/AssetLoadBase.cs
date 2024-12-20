using System.Collections.Generic;
using Godot;

public abstract class AssetLoadBase
{
    public abstract Dictionary<string, object> Assets { get; }
    public void Init(string[] paths)
    {
        foreach (string path in paths)
        {
            var resource = ResourceLoader.Load(path);
            if (resource != null)
            {
                //  If the resource is a scene, we need to instantiate it
                if (resource is PackedScene packed)
                {
                    Node node = packed.Instantiate();
                    Assets.Add(node.Name, node);
                    GD.Print($"Loaded {node.Name}");
                }
            }
            else
            {
                GD.PrintErr($"Resource {path} is not a");
            }
        }
    }
    public void Get(string key, out Node node)
    {
        if (Assets.TryGetValue(key, out object t_))
        {
            if (t_ is Node node1)
            {
                node = node1;
                return;
            }
        }
        node = null;
    }
}