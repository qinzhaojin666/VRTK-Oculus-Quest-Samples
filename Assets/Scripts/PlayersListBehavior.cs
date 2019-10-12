using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersListBehavior : MonoBehaviourPunCallbacks
{
    public override void OnEnable()
    {
        string players = "Current Players: \n";
        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
        {
            players += player.NickName + "\n";
        }
        GetComponent<Text>().text = players;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        GetComponent<Text>().text += newPlayer.NickName + " entered room.\n";
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        GetComponent<Text>().text += otherPlayer.NickName + "left room.\n";
    }
}
