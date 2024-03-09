using System;
using Code.SharedTypes.Units;
using UnityEngine;

namespace Code.ApplicationLayer.DataAccess
{
    [Serializable]
    public class UnitCustomData
    {
        [SerializeField] private UnitAttributes customData;

        public UnitAttributes Attributes => customData;

        public UnitCustomData(UnitAttributes customData)
        {
            this.customData = customData;
        }
    }
}