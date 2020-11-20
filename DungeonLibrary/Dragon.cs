using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Dragon : Monster
    {
        //fields - N/A

        //props
        public bool IsScaly { get; set; }

        //ctor
        public Dragon(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool isScaly) :base (name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            IsScaly = isScaly;
        }

        public Dragon()
        {
            MaxLife = 6;
            MaxDamage = 3;
            Name = "Baby Dragon";
            Life = 6;
            HitChance = 25;
            Block = 20;
            MinDamage = 1;
            Description = "A freshly-hatched baby dragon. It still looks dangerous thuogh...";
            IsScaly = false;
        }//end default ctor

        //methods
        public override string ToString()
        {
            return base.ToString() + (IsScaly ? "It has thick scales" : "Not so well-armored");
        }
        public override int CalcBlock()
        {
            int calculatedBlock = Block;
            if (IsScaly)
            {
                calculatedBlock += calculatedBlock / 4;
            }
            return calculatedBlock;
        }
    }
    public class Orc : Monster
    {
        //fields - N/A

        //props
        public bool IsArmored { get; set; }

        //ctor
        public Orc(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool isArmored) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            IsArmored = isArmored;
        }

        public Orc()
        {
            MaxLife = 12;
            MaxDamage = 5;
            Name = "Orc";
            Life = 12;
            HitChance = 40;
            Block = 20;
            MinDamage = 2;
            Description = "An ugly green orc. It lunges toward you with a dull recognition.";
            IsArmored = false;
        }//end default ctor

        //methods
        public override string ToString()
        {
            return base.ToString() + (IsArmored ? "It is wearing a crude set of armor" : "Has no armor.");
        }
        public override int CalcBlock()
        {
            int calculatedBlock = Block;
            if (IsArmored)
            {
                calculatedBlock += calculatedBlock / 4;
            }
            return calculatedBlock;
        }
    }
    public class Specter : Monster
    {
        //fields - N/A

        //props
        public bool IsSpooky { get; set; }

        //ctor
        public Specter(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool isSpooky) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            IsSpooky = isSpooky;
        }

        public Specter()
        {
            MaxLife = 15;
            MaxDamage = 4;
            Name = "Specter";
            Life = 12;
            HitChance = 40;
            Block = 30;
            MinDamage = 2;
            Description = "Just your run-of-the-mill evil spirit.";
            IsSpooky = false;
        }//end default ctor

        //methods
        public override string ToString()
        {
            return base.ToString() + (IsSpooky ? "However, this one seems particularly spooky." : "It's not even that spooky.");
        }
        public override int CalcBlock()
        {
            int calculatedBlock = Block;
            if (IsSpooky)
            {
                calculatedBlock += calculatedBlock / 2;
            }
            return calculatedBlock;
        }
    }
}
