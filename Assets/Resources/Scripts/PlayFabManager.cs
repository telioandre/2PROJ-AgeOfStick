using System.Collections.Generic;
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
    public GameObject friendList;
    public GameObject friendButtonPrefab;
    public TextMeshProUGUI victoryCountText;
    public GameObject loginMenu;

    public GameObject registerMenu;

    public GameObject mainMenu;

	public PhotonChatManager photonChatManager;
	private string _name;
    
    private string _playFabId;

    // Méthode appelée lorsque l'utilisateur appuie sur le bouton de connexion
    public void OnLoginButtonClicked()
    {
        string username = usernameLoginInput.text;
        string password = passwordLoginInput.text;
        usernameLoginInput.text = "";
        passwordLoginInput.text = "";
        Login(username, password);
    }

    // Méthode appelée lorsque l'utilisateur appuie sur le bouton d'enregistrement
    public void OnRegisterButtonClicked()
    {
        string username = usernameRegisterInput.text;
        string password = passwordRegisterInput.text;
        usernameRegisterInput.text = "";
        passwordRegisterInput.text = "";
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
		registerMenu.SetActive(false);
		loginMenu.SetActive(true);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        //Debug.Log("Logged in successfully!");
        _name = result.InfoResultPayload.PlayerProfile.DisplayName;
        loginMenu.SetActive(false);
        registerMenu.SetActive(false);
        mainMenu.SetActive(true);
        GetFriendList();
        _playFabId = result.PlayFabId;
        GetCurrentVictoryCount(_playFabId);
    }

    public string GetName()
    {
        return _name;
    }
    public string GetPlayFabId()
    {
        return _playFabId;
    }
    
    public void GetCurrentVictoryCount(string playFabId)
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = "Victories",
            PlayFabId = playFabId,
            MaxResultsCount = 1
        };

        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnLeaderboardSuccess, OnLeaderboardFailure);
    }
    
    private void OnLeaderboardSuccess(GetLeaderboardAroundPlayerResult result)
    {
        int currentVictoryCount = 0;

        if (result.Leaderboard.Count > 0)
        {
            currentVictoryCount = result.Leaderboard[0].StatValue;
        }

        victoryCountText.text = "" + currentVictoryCount;
    }
    
    public void PostNewVictoryCount(string playFabId)
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = "Victories",
            PlayFabId = playFabId,
            MaxResultsCount = 1
        };

        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, result => OnLeaderboardPostSuccess(result, playFabId), OnLeaderboardFailure);
    }
    
    private void OnLeaderboardPostSuccess(GetLeaderboardAroundPlayerResult result, string playFabId)
    {
        int currentVictoryCount = 0;

        if (result.Leaderboard.Count > 0)
        {
            currentVictoryCount = result.Leaderboard[0].StatValue;
        }

        UpdateVictoryCount(playFabId, currentVictoryCount + 1);
    }
    
    private void UpdateVictoryCount(string playFabId, int newVictoryCount)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Victories",
                    Value = newVictoryCount
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnUpdateStatisticsSuccess, OnUpdateStatisticsFailure);
    }
    
    private void OnUpdateStatisticsSuccess(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Victory count updated successfully.");
    }

    private void OnUpdateStatisticsFailure(PlayFabError error)
    {
        Debug.LogError("Failed to update victory count: " + error.ErrorMessage);
    }

    private void OnLeaderboardFailure(PlayFabError error)
    {
        Debug.LogError("Failed to post score" + error.ErrorMessage);
    }
    
    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError("Login failed: " + error.ErrorMessage);
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        //Debug.Log("Registered successfully!");
    }

    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.LogError("Registration failed: " + error.ErrorMessage);
    }

    public void AddFriend()
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
        addFriendField.text = "";
        ClearFriendButtons();
        GetFriendList();
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
        for (int i = 0; i < result.Friends.Count; i++)
        {
            float buttonYPosition = -i * 20f + 70f;

            GameObject friendButton = Instantiate(friendButtonPrefab, friendList.transform);
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
                var friend = result.Friends[i];
				string friendName = friend.TitleDisplayName;
                buttonComponent.onClick.AddListener(() => photonChatManager.ChatConnectOnClick(name, friendName));
            }
        }

        //Debug.Log("success");
    }
    
    public void ClearFriendButtons()
    {
        foreach (Transform child in friendList.transform)
        {
            if (child.gameObject != friendButtonPrefab)
            {
                Destroy(child.gameObject);
            }
        }
    }

    private void OnGetFriendListFailure(PlayFabError error)
    {
        Debug.LogError("Failed to get friend list: " + error.ErrorMessage);
    }

    public void Logout()
    {
        PlayFabClientAPI.ForgetAllCredentials();
        Debug.Log("Logged out successfully!");
    }

}