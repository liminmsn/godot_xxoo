using Godot;
using System;

public partial class About : UIBase
{
    public override string UName => "About";
    public override void OnDown(string key)
    {
        GD.Print(key);
    }
}
