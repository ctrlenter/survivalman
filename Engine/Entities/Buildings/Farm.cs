using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace SurvivalMan{
    public class Farm : Entity{
        public BuildingData Data;
        public Farm() : base(EntityType.Building){
            Texture = Handler.Content.Load<Texture2D>("buildings/farm");
            Scale = 12;
            Data = new BuildingData("Farm", "Grows and collects food and crops for you");
            Solid = true;
        }

        public override Entity Copy()
        {
            var farm = new Farm();
            farm.Data = Data;
            farm.Scale = Scale;
            farm.Texture = Texture;
            return farm;
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(Texture, GetBounds().ToRectangle(), Color.White);
            if(Handler.Debug){
                batch.DrawRectangle(GetCollisionBounds(), Color.Black, 2);
            }
        }

        public override RectangleF GetBounds()
        {
            return new RectangleF(Position.X, Position.Y, Texture.Width * Scale, Texture.Height * Scale);
        }

        public override RectangleF GetCollisionBounds()
        {
            return new RectangleF(Position.X+ ((Texture.Width / 2 ) * Scale) + (1 * Scale), Position.Y + (6 * Scale), (Texture.Width / 2 - 2) * Scale, (Texture.Height - 6) * Scale);
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}