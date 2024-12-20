using System;
using System.Linq;
using Godot;

public abstract partial class UIBase : Control
{
    public abstract string UName { get; }
    public abstract void OnDown(string key);
    public UiManage UiManage { get; } = GameMain.GetUiMange();
    public void OnStartButtonUp()
    {
        OnDown("");
    }
}