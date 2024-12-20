using Godot;

public abstract partial class UIBase : Control
{
    public abstract string UName { get; }
    public abstract void OnDown(string key);
    public UiManage UiManage { get; } = GameMain.GetUiMange();
    public void OnStartButtonUp(string key)
    {
        //这里做一些统一播放声音之类的
        OnDown(key);
    }
}