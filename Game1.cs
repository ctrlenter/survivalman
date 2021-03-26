using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using MonoGame.Extended.ViewportAdapters;

namespace SurvivalMan
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public static Game1 Instance;
        public SpriteBatch spriteBatch;
        public InputManager Input;
        public OrthographicCamera Camera;
        public World World;
        public Player Player;
        public EntityData EntityData;
        public ItemData ItemData;
        public CollisionComponent CollisionComponent;


        public Game1()
        {
            Instance = this;
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = Handler.Width;
            _graphics.PreferredBackBufferHeight = Handler.Height;
            _graphics.ApplyChanges();

            Input = new InputManager(this);
            this.Components.Add(Input);
            base.Initialize();

            EntityData = new EntityData();
            ItemData = new ItemData();
            Handler.EntityData = EntityData;
            Handler.ItemData = ItemData;

            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, Handler.Width, Handler.Height);
            Camera = new OrthographicCamera(viewportAdapter);
            Player = new Player(Camera);
            World = new World(Player);
            Handler.Player = Player;
            Handler.World = World;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            World.Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            var transformMatrix = Camera.GetViewMatrix();
            spriteBatch.Begin(transformMatrix: transformMatrix, 
                blendState: BlendState.AlphaBlend,
                samplerState: SamplerState.PointClamp);

            World.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
