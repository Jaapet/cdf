using Godot;
using System;

public partial class intro : Node2D
{
	public override void _Ready()
	{
		PlayAnimation();
	}

	private async void PlayAnimation()
	{
		GetNode<AnimationPlayer>("AnimationPlayer").Play("IN");
		await ToSignal(GetTree().CreateTimer(6), "timeout");
		
		GetNode<AnimationPlayer>("AnimationPlayer").Play("OUT");
		await ToSignal(GetTree().CreateTimer(2), "timeout");
		
		GetTree().ChangeSceneToFile("res://Scenes/menu.tscn");
	}
}
