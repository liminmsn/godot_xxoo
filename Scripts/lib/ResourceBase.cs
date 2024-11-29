using Godot;
using Godot.Collections;

public abstract class ResourceBase<[MustBeVariant] T>
{
    public abstract void CallFun(T arg);
    protected readonly Dictionary<string, T> asset = new();

    public ResourceBase(string path, string[] files)
    {
        foreach (string file in files)
        {
            var loadedResource = ResourceLoader.Load(path + file);
            GD.Print("正在加载", path + file, "资源");
            if (loadedResource is PackedScene packedScene)
            {
                var colntol = packedScene.Instantiate();
                if (colntol != null && colntol is T node)
                {
                    asset.Add(colntol.Name, node);
                    CallFun(node);
                    GD.Print("资源加载成功! 资源数量：", asset.Count);
                }
            }
        }
    }
}