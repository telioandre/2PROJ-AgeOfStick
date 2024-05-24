using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;

public class PlayFabManager : MonoBehaviour
{
    public TMP_InputField  usernameLoginInput;
    public TMP_InputField  passwordLoginInput;
    public TMP_InputField  usernameRegisterInput;
    public TMP_InputField  passwordRegisterInput;
    public TMP_InputField  addFriendField;

    public GameObject loginMenu;

    public GameObject registerMenu;

    public GameObject mainMenu;

    // Méthode appelée lorsque l'utilisateur appuie sur le bouton de connexion
    public void OnLoginButtonClicked()
    {
        string username = usernameLoginInput.text;
        string password = passwordLoginInput.text;
        Login(username, password);
    }

    // Méthode appelée lorsque l'utilisateur appuie sur le bouton d'enregistrement
    public void OnRegisterButtonClicked()
    {
        string username = usernameRegisterInput.text;
        string password = passwordRegisterInput.text;
        Register(username, password);
    }
    // Méthode pour se connecter à un compte PlayFab
    public void Login(string username, string password)
    {
        var request = new LoginWithPlayFabRequest
        {
            Username = username,
            Password = password,

            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };


        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnLoginFailure);
    }

    // Méthode pour s'enregistrer avec un nouveau compte PlayFab
    private void Register(string username, string password)
    {
        var request = new RegisterPlayFabUserRequest
        {
            Password = password,
            Username = username,
            DisplayName = username,
            RequireBothUsernameAndEmail = false
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterFailure);
        Login(username, password);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Logged in successfully!");
        string name = null;
        name = result.InfoResultPayload.PlayerProfile.DisplayName;
        Debug.Log(name);
        loginMenu.SetActive(false);
        registerMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError("Login failed: " + error.ErrorMessage);
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("Registered successfully!");
    }

    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.LogError("Registration failed: " + error.ErrorMessage);
    }

    private void addFriend()
    {
        string friendName = addFriendField.text;
        var request = new GetAccountInfoRequest
    }
}