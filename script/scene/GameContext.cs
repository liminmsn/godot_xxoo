using Godot;
using System;
using System.Linq;

public partial class GameContext : GameBase
{
	public override void _Ready()
	{
		Init();
	}
	private void Init()
	{
		RandomIsX();//随机xo谁先手
		var inGroup = GetTree().GetNodesInGroup("鼠标点击宫格");
		foreach (var pos in inGroup.Cast<RigidBody3D>())
		{
			pos.MouseEntered += () => Pos = pos; //添加
			pos.MouseExited += () => Pos = null; //移除就删掉
		}
	}
}