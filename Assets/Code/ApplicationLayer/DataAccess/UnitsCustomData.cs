using System;

namespace Code.ApplicationLayer.DataAccess
{
    [Serializable]
    public class UnitsCustomData
    {
        public int Health;
        public int Attack;

        public UnitsCustomData(int health, int attack)
        {
            Health = health;
            Attack = attack;
        }
    }
}