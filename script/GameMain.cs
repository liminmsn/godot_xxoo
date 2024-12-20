using Godot;
using XXOO.script.manage;

namespace XXOO.script
{
	public partial class GameMain : Node
	{
		[Export]
		Node ui, context;
		static UiManage uiManage;
		static GameManage gameManage;

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			uiManage = new UiManage(ui);
			gameManage = new GameManage(context);
			InitUI();
		}
		public void InitUI()
		{
			uiManage.Show("Home");
			gameManage.Show("GameContext");
		}
	}
}
