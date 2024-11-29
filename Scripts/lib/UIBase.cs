using Godot;

public abstract partial class UIBase : Control
{
    public abstract void OnBtn(uint angs);
    public void OpenUI(string uiname)
    {
        var ui = AppContext.GetApp().uManage.GetControl(uiname);
        foreach (Control control in AppContext.GetApp().uiNode.GetChildren())
        {
            if (control == ui)
            {
                control.Visible = true;
            }
        }
    }
    public void CloseUI()
    {
        Visible = false;
    }
}