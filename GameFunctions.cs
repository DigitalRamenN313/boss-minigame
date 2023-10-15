using System;
using System.Threading;

namespace BossRushGame
{
    class GameVisuals
    {
        #region Title screen
        /// <summary>
        /// Show the game title to the player.
        /// </summary>
        internal static void Introduction()
        {
            Console.WriteLine(@"
               ###   #                 ###           #                            
                #    #                 #  #         # #                           
                #    ###    ##         #  #   ##    #     ##   ###    ###    ##   
                #    #  #  # ##        #  #  # ##  ###   # ##  #  #  ##     # ##  
                #    #  #  ##          #  #  ##     #    ##    #  #    ##   ##    
                #    #  #   ##         ###    ##    #     ##   #  #  ###     ##   
                                                                   
                                                              #   
                                                             # #  
                                                       ##    #    
                                                      #  #  ###   
                                                      #  #   #    
                                                       ##    #    
                                                                  
                                                       ##                            ##                 
                                                      #  #                            #                 
                                                      #      ##   ###    ###    ##    #     ###   ###   
                                                      #     #  #  #  #  ##     #  #   #    #  #  ##     
                                                      #  #  #  #  #  #    ##   #  #   #    # ##    ##   
                                                       ##    ##   #  #  ###     ##   ###    # #  ###    
                                                                                                       
            ");
            Thread.Sleep(800);
            Console.WriteLine("                                                       by Digital RameN\n");
            Thread.Sleep(1000);
            Console.WriteLine("                                     Press ENTER");
            Console.ReadKey();
            Console.Clear();
        }
        #endregion

        #region Game instructions
        /// <summary>
        /// It's only purpose is to show the basic instructions for the game to the player.
        /// </summary>
        internal static void GameInstructions()
        {
            Console.WriteLine("Welcome to the game: \"The Defense of Consolas\"\n\n");
            Thread.Sleep(800);
            Console.WriteLine("This game is a programming challenge from the book: C# Player's Guide by RB Withaker\n");
            Console.WriteLine("In the challenge we are tasked with creating a game where the player takes the role of the defender of the city");
            Console.WriteLine("from the enemy airship \"The Manticore\" which will attack the player each turn, the player must try to guess the position");
            Console.WriteLine("of the enemy which changes each new turn\n");
            Console.WriteLine("- If the player correctly guess the enemy position, then the airship will take damage else the city takes damage.");
            Console.WriteLine("\n- The player has to defeat 3 bosses, each boss more powerful than the previous one.");
            Console.WriteLine("\n- For every boss defeated the player receives a buff to its HP and Power.");
            Console.WriteLine("\n- On every turn the player has 3 chances to guess the current position of the enemy before it changes to a new position.\n");
            Thread.Sleep(1500);
            Console.WriteLine("Press ENTER to start game");
            Console.ReadKey();
            Console.Clear();
        }
        #endregion

        #region Player and Boss status screen
        /// <summary>
        /// Displays current stats for player and boss, and which boss if currently fighting.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="currentBoss"></param>
        /// <param name="bossCount"></param>
        internal static void DisplayGameStatus(City player, Boss currentBoss, int bossCount)
        {
            Console.Clear();
            Console.WriteLine($"Boss: {bossCount + 1} / 3            [{currentBoss.Name}]                   ");
            Console.WriteLine("==========================================================");
            Console.WriteLine($"PlayerHP: {player.HP} Power: {player.FirePower}        ||       BossHP: {currentBoss.HP} Power: {currentBoss.FirePower}");
            Console.WriteLine("==========================================================\n");
            Map();
        }
        #endregion

        #region Map
        /// <summary>
        /// It's only purpose is to display a map as a visual reference for the player. 
        /// </summary>
        internal static void Map()
        {
            Console.WriteLine(@"
                                
                            ┌──────────────────────────────────────────────────────────────────────────────────────────────────────┐
                            │                                                                                                      │
                            │  ┌────────────────────────────────────────────────────────────────────────────────────────────────┐  │
                            │  │                                                                                                │  │
                            │  │                                          Map                                                   │  │
                            │  │                                                                                                │  │
                            │  │                                                                                                │  │
                            │  │                                                                                                │  │
                            │  │                                                                                                │  │
                            │  │                                                                                                │  │
                            │  │                                                                                                │  │
                            │  │   ┌──────────┐     │      │      │      │      │      │      │      │      │      │            │  │
                            │  │   │          │     │      │      │      │      │      │      │      │      │      │            │  │
                            │  │   │          │     │      │      │      │      │      │      │      │      │      │            │  │
                            │  │   │          ├─────┼──────┼──────┼──────┼──────┼──────┼──────┼──────┼──────┼──────┤            │  │
                            │  │   │   City   │     │      │      │      │      │      │      │      │      │      │            │  │
                            │  │   │          │     │      │      │      │      │      │      │      │      │      │            │  │
                            │  │   │          │     ▼      ▼      ▼      ▼      ▼      ▼      ▼      ▼      ▼      ▼            │  │
                            │  │   └──────────┘     1      2      3      4      5      6      7      8      9      10           │  │
                            │  │                                                                                                │  │
                            │  │                                                                                                │  │
                            │  │                                                                                                │  │
                            │  │                                                                                                │  │
                            │  │                                                                                                │  │
                            │  └────────────────────────────────────────────────────────────────────────────────────────────────┘  │
                            │                                                                                                      │
                            └──────────────────────────────────────────────────────────────────────────────────────────────────────┘

                            ");
        }
        #endregion

        #region Game Over screen
        /// <summary>
        /// Displays the game over screen for the player
        /// </summary>
        internal static void GameOver()
        {
            Console.Clear();

            Console.WriteLine("\nCommander we lost the battle...the city has fallen (⋟﹏⋞)\n");
            Console.WriteLine(@"
                                      _____          __  __ ______           ______      ________ _____  
                                     / ____|   /\   |  \/  |  ____|         / __ \ \    / /  ____|  __ \ 
                                    | |  __   /  \  | \  / | |__           | |  | \ \  / /| |__  | |__) |
                                    | | |_ | / /\ \ | |\/| |  __|          | |  | |\ \/ / |  __| |  _  / 
                                    | |__| |/ ____ \| |  | | |____         | |__| | \  /  | |____| | \ \ 
                                     \_____/_/    \_\_|  |_|______|         \____/   \/   |______|_|  \_\
                                ");
            
            Thread.Sleep(2000);
        }
        #endregion

        #region Rank display
        /// <summary>
        /// Displays the Rank the achieved depending on the number of enemies defeated by the player. 
        /// </summary>
        /// <param name="bossNum"></param>
        internal static void PlayerRank(int bossNum)
        {
            Console.Clear();

            switch(bossNum)
            {
                case 0: 
                    Console.WriteLine($"\nYou defeated: {bossNum} bosses\n");
                    Console.WriteLine("Your Rank is: ");
                    Console.WriteLine(@"
                                        _      ____  ____  ____ 
                                       / \  /|/  _ \/  _ \/  _ \
                                       | |\ ||| / \|| / \|| | //
                                       | | \||| \_/|| \_/|| |_\\
                                       \_/  \|\____/\____/\____/
                         
                        ");
                    break;
                
                case 1:
                    Console.WriteLine($"\nYou defeated: {bossNum} bosses\n");
                    Console.WriteLine("Your Rank is: ");
                    Console.WriteLine(@"
                                        ____  _____ _____ _____ _      ____  _____ ____ 
                                       /  _ \/  __//    //  __// \  /|/  _ \/  __//  __\
                                       | | \||  \  |  __\|  \  | |\ ||| | \||  \  |  \/|
                                       | |_/||  /_ | |   |  /_ | | \||| |_/||  /_ |    /
                                       \____/\____\\_/   \____\\_/  \|\____/\____\\_/\_\
                                                 ");
                    break;
                
                case 2:
                    Console.WriteLine($"\nYou defeated: {bossNum} bosses\n");
                    Console.WriteLine("Your Rank is: ");
                    Console.WriteLine(@"
                                        _     _____ ____  ____ 
                                       / \ /|/  __//  __\/  _ \
                                       | |_|||  \  |  \/|| / \|
                                       | | |||  /_ |    /| \_/|
                                       \_/ \|\____\\_/\_\\____/
                                                ");
                    break;
                
                case 3:
                    Console.WriteLine($"\nYou defeated: {bossNum} bosses\n");
                    Console.WriteLine("Your Rank is: ");
                    Console.WriteLine(@" 
                                         _     _  _     _  _      _____     _     _____ _____ _____ _      ____ 
                                        / \   / \/ \ |\/ \/ \  /|/  __/    / \   /  __//  __//  __// \  /|/  _ \
                                        | |   | || | //| || |\ ||| |  _    | |   |  \  | |  _|  \  | |\ ||| | \|
                                        | |_/\| || \// | || | \||| |_//    | |_/\|  /_ | |_//|  /_ | | \||| |_/|
                                        \____/\_/\__/  \_/\_/  \|\____\    \____/\____\\____\\____\\_/  \|\____/
                                                                        ");
                    break;
            }

            Console.WriteLine("\nThank you for playing! (＾▽＾)\n");
        }
        #endregion
    }
}