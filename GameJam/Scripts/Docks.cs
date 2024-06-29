using Godot;
using System;
using System.Collections.Generic;

public partial class Docks : Node2D
{
   private Node2D docks;


   public override void _Ready()
   {
      base._Ready();

      docks = GetNode<Node2D>("Docks");
   }

   public override void _Process(double delta)
   {
      base._Process(delta);

      foreach (Node2D node in docks.GetChildren())
      {
         node.Position = new Vector2(node.Position.X - GameManager.scrollingSpeed, node.Position.Y);
      }
   }
}
// set jeux  5minute
// algo 30 s pour change sprite
// donc 10 * algo
// bordure_Haute = [800 - 1000]
//bordure_basse = [0 - 200]
//bordure_game = [200 - 800]
//
//obstacle_a: = shark
//obstacle_B: = bidont
//obstacle_C: = bateau_mouche
//obstacle_D: = police
//obstacle_E: = journaliste

//