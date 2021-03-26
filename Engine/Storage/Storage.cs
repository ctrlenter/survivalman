using System.Collections.Generic;

namespace SurvivalMan{
    public class Storage : IStorage
    {

        public List<Item> items = new List<Item>();
        
        public virtual void AddItem(Item item){ }

        public virtual void RemoveItem(Item item){ }
    }
}