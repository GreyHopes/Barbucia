using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Barbucia
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        Texture2D textureCarte;
        Rectangle PosCarte;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;

            //Rectange position de la carte
            int posX = GraphicsDevice.Viewport.Width / 2 - 200;
            int posY = GraphicsDevice.Viewport.Height / 2 - 200;
            Rectangle posCarte = new Rectangle(posX, posY, 400, 400);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            textureCarte = Content.Load<Texture2D>("Conseiller");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected  void RotateCarte()
        {
            Vector2 v1 = new Vector2(PosCarte.X, PosCarte.Y);
            Vector2 v2 = new Vector2(PosCarte.X + PosCarte.Width,PosCarte.Y);
            Vector2 v3 = new Vector2(PosCarte.X, PosCarte.Y + PosCarte.Height);
            Vector2 v4 = new Vector2(PosCarte.X + PosCarte.Width, PosCarte.Y + PosCarte.Height);

            v1 = Vector2.Transform(v1, Matrix.CreateRotationZ(MathHelper.ToRadians(30)));
            v2 = Vector2.Transform(v2, Matrix.CreateRotationZ(MathHelper.ToRadians(30)));
            v3 = Vector2.Transform(v3, Matrix.CreateRotationZ(MathHelper.ToRadians(30)));
            v4 = Vector2.Transform(v4, Matrix.CreateRotationZ(MathHelper.ToRadians(30)));

            PosCarte = new Rectangle(v1, v2, v3, v4);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            
            spriteBatch.Draw(textureCarte,PosCarte, Color.White);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
