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
        /// <summary>
        /// the device to be tracked
        /// </summary>
        private GameObject _device;

        /// <summary>
        /// name of the device to be tracked
        /// </summary>
        [SerializeField]
        [SyncVar]
        private string _deviceName;
        public string DeviceName
        {
            get { return _deviceName; }
            set { _deviceName = value; }
        }

        /// <summary>
        /// start tracking coroutine when given the authority
        /// </summary>
        public override void OnStartAuthority()
        {
            base.OnStartAuthority();
            if (hasAuthority)
                StartCoroutine(TrackDeviceCoroutine());
        }

        /// <summary>
        /// track the device position and orientation
        /// </summary>
        public IEnumerator TrackDeviceCoroutine()
        {
            while (true)
            {
                // try to find the device if null
                if (_device == null)
                {
                    _device = GameObject.Find(DeviceName);
                    // test commit
                    //if (_device == null)
                    //    Debug.LogWarning("No device found!");
                }

                // track the device if it exists
                if (_device != null)
                {
                    this.transform.SetPositionAndRotation(_device.transform.position, _device.transform.rotation);
                }

                yield return null;
            }
        }
    }
}
