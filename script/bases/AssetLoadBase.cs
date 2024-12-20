using System.Collections.Generic;
using Godot;

namespace XXOO.script.bases
{
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
        public void Get(string key, out Node node)
        {
            if (Assets.TryGetValue(key, out T asset))
            {
                node = asset as Node;
                GD.Print($"Get {asset}");
            }
            else
            {
                GD.PrintErr($"Asset {key} not found");
                node = null;
            }
        }
    }
}