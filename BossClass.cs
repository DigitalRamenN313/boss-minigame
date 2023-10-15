using System;

namespace BossRushGame
{
    internal class Boss : IFighter
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int FirePower { get; set; }

        public Boss(string name, int hp, int firePower)
        {
            this.Name = name;
            this.HP = hp;
            this.FirePower = firePower;
        }
    }
}