using Godot;
using System;

public partial class Bridge : Node2D
{
   public override void _Process(double delta)
   {
      base._Process(delta);

      GlobalPosition = new Vector2(GlobalPosition.X - GameManager.scrollingSpeed * (float)delta * 75, GlobalPosition.Y);
   }

}
