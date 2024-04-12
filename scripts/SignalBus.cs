using Godot;
using Godot.Collections;
using System;

public partial class SignalBus : Node2D
{
    [Signal] public delegate void UI_DialogPassTextsEventHandler(Array<string> texts);
    [Signal] public delegate void UI_DialogNextEventHandler();
    [Signal] public delegate void UI_DialogFinishEventHandler();

    public static SignalBus Instance;

    

    public override void _Ready()
    {
        Instance = this;
    }
}