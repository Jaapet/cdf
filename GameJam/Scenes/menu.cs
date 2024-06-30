using Godot;
using System;

public partial class menu : Control
{
	private void _on_quit_2_pressed()
	{
		GetTree().Quit();
	}

	private void _on_intro_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/game.tscn");
	}
}
