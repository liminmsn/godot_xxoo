using XXOO.script.lib;
using XXOO.script.asset;
using System.Collections.Generic;
using Godot;

namespace XXOO.script.manage
{
    public class UiManage : AssetLoadBase<PackedScene>
    {
        private readonly Node ui;
        private readonly Node context;

        public override Dictionary<string, PackedScene> Assets { get; } = new();
        public UiManage(Node ui, Node context)
        {
            this.ui = ui;
            this.context = context;
            Init(Asset.ui);
        }
    }
}