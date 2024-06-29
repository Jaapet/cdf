using Godot;
using System;

public partial class WaterShip : WaterObject
{
   public override void _Ready()
   {
      base._Ready();

      AddToGroup("obstacle");
   }
}
