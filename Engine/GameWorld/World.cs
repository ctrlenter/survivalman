using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SurvivalMan{
    public class World{
        public List<Entity> entities = new List<Entity>();
        //TODO: Add tiles to this thing. 
        
        public World(){
            AddEntity(ItemEntity.Spawn(-200, 200, ItemData.itemStick.Copy()));
        }

        public void AddEntity(Entity entity){
            entities.Add(entity);
        }

        public void Draw(SpriteBatch batch){
            for(var i = 0; i < entities.Count; i++){
                entities[i].Draw(batch);
            }
        }

        public void Update(GameTime gameTime){
            for(var i = 0; i < entities.Count; i++){
                if(entities[i].Dead) entities.RemoveAt(i);
                entities[i].Update(gameTime);
            }
        }
    }
}