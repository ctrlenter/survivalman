using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
namespace SurvivalMan{
    public class ItemEntity : Entity{
        public Item Item; 
        public ItemEntity() : base(EntityType.Item){
            
        }

        public override Entity Copy()
        {
            var itemEnt = new ItemEntity();
            itemEnt.Item = Item;
            itemEnt.Position = new Vector2(Position.X, Position.Y);
            itemEnt.Scale = Scale;
            return itemEnt;
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(Item?.Texture, GetBounds().ToRectangle(), Color.White);
        }

        public override RectangleF GetBounds()
        {
            return new RectangleF(Position.X, Position.Y, DefaultSize * Scale, DefaultSize * Scale );
        }
        public override RectangleF GetCollisionBounds()
        {
            return GetBounds();
        }
        public override void Update(GameTime gameTime)
        {
            //Eh idk about this one fam
        }
    }
}