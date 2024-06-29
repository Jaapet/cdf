using Godot;
using System;

public partial class WaterObject : CharacterBody2D
{
   #region Components
   private AnimationPlayer animationPlayer;
   #endregion

   public override void _Ready()
   {
      base._Ready();

      animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");

      AddToGroup("water_object");
   }

   public override void _Process(double delta)
   {
      base._Process(delta);

      GlobalPosition = new Vector2(GlobalPosition.X - GameManager.scrollingSpeed, GlobalPosition.Y);
   }

   public void Death()
   {
      animationPlayer.Play("Death");
   }
}
