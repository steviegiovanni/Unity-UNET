using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MultiplayerDeviceTracker : NetworkBehaviour{
    public VRDeviceInterface vrDeviceInterface;

    public override void OnStartAuthority()
    {
        base.OnStartAuthority();
        if (hasAuthority)
            StartCoroutine(TrackHMDCoroutine());
    }

    public IEnumerator TrackHMDCoroutine()
    {
        while (true)
        {
            if(vrDeviceInterface == null)
            {
                vrDeviceInterface = GameObject.FindObjectOfType<VRDeviceInterface>();
                if (vrDeviceInterface == null)
                    Debug.LogWarning("No compatible device found!");
            }
            
            if (vrDeviceInterface != null)
            {
                this.transform.SetPositionAndRotation(vrDeviceInterface.transform.position, vrDeviceInterface.transform.rotation);
            }

            yield return null;
        }
    }
}
