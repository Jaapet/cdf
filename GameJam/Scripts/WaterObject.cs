using Godot;
using System;

public partial class WaterObject : CharacterBody2D
{
   public override void _Ready()
   {
      base._Ready();

      AddToGroup("water_object");
   }

   public override void _Process(double delta)
   {
      base._Process(delta);

      GlobalPosition = new Vector2(GlobalPosition.X - GameManager.scrollingSpeed, GlobalPosition.Y);
   }

   public void Death()
   {
      QueueFree();
   }
}
