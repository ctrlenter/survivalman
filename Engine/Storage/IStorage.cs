using System.Collections.Generic;

namespace SurvivalMan{
    public interface IStorage{
        
        void AddItem(Item item);
        void RemoveItem(Item item);

    }
}