using System;
using UnityEngine;

namespace Code.SharedTypes.Units
{
    [Serializable]
    public class UnitState
    {
        [SerializeField] private int health;
        [SerializeField] private int level;
        [SerializeField] private string levelol;

        public UnitState(int health, int level, string levelol)
        {
            this.health = health;
            this.level = level;
            this.levelol = levelol;
        }
    }
}