using Godot;
using System;

public partial class Interactable
{
    private void OnAreaEntered2D(Area2D area)
    {
        GD.Print("Area Entered");
    }
}