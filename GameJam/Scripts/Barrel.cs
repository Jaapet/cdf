using Godot;
using System;

public partial class Barrel : WaterObject
{
   public override void _Ready()
   {
      base._Ready();

      AddToGroup("barrel");
   }
}
