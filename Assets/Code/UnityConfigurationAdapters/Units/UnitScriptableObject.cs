using System;
using System.Collections.Generic;
using System.Linq;
using Code.ApplicationLayer.DataAccess;
using NaughtyAttributes;
using PlayFab;
using PlayFab.AdminModels;
using UnityEngine;

namespace Code.UnityConfigurationAdapters.Units
{
    [CreateAssetMenu(menuName = "Milenur/Units/New Unit", fileName = "UnitScriptableObject")]
    public class UnitScriptableObject : ScriptableObject //Esto esta al margen, no ahi que ser purista, es una tool de desarrollo
    {
        [SerializeField] private string _id;
        [SerializeField] private string _name;
        [SerializeField] private int _attack;
        [SerializeField] private int _health;

        [Button("Guardar en el Servidor")]
        public void SaveOnServer()
        {
            var request = new UpdateCatalogItemsRequest()
            {
                Catalog = new List<CatalogItem>()
                {
                    new CatalogItem()
                    {
                        ItemId = _id,
                        DisplayName = _name,
                        CustomData = JsonUtility.ToJson(new UnitsCustomData(_health, _attack))
                    }
                },
                CatalogVersion = "Units",
            };
            PlayFabAdminAPI.UpdateCatalogItems(request, resultCallback => { Debug.Log("Saved"); }, error => throw new Exception(error.ErrorMessage));
        }

        [Button("Cargar del Server")]
        public void LoadFromServer()
        {
            var request = new GetCatalogItemsRequest()
            {
                CatalogVersion = "Units"
            };
            PlayFabAdminAPI.GetCatalogItems(request, result =>
            {
                var catalogItem = result.Catalog.FirstOrDefault(item => item.ItemId.Equals(_id));
                if (catalogItem == null)
                {
                    throw new Exception("No existe");
                }

                _name = catalogItem.DisplayName;
                var customData = JsonUtility.FromJson<UnitsCustomData>(catalogItem.CustomData);
                _attack = customData.Attack;
                _health = customData.Health;

                Debug.Log($"{_id} Cargado");
                UnityEditor.EditorUtility.SetDirty(this);
                UnityEditor.AssetDatabase.SaveAssets();
                UnityEditor.AssetDatabase.Refresh();
            }, error => throw new Exception(error.ErrorMessage));
        }
    }
}