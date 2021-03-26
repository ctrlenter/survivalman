using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace SurvivalMan{
    public class Chest : Entity
    {
        public Storage Inventory;

        public Chest() : base(EntityType.Storage){
            Texture = Handler.Content.Load<Texture2D>("world/chest");
            Solid = true;
        }

        public override Entity Copy()
        {
            var chest = new Chest();
            chest.Inventory = Inventory;
            chest.Scale = Scale;
            chest.Texture = Texture;
            return chest;
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
            return new RectangleF(Position.X, Position.Y + (7 * Scale), Texture.Width * Scale, 9 * Scale);
        }
        public override void Update(GameTime gameTime)
        {
            
        }
    }
}