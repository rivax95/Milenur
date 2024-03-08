namespace Code.Domain.Entities
{
    public class Unit
    {
        public readonly string ID;
        public readonly string Name;
        public readonly int Attack;
        public readonly int Health;

        public Unit(string id, string name, int attack, int health)
        {
            ID = id;
            Name = name;
            Attack = attack;
            Health = health;
        }
    }
}