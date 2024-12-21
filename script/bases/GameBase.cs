using System;
using Godot;
public abstract partial class GameBase : Node
{
    protected RigidBody3D Pos { get; set; }
    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed)
        {
            if (mouseButton.ButtonIndex == MouseButton.Left && Pos != null)
            {
                string idx = Pos.Name.ToString()[^1..];
                AddPawn(uint.Parse(idx));
                GD.Print("鼠标左键点击", idx);
            }
        }
    }
    [Export]
    PackedScene X, O;
    private bool IsX;
    private RigidBody3D[] Pawns = new RigidBody3D[9];
    private void AddPawn(uint idx)
    {
        if (IsPawn(idx))
        {
            var xo_pawn = InitXO(IsX);
            var transform = Pos.Transform;
            transform.Origin.Y = 1; // 设置 Transform 的 pos.y 为 3
            transform.Basis = transform.Basis.Rotated(Vector3.Up, Mathf.DegToRad(45));
            xo_pawn.Transform = transform;
            AddChild(xo_pawn);
            Pawns[idx] = xo_pawn;
            IsX = !IsX;
        }
    }
    //根据bol返回xo的实例节点
    private RigidBody3D InitXO(bool xo)
    {
        if (xo)
        {
            return X.Instantiate<RigidBody3D>();
        }
        return O.Instantiate<RigidBody3D>();
    }
    //判断是否可以下棋子
    private bool IsPawn(uint idx)
    {
        if (Pawns[idx] == null)
        {
            return true;
        }
        return false;
    }

    //随机bol值
    protected void RandomIsX()
    {
        // 生成随机布尔值
        bool randomBool = new Random().Next(2) == 0;
        IsX = randomBool;
        GD.Print("随机布尔值: ", IsX);
    }
}