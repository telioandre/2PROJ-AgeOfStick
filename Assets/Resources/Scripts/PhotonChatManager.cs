using System;
using Photon.Chat;
using ExitGames.Client.Photon;
using UnityEngine;
using TMPro;

public class PhotonChatManager : MonoBehaviour, IChatClientListener
{
    private ChatClient _chatClient;
	private bool _isOnline;
	private string _currentRoom;
	public GameObject chatPanel;
	public TMP_InputField  chatText;
	public TextMeshProUGUI chatsText;

	/*
	 * This start method will start a new ChatClient.
	 */
	void Start()
	{
    	_chatClient = new ChatClient(this);
	}

	/*
	 * This update is used to keep the connexion with the Photon server and see any change in it when the user is connected.
	 */
	void Update()
	{
		if(_isOnline)
		{
			_chatClient.Service();
		}
	}

	/*
	 * This method is used to connect the user to Photon.
	 */
	public void ChatConnectOnClick(string username, string friendName)
	{
		if (!_isOnline)
    	{
			_currentRoom = String.CompareOrdinal(username, friendName) < 0 ? username + friendName : friendName + username;
			_isOnline = true;
    		_chatClient.Connect("75f6333c-07e6-4dd5-b40a-b5d42c5d2b4d", "version2", new Photon.Chat.AuthenticationValues());
		}
	}

	/*
	 * When connected, this method create a unique room with the friend selected by the user.
	 */
	public void OnConnected(){
    	if (_chatClient.State == ChatState.ConnectedToFrontEnd)
    	{
			chatPanel.SetActive(true);
        	_chatClient.Subscribe(new string[] { _currentRoom });
    	}
	}

	/*
	 * This method is used to disconnect the user.
	 */
	public void Close()
	{
        _chatClient.Disconnect();
		chatPanel.SetActive(false);
	}
	
	/*
	 * Method to disconnect properly the user?
	 */
	public void OnDisconnected()
	{
		_isOnline = false;
	}
	
	/*
	 * This method will send the user's message to the private room.
	 */
	public void SendMessages()
	{
		string message = chatText.text;
		chatText.text = "";	
		if(message != "")
		{
			_chatClient.PublishMessage(_currentRoom, message);
		}	
	}

	/*
	 * This method will display every message send to the private room.
	 */
	public void OnGetMessages(string channelName, string[] senders, object[] messages)
	{
		for (int i = 0; i < senders.Length; i++)
		{
			chatsText.text += $"\n{messages[i]}";
		}
	}
	
	/*
	 * Logs a debug message with the specified debug level.
	 */
    public void DebugReturn(DebugLevel level, string message)
    {
        Debug.Log($"DebugReturn: {level} - {message}");
    }

    /*
     * Logs the new chat state when it changes.
     */
    public void OnChatStateChange(ChatState state)
    {
        Debug.Log($"OnChatStateChange: {state}");
    }

    /*
     * Logs a received private message.
     */
    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        Debug.Log($"Private message from {sender} in {channelName}: {message}");
    }

    /*
     * Logs the channels that have been successfully subscribed to
     */
    public void OnSubscribed(string[] channels, bool[] results)
    {
        foreach (string channel in channels)
        {
            Debug.Log($"Subscribed to channel: {channel}");
        }
    }

    /*
     * Logs the channels that have been unsubscribed from.
     */
    public void OnUnsubscribed(string[] channels)
    {
        foreach (string channel in channels)
        {
            Debug.Log($"Unsubscribed from channel: {channel}");
        }
    }

    /*
     * Logs a status update for a specific user.
     */
    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        Debug.Log($"Status update for {user}: {status} - {message}");
    }

    /*
     * Logs when a user subscribes to a channel.
     */
    public void OnUserSubscribed(string channel, string user)
    {
        Debug.Log($"User {user} subscribed to channel {channel}");
    }

    /*
     * Logs when a user unsubscribes from a channel.
     */
    public void OnUserUnsubscribed(string channel, string user)
    {
        Debug.Log($"User {user} unsubscribed from channel {channel}");
    }
}
