using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using Microsoft.VisualBasic;

public class UiManage : AssetLoadBase, Manage
{
    private readonly Node ui;
    private readonly List<Control> PageStack = new();

    public override Dictionary<string, object> Assets { get; } = new();
    public UiManage(Node ui)
    {
        this.ui = ui;
        Init(Asset.ui);
    }
    public void Show(string name)
    {
        Get(name, out Node node);
        //如果当前ui已经挂载到页面上
        if (node.GetParent() != null)
        {
            (node as Control).Visible = true;
        }
        else
        {
            ui.AddChild(node);
            GD.Print($"显示ui:{name} _ {node}");
            PageStack.Add(node as Control);
        }
    }
}