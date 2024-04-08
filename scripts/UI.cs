using Godot;
using Godot.Collections;
using System;

public partial class UI : Control
{
	[Signal] public delegate void StartReadingTextEventHandler(Array<string> textArray);
    [Signal] public delegate void SwitchToNextTextEventHandler();
    [Signal] public delegate void EndedReadingTextEventHandler();

	[Export] private Label _bottomTextBox;
	private Array<string> _textToDisplay;
	private int _nextText;



	public override void _Ready()
	{
		StartReadingText += LoadTextsToDisplay;
		SwitchToNextText += UpdateBottomTextBox;
	}



	private void LoadTextsToDisplay(Array<string> textArray)
	{
		_textToDisplay = textArray;
		_nextText = 0;

		UpdateBottomTextBox();
	}

	private void UpdateBottomTextBox()
	{
		if (_nextText == _bottomTextBox.Size[0])
		{
			EmitSignal(SignalName.EndedReadingText);
		}
		_bottomTextBox.Text = _textToDisplay[_nextText++];
	}
}
