using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
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

            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, Handler.Width, Handler.Height);
            Camera = new OrthographicCamera(viewportAdapter);

            World = new World();
            World.AddEntity((Player = new Player(Camera)));
            
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

            spriteBatch.FillRectangle(100, 100, 100, 100, Color.Black);
            World.Draw(spriteBatch);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
