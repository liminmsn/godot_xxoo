using XXOO.script.asset;
using XXOO.script.bases;
using System.Collections.Generic;
using Godot;
using System;

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
            Get(name);
            // Get(name, out var scene);
            // if (scene != null)
            // {
            //     ui.AddChild(scene);
            // }
        }
    }
}