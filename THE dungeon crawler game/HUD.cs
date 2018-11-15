using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace THE_dungeon_crawler_game
{
    /// <summary>
    /// A object displaying all the HUD elements
    /// </summary>
    public class HUD : GameObject
    {
        /// <summary>
        /// Constructor for displaying remaining Health.
        /// </summary>
        public HUD() : base("HealthHeart", Vector2.Zero)
        {

        }


        public void DrawPowerups(SpriteBatch spriteBatch)
        {
            StringBuilder powerUpsDrawer = new StringBuilder();
            SpriteFont hudFont = GameWorld.ContentManager.Load<SpriteFont>("HUDFont");
            foreach (PowerUp powerUp in GameWorld.Player.activePowerups)
            {
                powerUpsDrawer.Append($"{powerUp.ShortName}+{powerUp.PowerupValue, 3}:{powerUp.duration:0.0}\n");
            }
            spriteBatch.DrawString(hudFont, powerUpsDrawer, new Vector2(0, 32), Color.White);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            DrawHealth(spriteBatch);
            DrawPowerups(spriteBatch);

        }

        private void DrawHealth(SpriteBatch spriteBatch)
        {
            //For every 2 Hp, draw 1 whole heart.
            //If there amount is odd, we draw 1 final half heart.
            int wholeHearts = GameWorld.Player.Health / 2;
            for (int i = 0; i < wholeHearts; i++)
            {
                spriteBatch.Draw(sprite, new Rectangle(i * 16, 0, 32, 32), Color.White);


            }
            if (GameWorld.Player.Health % 2 == 1)
            {
                spriteBatch.Draw(sprite, new Rectangle(wholeHearts * 16, 0, 16, 32), new Rectangle(0, 0, sprite.Width / 2, sprite.Height), Color.White);
            }
        }
    }
}
