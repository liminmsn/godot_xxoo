using Godot;
public partial class GameMain : Node
{
	[Export]
	Node ui, context;
	private static UiManage uiManage;
	private static GameManage gameManage;
	private static GameContext gameContext;
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
	public static GameContext GetGameContext()
	{
		return gameContext;
	}
	public static void SetGameContext(GameContext gameContext)
	{
		GameMain.gameContext = gameContext;
	}
}