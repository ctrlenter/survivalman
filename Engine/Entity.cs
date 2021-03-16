using System;
using MonoGame.Extended;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SurvivalMan{
    public class Entity{
        public float X{get;set;}
        public float Y{get;set;}
        public Texture2D Texture{get;set;}
        public const int DefaultSize = 32;
        public bool Dead = false;
        public int Scale = 1;
        public EntityType Type;
        public RectangleF Bounds{
            get{
                return new RectangleF(X, Y, DefaultSize * Scale, DefaultSize * Scale);
            }
        }
        public InputManager Input => Handler.Input;


        public Entity(){

        }

        public Entity(string texId, int scale = 1){
            Texture = Handler.Content.Load<Texture2D>(texId);
            Scale = scale;
        }

        public Entity(float x, float y){
            X = x;
            Y = y;
        }

        public Entity(float x, float y, string texId){
            X = x;
            Y = y;
            Texture = Handler.Content.Load<Texture2D>(texId);
        }

        public Entity SetScale(int scale){
            Scale = scale;
            return this;
        }

        public virtual void Draw(SpriteBatch batch){}

        public virtual void Update(GameTime gameTime){}

        public static void SpawnEntity(float x, float y, Entity entity){
            var ent = new Entity();
            ent.X = x;
            ent.Y = y;
            ent.Texture = entity.Texture;
            ent.Scale = entity.Scale;

            Handler.World.AddEntity(ent);
        }
    }
}