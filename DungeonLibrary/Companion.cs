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
        public string Description { get; set; }
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
        public Companion(string name, int maxDamage, int minDamage, int hitChance, int block, int life, int maxLife, Animal animal, Item equippedItem, string descriptrion)
        {
            MaxLife = maxLife;
            Name = name;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            HitChance = hitChance;
            Block = block;
            Animal = animal;
            EquippedItem = equippedItem;
            Description = descriptrion;
            Life = life;
        }

        //methods

        public override string ToString()
        {
            return string.Format("\n-=-= COMPANION =-=-\n" +
                "{0} - {1}\nLife: {2} of {3}\nDamage: {4} to {5}\nBlock: {6}\nDescription:\n{7}", Name, Animal, Life, MaxLife, MinDamage, MaxDamage, Block, Description);
        }

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
