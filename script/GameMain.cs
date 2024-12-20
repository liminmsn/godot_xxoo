using Godot;
public partial class GameMain : Node
{
	[Export]
	Node ui, context;
	private static UiManage uiManage;
	private static GameManage gameManage;
	private static GameMain I;

	public override void _Ready()
	{
		uiManage = new UiManage(ui);
		gameManage = new GameManage(context);
		InitUI();
		I = this;
	}
	static public void InitUI()
	{
		uiManage.Show("Home");
		gameManage.Show("GameContext");
	}



	public static UiManage GetUiMange()
	{
		return uiManage;
	}
	public static GameManage GetGameManage()
	{
		return gameManage;
	}
	public static GameMain GetGameApp()
	{
		return I;
	}
}