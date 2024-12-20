using Godot;
using System;
using System.Linq;

public partial class Home : UIBase
{
	public override string UName => "Home";

	public override void OnDown(string key)
	{
		GD.Print(key);
	}
}
