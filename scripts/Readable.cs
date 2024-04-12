using Godot;
using Godot.Collections;
using System;

public partial class Readable : Node2D
{
    [Export] private Array<string> _lines;

    public void Read()
    {
        SignalBus.Instance.EmitSignal(SignalBus.SignalName.UI_DialogPassTexts, _lines);
    }
}