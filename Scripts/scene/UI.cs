using System;
using System.Collections.Generic;
using Godot;

public partial class UI : SceneBase
{
    [Export] PackedScene[] ui_arr;
    public override void _Ready()
    {
        InitUI();
        OpenUI("Home");
    }
    public void InitUI()
    {
        Array.ForEach(ui_arr, ui =>
        {
            var ui_ = ui.Instantiate<Control>();
            if (dict == null)
            {
                dict = new Dictionary<string, Control>();
            }
            dict.Add(ui_.Name, ui_);
            GD.Print(ui.Instantiate().Name, "初始化完成!");
        });
    }
}