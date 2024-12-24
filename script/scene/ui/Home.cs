using Godot;
public partial class Home : UIBase
{
	public override string UName => "Home";

	public override void OnDown(string key)
	{
		GD.Print(key);
		switch (key)
		{
			case "start":
				Close();
				break;
			case "about":
				Show("About");
				break;
		}
	}
}
