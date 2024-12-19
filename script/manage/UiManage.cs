using XXOO.script.asset;
using XXOO.script.bases;
using System.Collections.Generic;
using Godot;

namespace XXOO.script.manage
{
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
            // ui.AddChild(node);
        }
    }
}