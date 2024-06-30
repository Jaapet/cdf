using Godot;
using System;

public partial class fin : Control
{
	private void _on_replay_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/game.tscn");
	}
	
	public override void _Ready()
	{
		PlayAnimation();
	}
	
	private void PlayAnimation()
	{
		GetNode<AnimationPlayer>("AnimationPlayer").Play("end");
	}
}
