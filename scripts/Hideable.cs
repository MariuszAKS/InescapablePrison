using Godot;
using System;

public partial class Hideable : Node2D
{
    private bool _occupied = false;

    public void HideIn()
    {
        _occupied = true;
        GD.Print("Hide");
    }

    public void GetOut()
    {
        _occupied = false;
    }

    public bool CheckIfOccupied()
    {
        return _occupied;
    }
}