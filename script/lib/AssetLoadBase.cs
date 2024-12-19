using System.Collections.Generic;
using Godot;

namespace XXOO.script.lib
{
    public abstract class AssetLoadBase<T> where T : class
    {
        protected abstract Dictionary<string, T> Assets { get; }
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
                    }
                }
                else
                {
                    GD.PrintErr($"Resource {path} is not a {typeof(T).Name}");
                }
            }
        }
    }
}