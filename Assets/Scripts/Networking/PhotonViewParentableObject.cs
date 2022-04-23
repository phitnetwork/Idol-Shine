using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PhotonViewParentableObject : MonoBehaviour
{
    PlatformManager platformManager;

    [SerializeField]
    private string parentPath_vr = "";

    [SerializeField]
    private string parentPath_mobile = "";

    [SerializeField]
    private Vector3 rotation = Vector3.zero;


    [SerializeField]
    private string alternativePath = "";

    void Start()
    {
        platformManager = GameObject.Find("PlatformManager").GetComponent<PlatformManager>();

        Debug.Log("Oculus value:");
        Debug.Log(platformManager.Oculus);

        if (platformManager.Oculus)
            ParentObject(parentPath_vr);
        else
            ParentObject(parentPath_mobile);
    }

    public void ParentObject(string path)
    {
        var photonView = GetComponent<PhotonView>();
        var parent = GameObject.Find(photonView.IsMine ? path : alternativePath);


        Assert.IsNotNull(parent, "Photon view " + gameObject.name + " has an invalid parent gameobject path " + path);

        transform.parent = parent.transform;
        transform.localPosition = Vector3.zero;

        if (rotation != Vector3.zero)
            transform.localRotation = Quaternion.Euler(rotation);
        else
            transform.localRotation = Quaternion.identity;
    }
}