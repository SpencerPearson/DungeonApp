using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Character
    {
        //fields
        private int _life; //We do not want life to be below 0 or more than maxLife
        //props
        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxLife { get; set; }
        public int Life
        {
            get { return _life; }
            set
            {
                //biz rule - life should not be below 0 and should not exceed maxLife
                if (value <= MaxLife)
                {
                    //good to go
                    _life = value;
                }
                else
                {
                    _life = MaxLife;
                }//end else
            }//end int Life
        }
        //ctors
        //Since we don't inherit constructors, we will define the CTORS in the other classes. We will still get the default ctor but will be unable to use it since this class is abstract.


        //methods - Below are the methods we want to be inherited by the Player and Monster classses. So, we are creating default versions of each method here, which the child classes will use if they do not override these default methods.
        public virtual int CalcBlock()
        {
            //VIRTUAL - allows us to override in derived classes
            //This basic version just returns Block, but this will give us the option to do something different in child classes.
            return Block;
        }//end CalcBlock()

        //MINILAB Make a CalcHitChance() that returns HitChance...Make it overrideable
        public virtual int CalcHitChance()
        {
            //Virtual keyword - allows but does not require us to override this method in any child class.

            //By default we will give a 5%
            //So we will return the prices times .95
            return HitChance;
        }//end CalcHitChance

        //make CalcDamage() and return 0 forf the base version
        public virtual int CalcDamage()
        {
            return 0;
            //starting with 0...we will override this in Player and Monster
        }
    }
}
