using System;

namespace PreparatoryCourse
{
    internal class Player
    {
        public String Name { get; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Luck { get; set; }

        public Player(string name, int health = 0, int luck = 0, int strength = 0)
        {
            this.Name = name;
            this.Health = health;
            this.Luck = luck;
            this.Strength = strength;
        }
    }
}