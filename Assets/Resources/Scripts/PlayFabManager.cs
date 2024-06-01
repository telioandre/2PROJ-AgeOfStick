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
    public TextMeshProUGUI usernameText;
    public TMP_InputField  addFriendField;
    public GameObject friendList;
    public GameObject friendButtonPrefab;
    public TextMeshProUGUI victoryCountText;
    public GameObject loginMenu;

    public GameObject registerMenu;

    public GameObject mainMenu;

	public PhotonChatManager photonChatManager;
	private string _name;
    
    private string _playFabId;

    /*
     * This method start the log in process.
     */
    public void OnLoginButtonClicked()
    {
        string username = usernameLoginInput.text;
        string password = passwordLoginInput.text;
        usernameLoginInput.text = "";
        passwordLoginInput.text = "";
        Login(username, password);
        }
    
    /*
     * This method start the register process.
    */
    public void OnRegisterButtonClicked()
    {
        string username = usernameRegisterInput.text;
        string password = passwordRegisterInput.text;
        usernameRegisterInput.text = "";
        passwordRegisterInput.text = "";
        Register(username, password);
    }
    
    /*
     * This method permits the user to log in to his PlayFab account.
     */
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

    /*
     * This method permits the user to register a new PlayFab account, then redirect to the login page. 
     */
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

    /*
     * This method is called when the user is log, it changes the active elements in the scene.
     */
    private void OnLoginSuccess(LoginResult result)
    {
        _name = result.InfoResultPayload.PlayerProfile.DisplayName;
        loginMenu.SetActive(false);
        registerMenu.SetActive(false);
        usernameText.text = _name;
        mainMenu.SetActive(true);
        GetFriendList();
        _playFabId = result.PlayFabId;
        GetCurrentVictoryCount();
    }

    /*
     * Getter for the username of the current user.
     */
    public string GetName()
    {
        return _name;
    }
    
    /*
     * Getter for the id of the current user.
     */
    public string GetPlayFabId()
    {
        return _playFabId;
    }
    
    /*
     * Method to get the Victories statistic of the current user and start the display.
     */
    public void GetCurrentVictoryCount()
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = "Victories",
            PlayFabId = _playFabId,
            MaxResultsCount = 1
        };

        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnLeaderboardSuccess, OnLeaderboardFailure);
    }
    
    /*
     * Method to display the statistic.
     */
    private void OnLeaderboardSuccess(GetLeaderboardAroundPlayerResult result)
    {
        int currentVictoryCount = 0;

        if (result.Leaderboard.Count > 0)
        {
            currentVictoryCount = result.Leaderboard[0].StatValue;
        }

        victoryCountText.text = "" + currentVictoryCount;
    }
    
    /*
     * Method to get the Victories statistic of the current user and update it.
     */
    public void PostNewVictoryCount()
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = "Victories",
            PlayFabId = _playFabId,
            MaxResultsCount = 1
        };

        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnLeaderboardPostSuccess, OnLeaderboardFailure);
    }
    
    /*
     * Method to update the statistic.
     */
    private void OnLeaderboardPostSuccess(GetLeaderboardAroundPlayerResult result)
    {
        int currentVictoryCount = 0;

        if (result.Leaderboard.Count > 0)
        {
            currentVictoryCount = result.Leaderboard[0].StatValue;
        }

        UpdateVictoryCount(currentVictoryCount + 1);
    }
    
    /*
     * This method update the statistic on PlayFab.
     */
    private void UpdateVictoryCount(int newVictoryCount)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new()
                {
                    StatisticName = "Victories",
                    Value = newVictoryCount
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnUpdateStatisticsSuccess, OnUpdateStatisticsFailure);
    }
    
    /*
     * Logs a message when the player statistics are updated successfully
     */
    private void OnUpdateStatisticsSuccess(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Victory count updated successfully.");
    }
    
    /*
     * Logs an error message when updating player statistics fails.
     */
    private void OnUpdateStatisticsFailure(PlayFabError error)
    {
        Debug.LogError("Failed to update victory count: " + error.ErrorMessage);
    }

    /*
     * Logs an error message when posting the score to the leaderboard fails
     */
    private void OnLeaderboardFailure(PlayFabError error)
    {
        Debug.LogError("Failed to post score" + error.ErrorMessage);
    }
    
    /*
     * Logs an error message when login fails.
     */
    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError("Login failed: " + error.ErrorMessage);
    }

    /*
     * Logs a message when registration is successful.
     */
    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("Registered successfully!");
    }

    /*
     * Logs an error message when registration fails.
     */
    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.LogError("Registration failed: " + error.ErrorMessage);
    }

    /*
     * Method to get a user in PlayFab based on his name.
     */
    public void AddFriend()
    {
        string friendName = addFriendField.text;
        var request = new GetAccountInfoRequest
        {
            TitleDisplayName = friendName
        };
        PlayFabClientAPI.GetAccountInfo(request, OnGetAccountInfoSuccess, OnGetAccountInfoFailure);
    }
    
    /*
     * Method to get the id of the user found.
     */
    private void OnGetAccountInfoSuccess(GetAccountInfoResult result)
    {
        if (result.AccountInfo != null)
        {
            string friendPlayFabId = result.AccountInfo.PlayFabId;
            SendFriendRequest(friendPlayFabId);
        }
    }

    /*
     * Logs an error message when retrieving account information fails.
     */
    private void OnGetAccountInfoFailure(PlayFabError error)
    {
        Debug.LogError("Failed to get account info: " + error.ErrorMessage);
    }
    
    /*
     * Method to add as friend the user.
     */
    private void SendFriendRequest(string friendPlayFabId)
    {
        var request = new AddFriendRequest
        {
            FriendPlayFabId = friendPlayFabId
        };

        PlayFabClientAPI.AddFriend(request, OnAddFriendSuccess, OnAddFriendFailure);
    }

    /*
     * Method to reset the field when the friend is added.
     */
    private void OnAddFriendSuccess(AddFriendResult result)
    {
        addFriendField.text = "";
        ClearFriendButtons();
        GetFriendList();
    }

    /*
     * Logs an error message when sending a friend request fails.
     */
    private void OnAddFriendFailure(PlayFabError error)
    {
        Debug.LogError("Failed to send friend request: " + error.ErrorMessage);
    }
    
    /*
     * Method to get the friend list of the current user.
     */
    public void GetFriendList()
    {
        var request = new GetFriendsListRequest();

        PlayFabClientAPI.GetFriendsList(request, OnGetFriendListSuccess, OnGetFriendListFailure);
    }

    /*
     * Method to display every friend found and attach a listener to every button created.
     */
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
                buttonComponent.onClick.AddListener(() => photonChatManager.ChatConnectOnClick(_name, friendName));
            }
        }
    }
    
    /*
     * Method to clear the display when a new friend is added or when the current user change.
     */
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

    /*
     * Logs an error message when retrieving the friend list fails.
     */
    private void OnGetFriendListFailure(PlayFabError error)
    {
        Debug.LogError("Failed to get friend list: " + error.ErrorMessage);
    }

    /*
     * This method is used to disconnect from PlayFab.
     */
    public void Logout()
    {
        PlayFabClientAPI.ForgetAllCredentials();
        Debug.Log("Logged out successfully!");
    }

}