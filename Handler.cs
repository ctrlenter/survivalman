using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace SurvivalMan{
    public class Handler{
        public static Game1 Game => Game1.Instance;
        public static InputManager Input => Game.Input;
        public static SpriteBatch SpriteBatch => Game.spriteBatch;
        public static ContentManager Content => Game.Content;
        public static int Width = 800;
        public static int Height = 600;
        public static World World = Game.World;
        public static Player Player = Game.Player;
        public static EntityData EntityData;
        public static ItemData ItemData;
        public static bool Debug = false;

        public static void SpawnEntity(float x, float y, Entity entity) => World.SpawnEntity(x, y, entity);
    }
}