using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField]
    public bool Oculus;

    // Start is called before the first frame update
    void Start()
    {
        if (Oculus)
        {
            GameObject.Find("VROnly").SetActive(true);
            GameObject.Find("MobileOnly").SetActive(false);
        }
        else
        {
            GameObject.Find("VROnly").SetActive(false);
            GameObject.Find("MobileOnly").SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
