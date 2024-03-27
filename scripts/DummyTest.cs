using Godot;
using Godot.Collections;

public partial class DummyTest : Area2D, IInteractable
{
	[Export] Array<string> texts;



	public void Interaction()
    {
		foreach (string text in texts)
		{
        	GD.Print(text);
		}
    }
}
