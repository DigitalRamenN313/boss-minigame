using System;
using System.Threading;

namespace BossRushGame
{
    class GameFunctions
    {
        #region Boss constructor
        /// <summary>
        /// Takes an int value to determine which Boss object will be returned.
        /// </summary>
        /// <param name="bossNum"></param>
        /// <returns>Boss object value</returns>
        internal static Boss DeployNextBoss(int bossNum)
        {
            Boss currentBoss = new Boss("", 0, 0);

            if(bossNum == 0)
            {
                currentBoss.Name = "The Goblin";
                currentBoss.HP = 6;
                currentBoss.FirePower = 2;
            }
            else if(bossNum == 1)
            {
                currentBoss.Name = "The Manticore";
                currentBoss.HP = 10;
                currentBoss.FirePower = 4;
            }
            else
            {
                currentBoss.Name = "The Wyvern";
                currentBoss.HP = 20;
                currentBoss.FirePower = 10;
            }

            return currentBoss;
        }
        #endregion

        #region Combat logic
        /// <summary>
        /// The method main focus is the battle squence which takes the user input as a guess of the enemy choosen position
        /// which is set in a semi-random way using the Random class.
        /// </summary>
        /// <returns>(Tuple) bool, int values</returns>
        internal static (bool hit, int hitDistance) CombatSequence()
        {
            bool wasSuccessful = false; // Determines if player was successful or not
            int shootDistance = 0; // Depending on the enemy position, determines the damage multiplier 

            int playerInput = 0;
            int shoots = 3; // Tracks the number of tries the player has to correctly guess the enemy position
            int firstShot = 0; // Tracks and displays the player first attempt
            int secondShot = 0; // Tracks and displays the player second attempt
            int[] battlefield = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}; // Contains the posible positions the enemy could take

            Random enemyPosition = new Random();
            
            int enemyPositionIndex = battlefield[enemyPosition.Next(0, battlefield.Length)]; // Generate a random index within the bounds of the battlefield array

            while(shoots > 0)
            {
                Console.WriteLine($"TEST: {enemyPositionIndex}"); // Test only, remove after
                Console.WriteLine($"\n[   Previous choices: -{firstShot} | -{secondShot} |  remaining shots: {shoots}   ]");
                Console.WriteLine($"=======================================================");
                Console.WriteLine("\nCommander the enemy is getting ready to attack, please choose a position from 1 to 10 ╭(°ﾛ° ”)╯");
                Console.Write("Shoot at position: ");
                bool isValid = int.TryParse(Console.ReadLine(), out playerInput);

                if(!isValid || playerInput < 1 || playerInput > 10)
                {
                    Console.WriteLine("\nInvalid input. You must enter an integer between 1 and 10.");
                    Console.WriteLine("\nPress ENTER to go back to input screen.");
                    Console.ReadKey();
                }
                else if(playerInput != enemyPositionIndex)
                {
                    --shoots;
                    Console.WriteLine("\nCommander it was a miss.... o(〒﹏〒)o\n");

                    if(playerInput < enemyPositionIndex)
                    {
                        Console.WriteLine("It seems the shot was to short on distance, we must aim a little further.");
                    }
                    else if(playerInput > enemyPositionIndex)
                    {
                        Console.WriteLine("It seems the shot was to far, we must aim a little less far.");
                    }

                    Thread.Sleep(2000);
                }
                else // Successful hit
                {
                    wasSuccessful = true;
                    Console.WriteLine("\nCommander it was a successful hit! ╭( ･ㅂ･)و\n");
                    Thread.Sleep(2000);
                    break;
                }

                if(shoots == 2)
                {
                    firstShot = playerInput;
                }
                else if(shoots == 1)
                {
                    secondShot = playerInput;
                }

                Console.Clear();
            }

            return (wasSuccessful, shootDistance);
        }
        #endregion

        #region Damage calculator
        /// <summary>
        /// Takes 2 int values as arguments, one for fire power and one for the current position.
        /// Position 3 or lower adds plus 2 to its base power, position 8 or higher subtract minus 2 to base power.
        /// </summary>
        /// <param name="basePower"></param>
        /// <param name="currentPosition"></param>
        /// <returns>int value</returns>
        internal static int DamageCalculator(int basePower, int currentPosition)
        {
            int distanceMultiplier = 0;

            if(currentPosition <= 3)
            {
                return distanceMultiplier = basePower + 2;
            }
            else if(currentPosition >= 8)
            {
                return distanceMultiplier = basePower - 2;
            }
            else
            {
                return basePower;
            }
        }
        #endregion
    }
}