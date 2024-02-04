using System;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabLogin : MonoBehaviour
{
    public string nombre;
    public string password;
    
    public void Start()
    {
        Login(nombre,password);
    }

    // Llama a esta función para iniciar sesión con PlayFab
    public void Login(string username, string password)
    {
        var request = new LoginWithPlayFabRequest
        {
            Username = username,
            Password = password
        };

        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnLoginFailure);
    }

    // Función de devolución de llamada para el éxito del inicio de sesión
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Login successful!");
        // Aquí puedes realizar acciones adicionales después del inicio de sesión, como cargar datos del jugador, cambiar escenas, etc.
    }

    // Función de devolución de llamada para el fallo del inicio de sesión
    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError("Login failed: " + error.ErrorMessage);
        // Aquí puedes manejar el error de inicio de sesión de alguna manera, como mostrar un mensaje de error al jugador
    }
}