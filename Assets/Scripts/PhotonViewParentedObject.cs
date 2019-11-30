using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonViewParentedObject : MonoBehaviour
{
    public string parentPath = "";
    // Start is called before the first frame update
    void Start()
    {
        var photonView = GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
            transform.parent = GameObject.Find(parentPath).transform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
    }

}
