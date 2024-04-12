using Godot;
using Godot.Collections;
using System;

public partial class UI : Control
{
	[Export] private PanelContainer _bottomDialogPanel;
	[Export] private Label _bottomDialogLabel;
	private Array<string> _lines;
	private int _lineId;



	public override void _Ready()
	{
		SignalBus.Instance.UI_DialogPassTexts += DialogLoadLines;
		SignalBus.Instance.UI_DialogNext += DialogNextLine;
		SignalBus.Instance.UI_DialogFinish += DialogFinish;

		DialogFinish();
	}



	private void DialogLoadLines(Array<string> lines)
	{
		_bottomDialogPanel.Visible = true;
		_lines = lines;
		_lineId = 0;

		DialogNextLine();
	}

	private void DialogNextLine()
	{
		if (_lineId >= _lines.Count)
		{
			SignalBus.Instance.EmitSignal(SignalBus.SignalName.UI_DialogFinish);
		}
		else
		{
			_bottomDialogLabel.Text = _lines[_lineId++];
		}
	}

	private void DialogFinish()
	{
		_bottomDialogLabel.Text = "";
		_bottomDialogPanel.Visible = false;
	}
}
