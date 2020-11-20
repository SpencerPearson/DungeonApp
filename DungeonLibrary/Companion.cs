using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Companion : Character
    {
        //fields
        private int _minDamage;
        //props
        public Animal Animal { get; set; }
        public Item EquippedItem { get; set; }
        public int MaxDamage { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    //Tried to set the value outside of our range
                    _minDamage = 1;
                }
            }
        }
        //ctors
        public Companion(string name, int maxDamage, int minDamage, int hitChance, int block, int life, int maxLife, Animal animal, Item equippedItem)
        {
            Name = name;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            HitChance = hitChance;
            Block = block;
            Life = life;
            MaxLife = maxLife;
            Animal = animal;
            EquippedItem = equippedItem;
        }

        //methods

        public override int CalcDamage()
        {
            //Created a random object
            Random rand = new Random();
            //Determine damage
            int damage = rand.Next(MinDamage, MaxDamage + 1);
            return damage;
        }
    }
}
