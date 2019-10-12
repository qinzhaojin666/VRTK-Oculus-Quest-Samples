using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAvatarController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var photonView = GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
            transform.parent = GameObject.Find("VRTK/TrackedAlias/Aliases/RightControllerAlias").transform;
            transform.localPosition = Vector3.zero;
        }
    }
}
