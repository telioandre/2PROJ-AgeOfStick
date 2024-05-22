using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PunManager : MonoBehaviour
{
    public GameObject Castle1;
    public GameObject Castle2;
    public TextMeshProUGUI Infos;
    
    public GameObject SoloMenu;
    public GameObject Background;
    public GameObject Game;
    public GameObject MenuEven;
    public GameObject MenuCanvas;
    public GameObject Menu;
    public GameObject ia;
    public AudioSource SoundEffect;
    
    void Start()
    {
        Connect();
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings("version1");
    }

    void OnJoinedLobby()
    {
        RoomOptions MyRoom = new RoomOptions();
        MyRoom.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom("war1", MyRoom, TypedLobby.Default);
    }

    void OnJoinedRoom()
    {
        AssignCastle();
    }
    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
    }

    void AssignCastle()
    {
        if (PhotonNetwork.isMasterClient)
        {
            PhotonNetwork.player.TagObject = Castle1;
            Debug.Log("Assigned Castle1 to MasterClient: " + PhotonNetwork.player.NickName);
        }
        else
        {
            PhotonNetwork.player.TagObject = Castle2;
            Debug.Log("Assigned Castle2 to player: " + PhotonNetwork.player.NickName);
        }
    }
    void ActivateGameObjects()
    {
        SoloMenu.SetActive(false);
        Background.SetActive(false);
        Game.SetActive(true);
        MenuEven.SetActive(true);
        MenuCanvas.SetActive(false);
        SoundEffect.Play();
        ia.SetActive(false);
        Menu.SetActive(false);
    }
    
    void Update()
    {
        if(PhotonNetwork.connectionStateDetailed.ToString() != "Joined")
        {
            Infos.text = PhotonNetwork.connectionStateDetailed.ToString();
            print(PhotonNetwork.connectionStateDetailed.ToString());
        }
        else
        {
            Infos.text = "Connected to : " + PhotonNetwork.room.name + " Player(s) online : " +
                         PhotonNetwork.room.playerCount + " Master ? " + PhotonNetwork.isMasterClient;
        }
        if (PhotonNetwork.room != null)
        {
            if (PhotonNetwork.room.PlayerCount == 2)
            {
                ActivateGameObjects();
            }
        }
    }
}
