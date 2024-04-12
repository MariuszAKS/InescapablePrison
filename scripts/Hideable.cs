using Godot;
using System;

public partial class Hideable : Node2D
{
    private AnimatedSprite2D _sprite;
    private bool _occupied = false;



    public override void _Ready()
    {
        _sprite = GetChild<AnimatedSprite2D>(0);
    }



    public void Enter()
    {
        _occupied = true;
        _sprite.Frame = 1;
    }

    public void Leave()
    {
        _occupied = false;
        _sprite.Frame = 0;
    }

    public bool CheckIfOccupied()
    {
        return _occupied;
    }

    public void Destroy()
    {
        _occupied = false;
        _sprite.Frame = 2;
        GetChild(1).QueueFree();
    }
}