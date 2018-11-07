using System;

namespace THE_dungeon_crawler_game
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new GameWorld())
            {
                game.Run();
            }
                
        }
    }
#endif
}
