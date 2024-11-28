using System.Collections.Generic;
using Godot;

public partial class SceneBase : Node
{
    Dictionary<string, Control> dict;
    public void InitDictionary(Dictionary<string, Control> dir)
    {
        dict = dir;
    }
    public void OpenUI(string name)
    {
        GD.Print("open_UI");
        if (dict.TryGetValue(name, out Control control))
        {
            GD.Print("yes");
            AddChild(control);
        }
    }
}