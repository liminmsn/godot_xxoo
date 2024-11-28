using Godot;
using System;

enum BtnKey
{
	START,
	ABOUT
}

public partial class Home : UIBase
{
	[Export] Button[] btns;
	public override void _Ready()
	{

	}
	public override void OnBtn(uint btnKey)
	{
		switch ((BtnKey)btnKey)
		{
			case BtnKey.START:
				GD.Print("开始游戏");
				Visible = false;
				break;
			case BtnKey.ABOUT:
				GD.Print("bbb");
				break;
		}
	}
}
