using Photon.Chat;
using ExitGames.Client.Photon;
using UnityEngine;
using TMPro;

public class PhotonChatManager : MonoBehaviour, IChatClientListener
{
    private ChatClient chatClient;
	private bool isOnline= false;
	private string currentRoom;
	public GameObject chatPanel;
	public TMP_InputField  chatText;
	public TextMeshProUGUI chatsText;

	void Start()
	{
    	chatClient = new ChatClient(this);
	}

	void Update()
	{		
		print(" N ??  " + PhotonNetwork.connectionStateDetailed.ToString());
		if(isOnline)
		{
			chatClient.Service();
		}
		print(" C !"+isOnline+"!  " + chatClient.State.ToString());
	}

	public void ChatConnectOnClick(string username, string friendName)
	{
		if (!isOnline)
    	{
			currentRoom = string.Compare(username, friendName) < 0 ? username + friendName : friendName + username;
			isOnline = true;
    		chatClient.Connect("75f6333c-07e6-4dd5-b40a-b5d42c5d2b4d", "version2", new Photon.Chat.AuthenticationValues());
		}
	}

	public void OnConnected(){
    	if (chatClient.State == ChatState.ConnectedToFrontEnd)
    	{
			chatPanel.SetActive(true);
        	chatClient.Subscribe(new string[] { currentRoom });
    	}
    	else
    	{
        	Debug.LogError("Cannot subscribe to chat channel. Not connected to front end server.");
    	}	
	}

	public void Close()
	{
        chatClient.Disconnect();
		chatPanel.SetActive(false);
	}

	public void SendMessages()
	{
		string message = chatText.text;
		chatText.text = "";	
		if(message != "")
		{
			chatClient.PublishMessage(currentRoom, message);
		}	
	}

    public void DebugReturn(DebugLevel level, string message)
    {
        Debug.Log($"DebugReturn: {level} - {message}");
    }

    public void OnChatStateChange(ChatState state)
    {
        Debug.Log($"OnChatStateChange: {state}");
    }

    public void OnDisconnected()
    {
		isOnline = false;
        Debug.Log("Disconnected from Photon Chat");
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        for (int i = 0; i < senders.Length; i++)
        {
            Debug.Log($"Message from {senders[i]} in {channelName}: {messages[i]}");
			chatsText.text += $"\n{messages[i]}";
        }
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        Debug.Log($"Private message from {sender} in {channelName}: {message}");
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        foreach (string channel in channels)
        {
            Debug.Log($"Subscribed to channel: {channel}");
        }
    }

    public void OnUnsubscribed(string[] channels)
    {
        foreach (string channel in channels)
        {
            Debug.Log($"Unsubscribed from channel: {channel}");
        }
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        Debug.Log($"Status update for {user}: {status} - {message}");
    }

    public void OnUserSubscribed(string channel, string user)
    {
        Debug.Log($"User {user} subscribed to channel {channel}");
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        Debug.Log($"User {user} unsubscribed from channel {channel}");
    }
}
