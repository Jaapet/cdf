using Godot;
using System;

public partial class EndScene : Control
{
	private void _on_menu_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/menu.tscn");
	}
}
