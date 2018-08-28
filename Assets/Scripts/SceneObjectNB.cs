using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SceneObjectNB : NetworkBehaviour {
    [Command]
    public void CmdPush()
    {
        RpcPush();
    }

    [ClientRpc]
    public void RpcPush()
    {
        GetComponent<Rigidbody>().AddForce(0, 1000, 0);
    }

    private void Update()
    {
        if (hasAuthority && Input.GetKeyUp(KeyCode.P))
            CmdPush();
    }
}
