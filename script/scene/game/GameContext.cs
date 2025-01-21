using Godot;
using System.Linq;

public partial class GameContext : GameBase
{
	public override void _Ready()
	{
		GameMain.SetGameContext(this);
		var inGroup = GetTree().GetNodesInGroup("鼠标点击宫格");
		foreach (var pos in inGroup.Cast<RigidBody3D>())
		{
			if (pos.HasSignal("MouseEntered") == false && pos.HasSignal("MouseExited") == false)
			{
				pos.MouseEntered += () => Pos = pos; //添加
				pos.MouseExited += () => Pos = null; //移除就删掉
			}
		}
	}
	public void onBtn(string btnkey)
	{
		GD.Print("点击了按钮", btnkey);
		switch (btnkey)
		{
			case "x":
				Setting.Visible = false;
				break;
			case "stop":
				Setting.Visible = !Setting.Visible;//设置
				break;
			case "reset":
				Init();
				break;
			case "exit":
				DestoryAll();//销毁所有棋子
				GetNode<Control>("StopContext").Visible = false;
				GameMain.GetUiMange().Show("Home");
				break;
		}
	}
	public void Init()
	{
		GetNode<Control>("StopContext").Visible = true;
		RandomIsX();//随机xo谁先手
	}
}
