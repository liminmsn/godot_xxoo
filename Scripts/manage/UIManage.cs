using Godot;
public class UIManage : ResourceBase<Control>
{
    public static string[] ui_file = { "Home.res", "About.res" };
    public UIManage() : base(AssetPath.UI, ui_file)
    {

    }
    public override void CallFun(Control arg)
    {
        arg.Visible = false;
        AppContext.GetApp().uiNode.AddChild(arg);
    }
    public void ShowControl(string name, bool show = true)
    {
        var colntol = GetControl(name);
        if (colntol != null)
        {
            colntol.Visible = show;
        }
    }
    public Control GetControl(string control_key)
    {
        if (asset.TryGetValue(control_key, out Control colntol))
        {
            return colntol;
        }
        return null;
    }
}