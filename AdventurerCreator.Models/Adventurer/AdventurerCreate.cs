﻿using AdventureCreator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventurerCreator.Models.Adventurer
{
    public class AdventurerCreate
    {
        public string Name { get; set; }
        public Species Class { get; set; }

        public string WeaponChoice()
        {
            if (Class == Species.GreenAlien)
            {
                return "Blaster";
            }
            if (Class == Species.SpaceArcher)
            {
                return "Space Bow";
            }
            if (Class == Species.SpaceBarbarian)
            {
                return "Space Axe";
            }
            if (Class == Species.SpaceKnight)
            {
                return "Space Sword";
            }
            if (Class == Species.SpaceMonk)
            {
                return "Space Fists";
            }
            if (Class == Species.SpaceWizard)
            {
                return "Space Wand";
            }
            return "Space Weapon";
        }
    }
}
