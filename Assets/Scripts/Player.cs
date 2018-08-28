using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {
    [SerializeField]
    private GameObject _headPrefab;
    public GameObject _head;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        Debug.Log("Lili");

        CmdSpawnHMD();
        //_head = Instantiate(_headPrefab);
        //NetworkServer.SpawnWithClientAuthority(_head, connectionToClient);
    }

    [Command]
    public void CmdSpawnHMD()
    {
        var head = Instantiate(_headPrefab);
        NetworkServer.SpawnWithClientAuthority(head, connectionToClient);
    }

    /*void Start()
    {
        // only do this for local player
        if (isLocalPlayer)
        {
            _head = Instantiate(_headPrefab);
            NetworkServer.SpawnWithClientAuthority(_head, connectionToClient);

            //CmdSpawnHead();

            // start tracking vr device
            StartCoroutine(TrackVRTransformCoroutine());
        }
    }

    [Command]
    public void CmdSpawnHead()
    {
        _head = Instantiate(_headPrefab);
        if (_head == null) Debug.Log("Wtf");
        // spawn head 
        NetworkServer.SpawnWithClientAuthority(_head,connectionToClient);
    }

    public IEnumerator TrackVRTransformCoroutine()
    {
        Debug.Log("client coroutine reached");
        // find VRDeviceInterface
        var vrDeviceInterface = GameObject.FindObjectOfType<VRDeviceInterface>();
        if (vrDeviceInterface != null)
        {
            while (true)
            {
                Debug.Log("shalalala");
                if (_head != null)
                {
                    Debug.Log("test");
                    _head.transform.SetPositionAndRotation(vrDeviceInterface.transform.position, vrDeviceInterface.transform.rotation);
                }

                yield return null;
            }
        }

        yield return null;
    }*/
}
