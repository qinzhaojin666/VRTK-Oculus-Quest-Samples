using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class NetworkedController : MonoBehaviourPunCallbacks
{
    public Text logText;
    public GameObject playerList;

    string _room = "MeetupVR";
    string _gameVersion = "0.1";

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    void Start()
    {
        PhotonNetwork.NickName = "Oculus";
        PhotonNetwork.AutomaticallySyncScene = true;
        
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.GameVersion = _gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
        Debug.Log("Connecting...");
    }
    
    public override void OnConnectedToMaster()
    {
        logText.text = "Connected to master";
        Debug.Log("Connected to master!");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        logText.text = "Disconnected with reason " + cause;
        Debug.LogWarningFormat("Disconnected with reason {0}", cause);
    }

    public override void OnJoinedRoom()
    {
        logText.text = "Room joined! Welcome " + PhotonNetwork.NickName;
        Debug.Log("Room joined!");

        playerList.SetActive(true);
        CreatePlayer();

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        logText.text = "Room join failed: " + message;
        Debug.LogWarning("Room join failed: " + message);
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 8});
    }

    private void CreatePlayer()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "RightHandPrefab"), Vector3.zero, Quaternion.identity, 0);
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "LeftHandPrefab"), Vector3.zero, Quaternion.identity, 0);
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "HeadPrefab"), Vector3.zero, Quaternion.identity, 0);
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "VoiceView"), Vector3.zero, Quaternion.identity, 0);
    }
}
