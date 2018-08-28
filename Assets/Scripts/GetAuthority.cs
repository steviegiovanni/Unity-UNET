using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetAuthority : NetworkBehaviour {

	[Command]
    void CmdGetAuthority()
    {
        var go = GameObject.Find("SceneObject");
        go.GetComponent<NetworkIdentity>().RemoveClientAuthority(go.GetComponent<NetworkIdentity>().clientAuthorityOwner);
        go.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient);
    }

    private void Update()
    {
        if (isLocalPlayer)
        {
            if (Input.GetKeyUp(KeyCode.Z))
                CmdGetAuthority();
        }
    }
}
