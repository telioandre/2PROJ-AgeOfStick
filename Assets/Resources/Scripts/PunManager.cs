using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class PunManager : MonoBehaviour
{
    public GameObject castle1;
    public GameObject castle2;
    public TextMeshProUGUI infos;
    
    public GameObject soloMenu;
    public GameObject background;
    public GameObject game;
    public GameObject menuEven;
    public GameObject menuCanvas;
    public GameObject menu;
    public GameObject ia;
    public AudioSource soundEffect;
    
    /*
     * This start method launch the connection.
     */
    private void Start()
    {
        Connect();
    }

    /*
     * This method will connect the user to Photon.
     */
    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings("version1");
    }

    /*
     * This method will set the option of the room?
     */
    private void OnJoinedLobby()
    {
        RoomOptions myRoom = new RoomOptions();
        myRoom.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom("war1", myRoom, TypedLobby.Default);
    }

    /*
     * This method will assign a castle to the player when he's on the room.
     */
    private void OnJoinedRoom()
    {
        AssignCastle();
    }
    /*
     * This method permit to disconnect from Photon.
     */
    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
    }
    
    /*
     * This method will get which user is the master then assign the castle based on it.
     */
    private void AssignCastle()
    {
        if (PhotonNetwork.isMasterClient)
        {
            PhotonNetwork.player.TagObject = castle1;
            Debug.Log("Assigned Castle1 to MasterClient: " + PhotonNetwork.player.NickName);
        }
        else
        {
            PhotonNetwork.player.TagObject = castle2;
            Debug.Log("Assigned Castle2 to player: " + PhotonNetwork.player.NickName);
        }
    }
    
    /*
     * This method is used to change the active GameObject of the scene when the game starts.
     */
    private void ActivateGameObjects()
    {
        soloMenu.SetActive(false);
        background.SetActive(false);
        game.SetActive(true);
        menuEven.SetActive(true);
        menuCanvas.SetActive(false);
        soundEffect.Play();
        ia.SetActive(false);
        menu.SetActive(false);
    }
    
    /*
     * This update method is used to get the current state of connection.
     * It also starts a game when two players joined the room.
     */
    private void Update()
    {
        if(PhotonNetwork.connectionStateDetailed.ToString() != "Joined")
        {
            infos.text = PhotonNetwork.connectionStateDetailed.ToString();
            print(PhotonNetwork.connectionStateDetailed.ToString());
        }
        else
        {
            infos.text = "Connected to : " + PhotonNetwork.room.name + " Player(s) online : " +
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
