using Godot;
using System;

public partial class Heart : WaterObject
{
   public override void _Ready()
   {
      base._Ready();

      AddToGroup("heart");
   }
}
