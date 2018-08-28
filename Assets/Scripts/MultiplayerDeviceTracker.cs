// author: Stevie Giovanni

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Multiplayer
{
    /// <summary>
    /// a class to track devices in a multiplayer session
    /// </summary>
    public class MultiplayerDeviceTracker : NetworkBehaviour
    {
        public VRDeviceInterface vrDeviceInterface;

        //[SerializeField]
        //private Types _deviceType;


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
                if (vrDeviceInterface == null)
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
}
