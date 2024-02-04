using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public void Start()
    {
        RegisterPlayer("Manolo","87A09pQQ12");
    }

    // Start is called before the first frame update
    public void RegisterPlayer(string username, string password)
    {
        RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest
        {
            Username = username,
            Password = password,
            RequireBothUsernameAndEmail = false // Puedes establecer esto en true si deseas que los jugadores proporcionen tanto un nombre de usuario como un correo electrónico
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterFailure);
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("Registration successful!");
        // Aquí puedes realizar acciones adicionales después del registro, como iniciar sesión automáticamente, cargar datos del jugador, cambiar escenas, etc.
    }

    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.LogError("Registration failed: " + error.ErrorMessage);
        // Aquí puedes manejar el error de registro de alguna manera, como mostrar un mensaje de error al jugador
    }
}
