using UnityEngine;

namespace Code.SharedTypes.Units
{
    public class UnitState
    {
        [SerializeField] private int health;
        [SerializeField] private int level;

        public UnitState(int health, int level)
        {
            this.health = health;
            this.level = level;
        }
    }
}