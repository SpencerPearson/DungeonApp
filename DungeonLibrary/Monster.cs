using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //fields - biz rule on MinDamage - cannot be more than maxDamage and cannot be less than 0
        private int _minDamage;

        //props
        public int MaxDamage { get; set; }
        public string Description { get; set; }
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
                    _minDamage = 1;
                }//end else
            }//end set
        }//end minDamage

        //ctors
        public Monster()
        {

        }
        public Monster(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description)
        {
            //Set maxLife and maxDamage first bc other props rely on their value
            MaxLife = maxLife;
            MaxDamage = maxDamage;
            Name = name;
            Life = life;
            HitChance = hitChance;
            Block = block;
            MinDamage = minDamage;
            Description = description;
        }

        //methods - ToString() and CalcDamage()
        public override string ToString()
        {
            return string.Format("\n-=-= MONSTER =-=-\n" +
                "{0}\nLife: {1} of {2}\nDamage: {3} of {4}\nBlock: {5}\nDescription:\n{6}", Name, Life, MaxLife, MinDamage, MaxDamage, Block, Description);
        }//end ToString()

        //We are overriding the CalcDamage to use properties MinDamage and MaxDamage
        public override int CalcDamage()
        {
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);
            //We added 1 above because the upper bound for .Next() is exclusive. To include all of the maxDamage, we add 1.
        }//end CalcDamage
    }
}
