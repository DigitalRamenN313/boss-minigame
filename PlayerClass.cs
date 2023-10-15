using System;

namespace BossRushGame
{
    internal class City : IFighter
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int FirePower { get; set; }

        public City()
        {
            Name = "Consolas";
            HP = 20;
            FirePower = 2;
        }
    }
}