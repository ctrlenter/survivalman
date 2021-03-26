using System;
using MonoGame.Extended;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SurvivalMan{
    public abstract class Entity{
        public Vector2 Position;
        public Texture2D Texture{get;set;}
        public const int DefaultSize = 32;
        public bool Dead = false;
        public int Scale = 1;
        public bool Solid;
        public EntityType Type;
        public InputManager Input => Handler.Input;

        public Entity(EntityType type){
            Type = type;
        }

        public Entity(string texId, EntityType type){
            Texture = Handler.Content.Load<Texture2D>(texId);
            Type = type;
        }

        public Entity(float x, float y, EntityType type){
            Position = new Vector2(x,y);
            Type = type;
        }

        public Entity(float x, float y, string texId, EntityType type){
            Position = new Vector2(x,y);
            Texture = Handler.Content.Load<Texture2D>(texId);
            Type = type;
        }

        public Entity SetScale(int scale){
            Scale = scale;
            return this;
        }


        public abstract void Draw(SpriteBatch batch);
        public abstract RectangleF GetCollisionBounds();

        public abstract RectangleF GetBounds();

        public abstract void Update(GameTime gameTime);

        public abstract Entity Copy();

    }
}