using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon : Item
    {       
        //fields
        private int _minDamage;

        //properties - props w. business rules should be listed last in the list
        public int MaxDamage { get; set; }
        public string Name { get; set; }
        public int BonusHitChance { get; set; }
        public bool IsRanged { get; set; }
        //Biz rule on MinDamage - cannot be more than maxDamage and cannot be less than 1
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
                }//end else
            }//end set
        }//end MinDamage

        //ctors
        public Weapon() { }

        //FQ CTOR
        public Weapon(int minDamage, int maxDamage, string name, float weight, bool isConsumable, string type, bool isTwoHanded, int bonusHitChance, bool isRanged) :base(weight, isConsumable, type, isTwoHanded)
        {
            //Assign property values to param values - If you have any properties that have biz rules based on other properties, set the other props first and then set your prop with the biz rule.
            MaxDamage = maxDamage;
            MinDamage = minDamage;//Set minDamage here after maxDamage because minDamage relies on the value for maxDamage when being set.

            Name = name;
            BonusHitChance = bonusHitChance;
            IsRanged = isRanged;
            

        }
        //methods
        public override string ToString()
        {
            //return base.ToString();
            return string.Format("{0}\t{1} to {2} Damage\n" +
                "Bonus Hit: {3}%\t{4}", Name, MinDamage, MaxDamage, BonusHitChance,
                IsTwoHanded ? "Two-Handed" : "One-Handed");
        }
    }
}
