using Code.ApplicationLayer.Services.Server.Dtos;
using Code.Domain.Entities;
using UnityEngine;

namespace Code.ApplicationLayer.DataAccess
{
    public static class UnitMapper
    {
        public static Unit ParseUnits(CatalogItemDto unitDto)
        {
            return ParseUnit(unitDto);
        }

        private static Unit ParseUnit(CatalogItemDto unitDto)
        {
            Debug.Log($"Parsing unit: {unitDto.ID}");
            var unitCustomData = unitDto.GetCustomData<UnitCustomData>();
            var unit = new Unit(unitDto.ID,unitDto.DisplayName,unitCustomData.Attributes.Attack,unitCustomData.Attributes.Health);
            return unit;
        }
    }
}