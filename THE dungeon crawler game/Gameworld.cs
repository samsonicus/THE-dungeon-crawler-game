using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace THE_dungeon_crawler_game
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {

        public static float updateSpeed = 1;

        private static ContentManager contentManager;
        public static ContentManager ContentManager
        {
            get
            {
                return contentManager;
            }
        }

        private List<GameObject> gameObjects = new List<GameObject>();
        private static List<GameObject> toBeAdded = new List<GameObject>();
        private static List<GameObject> toBeRemoved = new List<GameObject>();
        private static GraphicsDeviceManager graphics;


        public static Rectangle ScreenSize
        {
            get
            {
                return graphics.GraphicsDevice.Viewport.Bounds;
            }
        }

        #region Add/Remove methods


        /// <summary>
        /// Adds a gameobject to the toBeAdded list.
        /// </summary>
        /// <param name="go"></param>
        public static void AddGameObject(GameObject go)
        {
            toBeAdded.Add(go);
        }

        /// <summary>
        /// Removes an object, by adding it to the toBeRemoved list.
        /// </summary>
        /// <param name="go"></param>
        public static void RemoveGameObject(GameObject go)
        {
            toBeRemoved.Add(go);
        }
        #endregion  


        SpriteBatch spriteBatch;
        private bool isPaused;

        public GameWorld()
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
            contentManager = Content;
            gameObjects = new List<GameObject>();
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
            AnimatedGameObject aGO = new Entity(100, new Vector2(0.5f, 0.5f),4, 5, new Vector2(0.5f,0.5f), "HeroStrip");
           //AnimatedGameObject aGO = new AnimatedGameObject(4, 5, new Vector2(new Random().Next(), new Random().Next()), "HeroStrip");
            gameObjects.Add(aGO);
            AddGameObject(aGO);


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
            if (!isPaused)
            {
                foreach (GameObject go in gameObjects)
                {
                    go.Update(gameTime);
                }
            }

            base.Update(gameTime);
        }


        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}
