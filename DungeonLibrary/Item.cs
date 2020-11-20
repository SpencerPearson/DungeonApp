using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Item
    {
        //fields
        //props
        public float Weight { get; set; }
        public bool IsConsumable { get; set; }
        public string Type { get; set; }
        public bool IsTwoHanded { get; set; }

        //ctors
        public Item()
        {

        }
        public Item(float weight, bool isConsumable, string type, bool isTwoHanded)
        {
            Weight = weight;
            IsConsumable = isConsumable;
            Type = type;
            IsTwoHanded = IsTwoHanded;
        }
        //methods

    }
}
