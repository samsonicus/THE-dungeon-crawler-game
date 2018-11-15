using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace THE_dungeon_crawler_game
{
    /// <summary>
    /// Enum for player direction
    /// </summary>
    public enum PlayerDirection { down,up,right,left}
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {

        public static float updateSpeed = 1;
        private Texture2D collisionTexture;
        private static ContentManager contentManager;
        public static ContentManager ContentManager
        {
            get
            {
                return contentManager;
            }
        }

        private static GameMap activeGameMap;
        public static GameMap ActiveGameMap
        {
            get { return activeGameMap; }
        }
        private List<GameObject> gameObjects = new List<GameObject>();
        private static List<GameObject> toBeAdded = new List<GameObject>();
        private static List<GameObject> toBeRemoved = new List<GameObject>();
        private static GraphicsDeviceManager graphics;
        private static Vector3 cameraPosition;
        public static Vector3 CameraPosition
        {
            get
            {
                return cameraPosition;
            }
        }


        private static Player player;
        public static Player Player
        {
            get { return player; }
        }
        
        /// <summary>
        /// Gets and returns the size of the screen that it is deisplaying on.
        /// </summary>
        public static Rectangle ScreenSize
        {
            get
            {
                return graphics.GraphicsDevice.Viewport.Bounds;
            }
        }

        #region camera
        public static void SetCameraPosition(int x,int y)
        {
            cameraPosition = new Vector3(-x+graphics.PreferredBackBufferWidth*0.5f, -y+graphics.PreferredBackBufferHeight*0.5f, 0); 
        }

        
        #endregion

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
        /// Adds multiple gameObjects to the toBeAdded list
        /// </summary>
        /// <param name="gameObjects">List of gameObjects to be added</param>
        public static void AddMultipleGameObjects(List<GameObject> gameObjects)
        {
            toBeAdded.AddRange(gameObjects);
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
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.ApplyChanges();
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
            collisionTexture = Content.Load<Texture2D>("CollisionTexture");

            //string path = AppDomain.CurrentDomain.BaseDirectory + @"\Content\TextFiles\PlayerSprites.txt";
            //string readFile = File.ReadAllText(path);


            player = new Player(100, new Vector2(10,10), 4, 4, 4, new Vector2(100,100), "PlayerAllDirections");
            gameObjects.Add(player);
            gameObjects.Add(new HUD());
            gameObjects.Add(new Enemy(10, 50, 10, 1.5f, 1, 3, 3, new Vector2(50, 50), "guardbot1", 50, new Vector2(50)));
            gameObjects.Add(new TurretEnemy(new Vector2(50,50), new Vector2(50,50)));
            activeGameMap = GameMap.GenerateMap();

            var rnd = new Random();
            var w = Tiles.tileSize * 15;
            var h = Tiles.tileSize * 11;
            for (int i = 0; i < 3; i++)
            {
                gameObjects.Add(new MovementSpeedPowerup(new Vector2((float)rnd.NextDouble() * w+50, (float)rnd.NextDouble() * h+50), 10));
                gameObjects.Add(new DamageBoostPowerup(new Vector2((float)rnd.NextDouble() * w+50, (float)rnd.NextDouble() * h+50), 10, 1));

            }


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

            base.Update(gameTime);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (!isPaused)
            {
                foreach (GameObject go in gameObjects)
                {
                    go.Update(gameTime);
                    if (go is ICollidable)
                    {
                        ICollidable collidable = (ICollidable)go;
                        foreach (ICollidable other in gameObjects.OfType<ICollidable>())
                        {
                            if (collidable != other && collidable.IsColliding(other))
                            {
                                collidable.DoCollision(other);
                            }
                        }
                    }
                   
                    
                }
            }

            

            foreach (GameObject go in toBeRemoved)
            {
                gameObjects.Remove(go);
            }
            toBeRemoved.Clear();

            gameObjects.AddRange(toBeAdded);
            toBeAdded.Clear();


        }


        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.BackToFront,null,null,null,null,null,Matrix.CreateTranslation(cameraPosition));
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Draw(spriteBatch);

                /*if (gameObject is ICollidable) //draws collisionbox if object is ICollidable
                {
                    DrawCollisionBox((ICollidable)gameObject);
                    
                }*/
            }

            
            
            


            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Draws ared box around all game objects. Should only be run in debug mode
        /// </summary>
        /// <param name="go">A GameObject with ICollidable implemented</param>
        private void DrawCollisionBox(ICollidable go)
        {
            Rectangle collisionBox = go.CollisionBox;
            Rectangle topLine = new Rectangle(collisionBox.X, collisionBox.Y, collisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(collisionBox.X, collisionBox.Y + collisionBox.Height, collisionBox.Width, 1);
            Rectangle rightLine = new Rectangle(collisionBox.X + collisionBox.Width, collisionBox.Y, 1, collisionBox.Height);
            Rectangle leftLine = new Rectangle(collisionBox.X, collisionBox.Y, 1, collisionBox.Height);



            spriteBatch.Draw(collisionTexture, topLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, bottomLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, rightLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, leftLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
        }
    }
}
