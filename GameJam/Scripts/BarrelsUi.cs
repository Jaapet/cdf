using Godot;
using System;

public partial class BarrelsUi : PanelContainer
{
   public static BarrelsUi instance;

   private Label nbBarrels;

   public override void _Ready()
   {
      instance = this; // Singleton

      nbBarrels = GetNode<Label>("MarginContainer/HBoxContainer/NbLabel");
   }

   public void SetNbBarrels()
   {
      nbBarrels.Text = GameManager.nbBarrels.ToString();
   }
}
