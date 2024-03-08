using System;
using Code.SharedTypes.Units;

namespace Code.ApplicationLayer.DataAccess
{
    [Serializable]
    public class UnitCustomData
    {
        [NonSerialized] private UnitAttributes customData;

        public UnitAttributes Attributes => customData;

        public UnitCustomData(UnitAttributes customData)
        {
            this.customData = customData;
        }
    }
}