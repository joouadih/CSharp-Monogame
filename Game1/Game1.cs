using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Scene bikeScene;


        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            Content.RootDirectory = "Content";
        }


        //Init all data
        protected override void Initialize()
        {
            bikeScene = new Scene(Content);
            base.Initialize();
        }


        /// Load function - This is where to load your content properly
        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

        }


        /// Unload function - This is where to unload your content properly
        protected override void UnloadContent()
        {
            
        }

        /// Update function - This is where all logic happends
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            bikeScene.Update(gameTime, GraphicsDevice.Viewport );
            // TODO: Add your update logic here



            base.Update(gameTime);
        }


        /// Draw function - This is where all graphics are drawn
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin();

            // Bike Level Scene
            bikeScene.Draw(spriteBatch);

            spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}
