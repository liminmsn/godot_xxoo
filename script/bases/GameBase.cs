using System;
using System.Linq;
using System.Threading.Tasks;
using Godot;
public abstract partial class GameBase : Node
{
    [Export]
    protected Control Cureent, Setting, Winning;
    protected RigidBody3D Pos { get; set; }
    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed)
        {
            if (mouseButton.ButtonIndex == MouseButton.Left && Pos != null)
            {
                string idx = Pos.Name.ToString()[^1..];
                AddPawn(uint.Parse(idx));
                // GD.Print("鼠标左键点击", idx);
            }
        }
    }
    [Export]
    PackedScene X, O;
    private bool IsX;
    private RigidBody3D[] Pawns = new RigidBody3D[9];
    //下棋
    private async void AddPawn(uint idx)
    {
        if (GetPawn(idx) == null)
        {
            var xo_pawn = InitXO(IsX);
            var transform = Pos.Transform;
            transform.Origin.Y = 1; // 设置 Transform 的 pos.y 为 3
            transform.Basis = transform.Basis.Rotated(Vector3.Up, Mathf.DegToRad(45));
            xo_pawn.Transform = transform;
            AddChild(xo_pawn);
            Pawns[idx] = xo_pawn;
            if (Pawns.All(item => item != null))
            {
                // GD.Print("平局！！！");
                await Task.Delay(500);//延迟一秒
                Winning.Visible = true;
                Winning.GetChildren()[0].GetNode<Label>("Label3").Text = "draw!";
            }
            else
            if (IsWin(xo_pawn) != null) //判断当前棋子是否赢
            {
                // GD.Print($"{xo_pawn.GetMeta("type")} 获胜！！！");
                await Task.Delay(500);//延迟一秒
                Winning.Visible = true;
                Winning.GetChildren()[0].GetNode<Label>("Label3").Text = (String)xo_pawn.GetMeta("type");
            }
            else //下一个玩家走棋子
            {
                IsX = !IsX;
                Cureent.GetNode<Label>("Label2").Text = IsX ? "X" : "O";
            }
        }
    }
    //判断当前下的棋子是否赢
    private RigidBody3D IsWin(RigidBody3D pawn)
    {
        /**
        6 | 7 | 8
        -----------
        3 | 4 | 5
        -----------
        0 | 1 | 2
        */
        RigidBody3D pawn_win = null;
        string[][] ar_x = { new string[3], new string[3], new string[3] };
        string[][] ar_y = { new string[3], new string[3], new string[3] };
        string[][] ar_xyx = { new string[3], new string[3] };
        string[][][] ar_all = { ar_x, ar_y, ar_xyx };
        for (uint y = 0; y < 3; y++)
        {
            //x轴线判断胜利的玩家
            for (uint x = 0; x < 3; x++)
            {
                var pawn_x = GetPawn(y * 3 + x);
                var pawn_y = GetPawn(x * 3 + y);
                if (pawn_x != null)
                {
                    ar_x[y][x] = (string)pawn_x.GetMeta("type");
                }
                if (pawn_y != null)
                {
                    ar_y[y][x] = (string)pawn_y.GetMeta("type");
                }
            }
        }

        //斜线判断
        for (uint idx = 3; idx > 0; idx--)
        {
            for (uint x = 0; x < 3; x++)
            {
                if (idx == 3)
                {
                    var ar_xy = GetPawn(idx * x + x);
                    if (ar_xy != null)
                    {
                        ar_xyx[0][x] = (string)ar_xy.GetMeta("type");
                    }
                }
                if (idx == 2)
                {
                    var ar_yx = GetPawn(idx * (x + 1));
                    if (ar_yx != null)
                    {
                        ar_xyx[1][x] = (string)ar_yx.GetMeta("type");
                    }
                }
            }
        }

        Array.ForEach(ar_all, ar =>
           {
               for (uint y = 0; y < ar.Length; y++)
               {
                   if (ar[y].All(val => val == ar[y][0] && val != null))
                   {
                       pawn_win = pawn;
                   }
               }
           });
        return pawn_win;
    }
    //清空棋盘
    protected void DestoryAll()
    {
        for (uint i = 0; i < Pawns.Length; i++)
        {
            if (Pawns[i] != null)
            {
                RemoveChild(Pawns[i]);
                Pawns[i] = null;
                // GD.Print(Pawns[i]);
            }
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
    private RigidBody3D GetPawn(uint idx)
    {
        if (Pawns[idx] == null)
        {
            return null;
        }
        return Pawns[idx];
    }
    //随机bol值
    protected void RandomIsX()
    {
        // 生成随机布尔值
        bool randomBool = new Random().Next(2) == 0;
        IsX = randomBool;
        GD.Print("随机布尔值: ", IsX);
        Cureent.GetNode<Label>("Label2").Text = IsX ? "X" : "O";
        DestoryAll(); //清空棋盘
        Setting.Visible = false;
        Winning.Visible = false;
    }
}