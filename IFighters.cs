using System;

namespace BossRushGame
{
    interface IFighter
    {
        string Name { get; set; }
        int HP { get; set; }
        int FirePower { get; set; }
    }
}