using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Player : Character
    {
        //About the above signature:
        //1. it is public
        //2. SEALED - this keyword indicates that a class cannot be used as a base class for other classes...no more inheritance can occur.
        //3. Player is a child of Character

        //fields
        //NO fields needed because no biz rules

        //props
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }//examples of containment - one complex object being used as a field in another complex object

        //ctors
        public Player(string name, int hitChance, int block, int life, int maxLife, Race characterRace, Weapon equippedWeapon)
        {
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
            Life = life;
        }

        public Player()
        {

        }

        //methods - ToString(), CalcDamage() CalcHitChance()
        public override string ToString()
        {
            return string.Format("-=-= {0} =-=-\n" +
                "Life: {1} of {2}\n" +
                "Hit Chance: {3}%\n" +
                "Weapon: {4}\n" +
                "Block: {5}\n" +
                "Description: {6}\n",
                Name, Life, MaxLife, CalcHitChance(), EquippedWeapon, Block, CharacterRace);
        }

        public override int CalcDamage()
        {
            //Created a random object
            Random rand = new Random();
            //Determine damage
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
            return damage;
        }

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }
    }
}
