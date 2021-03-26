using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SurvivalMan{
    public class World{
        public List<Entity> entities = new List<Entity>();
        public Player Player;
        //TODO: Add tiles to this thing. 
        
        public World(Player player){
            Player = player;
            Console.WriteLine(Handler.ItemData != null);
            Console.WriteLine(Handler.ItemData.itemStick != null);
            SpawnEntity(-200, 200, Handler.ItemData.itemStick.SpawnEntity());
            SpawnEntity(500,500, Handler.EntityData.Tree.SetScale(10));
            SpawnEntity(-100, -100, Handler.EntityData.Chest);
            SpawnEntity(0, -300, Handler.EntityData.Farm);
        }

        public void SpawnEntity(float x, float y, Entity entity){
            var copy = entity.Copy();
            copy.Position = new Vector2(x,y);
            AddEntity(copy);
        }

        public void AddEntity(Entity entity){
            entities.Add(entity);
        }

        public void Draw(SpriteBatch batch){
            //todo: add a render order. Currently, the player is above the other entities.
            Player.Draw(batch);
            for(var i = 0; i < entities.Count; i++){
                entities[i].Draw(batch);
            }
        }

        public void Update(GameTime gameTime){
            Player.Update(gameTime);
            for(var i = 0; i < entities.Count; i++){
                if(entities[i].Dead) entities.RemoveAt(i);
                entities[i].Update(gameTime);
            }
        }
    }
}