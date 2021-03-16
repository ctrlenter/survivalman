using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
namespace SurvivalMan{
    public class ItemEntity : Entity{
        public Item Item; 
        public ItemEntity(){

        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(Item.Texture, Bounds.ToRectangle(), Color.White);
        }

        public static ItemEntity Spawn(float x, float y, Item item){
            //Make a copy of this
            ItemEntity ie = new ItemEntity();
            ie.X = x;
            ie.Y = y;
            ie.Item = item;
            ie.Texture = item.Texture;
            ie.Type = EntityType.Item;
            return ie;
        }

    }
}