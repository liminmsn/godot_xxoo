using Godot;

namespace XXOO.script.bases
{
    public partial class SceneBase : Node
    {
        public override void _Ready()
        {
            GD.Print("SceneBase _Ready");
        }
    }
}