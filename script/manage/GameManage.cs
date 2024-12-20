using XXOO.script.asset;
using XXOO.script.bases;
using System.Collections.Generic;
using Godot;

namespace XXOO.script.manage
{
    public class GameManage : AssetLoadBase<PackedScene>
    {
        private readonly Node context;

        public override Dictionary<string, PackedScene> Assets { get; } = new();
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
}