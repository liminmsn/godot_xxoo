using System.Collections.Generic;
using Godot;

public abstract class AssetLoadBase<T> where T : class
{
    public abstract Dictionary<string, T> Assets { get; }
    public void Init(string[] paths)
    {
        foreach (string path in paths)
        {
            var resource = ResourceLoader.Load(path);
            if (resource is T)
            {
                //  If the resource is a scene, we need to instantiate it
                if (resource is PackedScene packed)
                {
                    Node node = packed.Instantiate();
                    Assets.Add(node.Name, node as T);
                    GD.Print($"Loaded {node.Name}");
                }
            }
            else
            {
                GD.PrintErr($"Resource {path} is not a {typeof(T).Name}");
            }
        }
    }
    public void Get(string key)
    {
        GD.Print(key);
        Assets.TryGetValue(key, out T node_);
        GD.Print(node_);
    }
}