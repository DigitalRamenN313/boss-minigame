using System;
using System.Threading;

/**
* @author  Alejandro Morales aka Digital RameN
* @version 1.0 2023/10/15
*/
namespace BossRushGame
{
    class Program
    {  
        static void Main(string[] args)
        {
            int bossNum = 0; // Keeps track of which boss is currently active
            bool playerAlive = true; // track player status

            GameVisuals.Introduction();
            GameVisuals.GameInstructions();

            Console.WriteLine("\nComander the enemy airship is approaching! (;° ロ°)");
            Console.WriteLine("We must defend the city! (ง •̀_•́)ง\n");
            Console.WriteLine("...");
            Thread.Sleep(2000);

            City player = new City(); // Player object is initialized

            while(bossNum < 3 && playerAlive) // Outer main loop
            {
                if(bossNum > 0) // Each time a boss is defeated, the player receives a buff 
                {
                    player.HP += 5;
                    player.FirePower += 1;
                }

                var currentBoss = GameFunctions.DeployNextBoss(bossNum); 

                while(true) // Go back to outer loop by defeating a boss or if player hp goes down to 0 
                {
                    GameVisuals.DisplayGameStatus(player, currentBoss, bossNum);
                    var battleResult = GameFunctions.CombatSequence();

                    if(!battleResult.hit)
                    {
                        var damage = GameFunctions.DamageCalculator(currentBoss.FirePower, battleResult.hitDistance);
                        player.HP -= damage;
                    }
                    else
                    {
                        var damage = GameFunctions.DamageCalculator(player.FirePower, battleResult.hitDistance);
                        currentBoss.HP -= damage;
                    }

                    if(currentBoss.HP <= 0)
                    {
                        bossNum++;
                        break;
                    }
                    else if(player.HP <= 0)
                    {
                        playerAlive = false;
                        break;
                    }
                }

                if(!playerAlive)
                {
                    GameVisuals.GameOver();
                    break;
                }
            }

            GameVisuals.PlayerRank(bossNum);
        }
    }
}