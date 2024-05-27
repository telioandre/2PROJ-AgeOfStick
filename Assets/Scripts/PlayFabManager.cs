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
    public GameObject friendListPanel;
    public GameObject friendButtonPrefab;
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
        GetFriendList();
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

    public void addFriend()
    {
        string friendName = addFriendField.text;
        var request = new GetAccountInfoRequest
        {
            TitleDisplayName = friendName
        };
        PlayFabClientAPI.GetAccountInfo(request, OnGetAccountInfoSuccess, OnGetAccountInfoFailure);
    }
    
    private void OnGetAccountInfoSuccess(GetAccountInfoResult result)
    {
        if (result.AccountInfo != null)
        {
            string friendPlayFabId = result.AccountInfo.PlayFabId;
            SendFriendRequest(friendPlayFabId);
        }
        else
        {
            Debug.LogError("AccountInfo is null");
        }
    }

    private void OnGetAccountInfoFailure(PlayFabError error)
    {
        Debug.LogError("Failed to get account info: " + error.ErrorMessage);
    }
    
    private void SendFriendRequest(string friendPlayFabId)
    {
        var request = new AddFriendRequest
        {
            FriendPlayFabId = friendPlayFabId
        };

        PlayFabClientAPI.AddFriend(request, OnAddFriendSuccess, OnAddFriendFailure);
    }

    private void OnAddFriendSuccess(AddFriendResult result)
    {
        Debug.Log("Friend request sent successfully!");
    }

    private void OnAddFriendFailure(PlayFabError error)
    {
        Debug.LogError("Failed to send friend request: " + error.ErrorMessage);
    }
    
    public void GetFriendList()
    {
        var request = new GetFriendsListRequest();

        PlayFabClientAPI.GetFriendsList(request, OnGetFriendListSuccess, OnGetFriendListFailure);
    }

    private void OnGetFriendListSuccess(GetFriendsListResult result)
    {
        Debug.Log("Nombre d'amis " + result.Friends.Count);
        for (int i = 0; i < result.Friends.Count; i++)
        {
            print(result.Friends[i].TitleDisplayName + " friendName");
            float buttonYPosition = -i * 20f + 70f;

            GameObject friendButton = Instantiate(friendButtonPrefab, friendListPanel.transform);
            RectTransform buttonTransform = friendButton.GetComponent<RectTransform>();

            buttonTransform.anchoredPosition = new Vector2(buttonTransform.anchoredPosition.x, buttonYPosition);

            TMP_Text buttonText = friendButton.GetComponentInChildren<TMP_Text>();
            if (buttonText != null)
            {
                buttonText.text = result.Friends[i].TitleDisplayName;
            }

            Button buttonComponent = friendButton.GetComponent<Button>();
            if (buttonComponent != null)
            {
                // Vous pouvez attacher une fonction à ce gestionnaire d'événements pour traiter le clic
                // Par exemple, si vous avez une fonction nommée "OnClickFriendButton", vous pouvez la lier comme ceci :
                var friend = result.Friends[i];
                buttonComponent.onClick.AddListener(() => OnClickFriendButton(friend));
            }
        }

        Debug.Log("success");
    }

    private void OnGetFriendListFailure(PlayFabError error)
    {
        Debug.LogError("Failed to get friend list: " + error.ErrorMessage);
    }

    private void OnClickFriendButton(PlayFab.ClientModels.FriendInfo friend)
    {
        print(friend.TitleDisplayName);
    }

    public void Logout()
    {
        PlayFabClientAPI.ForgetAllCredentials();
        Debug.Log("Logged out successfully!");
    }

}