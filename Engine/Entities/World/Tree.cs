using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace SurvivalMan{
    public class Tree : Entity
    {
        public Tree() : base("world/tree", EntityType.Tree)
        {
            Solid = true;
        }

        public override Entity Copy()
        {
            var tree = new Tree();
            tree.Scale = Scale;
            return tree;
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(Texture, GetBounds().ToRectangle(), Color.White);
            if(Handler.Debug) batch.DrawRectangle(GetCollisionBounds(), Color.Black, 2);
        }

        public override RectangleF GetBounds()
        {
            return new RectangleF(X, Y, Texture.Width * Scale, Texture.Height * Scale);
        }
        public override RectangleF GetCollisionBounds()
        {
            return new RectangleF(X+ ( 7 * Scale), Y + (11 * Scale), 2 * Scale, 5 * Scale);
        }
        public override void Update(GameTime gameTime)
        {
            
        }
    }
}