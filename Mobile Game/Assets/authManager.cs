using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System.Threading.Tasks;
using UnityEngine.UI;


public class authManager : MonoBehaviour
{
    public Text logTxt;

    async void start()
    {
        await UnityServices.InitializeAsync();
    }

    public async void signIn()
    {
        await signInAnonymous();
    }

    async Task signInAnonymous()
    {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();

            print("sign in successful!")
            print("Player ID:" + AuthenticationService.Instance.PlayerId);
            logTxt.text = "Player ID:" + AuthenticationService.Instance.PlayerId;
        }
        catch (AuthenticationException ex)
        {
            print("Sign in Failed!");
            Debug.LogException(ex);
        }
    }
}
