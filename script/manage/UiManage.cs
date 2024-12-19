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

        protected override Dictionary<string, PackedScene> Assets { get; } = new();
        public UiManage(Node ui, Node context)
        {
            this.ui = ui;
            this.context = context;
            this.Init(Asset.ui);
        }
    }
}