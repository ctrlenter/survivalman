using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;

namespace SurvivalMan{
    public class Player : Entity{
        public OrthographicCamera Camera;
        public float Speed = 200;
        public Player(OrthographicCamera camera) : base(){
            Camera = camera;
        }

        private void SetPos(){
            X = (Handler.Width / 2 - Bounds.Width / 2) + Camera.Position.X;
            Y = (Handler.Height / 2 - Bounds.Width / 2) + Camera.Position.Y;
        }

        public override void Update(GameTime gameTime)
        {
            Camera.Move(HandleMovement() * Speed * gameTime.GetElapsedSeconds());
            //Handle collision or sumthin
            if(Input.JustPressed(Keys.F)){
                Console.WriteLine($"{Camera.Position.X},{Camera.Position.Y}");
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.FillRectangle(Bounds, Color.Purple);
            batch.DrawRectangle(Bounds, Color.Black);
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
    }
}