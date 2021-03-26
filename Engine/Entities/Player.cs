using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;

namespace SurvivalMan{
    public class Player : Entity{
        public OrthographicCamera Camera;
        public float Speed = 200;
        public Vector2 Pos;
        public Player(OrthographicCamera camera) : base(EntityType.Player){
            Camera = camera;
        }

        /*private void SetPos(){
            X = (Handler.Width / 2 - GetBounds().Width / 2) + Camera.Position.X;
            Y = (Handler.Height / 2 - GetBounds().Width / 2) + Camera.Position.Y;
        }
        */
        
        public List<Entity> GetEntitiesInView(){
            var entities = Handler.World.entities.FindAll(r => Camera.BoundingRectangle.Intersects(r.GetBounds()));
            return entities;
        }

        public override void Update(GameTime gameTime)
        {

            Pos += HandleMovement() * Speed * gameTime.GetElapsedSeconds();
            
            //Camera.Move(HandleMovement() * Speed * gameTime.GetElapsedSeconds());
            //SetPos();
            //Handle collision or sumthin
            
            if(Input.JustPressed(Keys.F)){
                Console.WriteLine($"{Camera.Position.X},{Camera.Position.Y}");
            }
            if(Input.JustPressed(Keys.F3)){
                Handler.Debug = !Handler.Debug;
            }

            if(Input.JustPressed(Keys.F4)){
                Console.WriteLine(GetEntitiesInView().Count);
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.FillRectangle(GetBounds(), Color.Purple);
            batch.DrawRectangle(GetBounds(), Color.Black);
        }

        private Vector2 HandleMovement(){
            var moveDir = Vector2.Zero;
            

            if(Input.IsHeld(Keys.W)){
                moveDir -= Vector2.UnitY;
            }
            if(Input.IsHeld(Keys.S)){
                moveDir += Vector2.UnitY;
            }
            if(Input.IsHeld(Keys.A)){
                moveDir -= Vector2.UnitX;
            }
            if(Input.IsHeld(Keys.D)){
                moveDir += Vector2.UnitX;
            }
            return moveDir;

        }

        public void MoveX(float amt){
            
        }

        public void MoveY(float amt){

        }

        public override RectangleF GetBounds()
        {
            return new RectangleF(Pos.X, Pos.Y, DefaultSize * Scale, DefaultSize * Scale);
        }
        public override RectangleF GetCollisionBounds()
        {
            return GetBounds();
        }
        
        public override Entity Copy()
        {
            var player = new Player(Camera);
            return player;
        }
    }
}