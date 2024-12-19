using Godot;

namespace XXOO.script.lib
{
    public partial class SceneBase : Node
    {
        public override void _Ready()
        {
            GD.Print("SceneBase _Ready");
        }
    }
}