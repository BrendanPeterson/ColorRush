using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Cinemachine;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    public CinemachineVirtualCamera vCam1;
    //public GameObject carToFollow;
    
    [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
    public static GameObject localPlayerInstance;


    private void Awake()
    {
        // #Important
// used in GameManager.cs: we keep track of the localPlayer instance to prevent instantiation when levels are synchronized
        if (photonView.IsMine)
        {
            PlayerManager.localPlayerInstance = this.gameObject;
        }
// #Critical
// we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        if (photonView.IsMine)
        {
            Debug.Log("Adding Cinemachine Components");
            vCam1 = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
            //carToFollow = 
            vCam1.Follow = transform;
            vCam1.LookAt = transform;
        }
        else
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color> Photon View Component on playerPrefab.", this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}