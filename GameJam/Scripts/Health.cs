using Godot;
using System;
using System.Collections.Generic;

public partial class Health : PanelContainer
{
   List<TextureRect> hearts = new List<TextureRect>();

   public override void _Ready()
   {
      base._Ready();

      hearts.Add(GetNode<TextureRect>("MarginContainer/HBoxContainer/AspectRatioContainer/Hearth"));
      hearts.Add(GetNode<TextureRect>("MarginContainer/HBoxContainer/AspectRatioContainer2/Hearth"));
      hearts.Add(GetNode<TextureRect>("MarginContainer/HBoxContainer/AspectRatioContainer3/Hearth"));
   }


   public void SetHealth(int health)
   {
      for (var i = 0; i < hearts.Count; i++)
      {
         if (i < health)
            hearts[i].Visible = true;
         else
            hearts[i].Visible = false;
      }
   }

   private void OnPlayerTakedDamage()
   {
      SetHealth(Player.instance.currentHealth);
   }
}
