using Oculus.Platform;
using Oculus.Platform.Models;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OculusPlatformManager : MonoBehaviour
{
    public Text logText;

    void Start()
    {
        PhotonNetwork.NickName = "Default User";
        try
        {
            Core.AsyncInitialize();
            Oculus.Platform.Entitlements.IsUserEntitledToApplication().OnComplete(EntitlementCallback);
        }
        catch (UnityException e)
        {
            logText.text = "Platform failed to initialize due to exception.";
            logText.text += "\n" + e;
        }
    }

    private void Update()
    {
        Oculus.Platform.Request.RunCallbacks();
    }

    void GetLoggedInUserCallback(Message<User> msg)
    {
        if (!msg.IsError)
        {
            PhotonNetwork.NickName = msg.Data.ID.ToString();
            logText.text = "Got user " + msg.Data.ID.ToString();
        }
        else
        {
            logText.text = msg.GetError().Message;
        }
    }
    void EntitlementCallback(Message msg)
    {
        if (msg.IsError)
        {
            logText.text = "Entitlement error!";
        }
        else
        {
            logText.text = "Entitlement succeded!";
        }
        Oculus.Platform.Users.GetLoggedInUser().OnComplete(GetLoggedInUserCallback);
    }
}
