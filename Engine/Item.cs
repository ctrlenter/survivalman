using System;
using Microsoft.Xna.Framework.Graphics;

namespace SurvivalMan{
    public class Item{
        public Texture2D Texture;
        public string Name;
        public string Description;

        public Item(string name, string desc, string texId){
            Name = name;
            Description = desc;
            Texture = Handler.Content.Load<Texture2D>(texId);
        }

        private Item(string name, string desc, Texture2D texture){
            Name = name;
            Description = desc;
            Texture = texture;
        }  

        public Item Copy(){
            var item = new Item(Name,Description,Texture);
            return item;
        }

        public ItemEntity SpawnEntity(){
            var itemEntity = new ItemEntity();
            itemEntity.Item = this;
            return itemEntity;
        }
    }
}