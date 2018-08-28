// author: Stevie Giovanni

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Multiplayer.VR
{
    /// <summary>
    /// a class that represents a player in VR 
    /// </summary>
    public class VRPlayer : Player
    {
        /// <summary>
        /// the head prefab to be spawned
        /// </summary>
        [SerializeField]
        private GameObject _headPrefab;

        /// <summary>
        /// the hand prefab to be spawned
        /// </summary>
        [SerializeField]
        private GameObject _handPrefab;

        /// <summary>
        /// when local player is connected, spawns HMD assets
        /// </summary>
        public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();
            CmdSpawnDevices();
        }

        /// <summary>
        /// spawns HMD assets on the server
        /// </summary>
        [Command]
        public void CmdSpawnDevices()
        {
            var head = Instantiate(_headPrefab);
            NetworkServer.SpawnWithClientAuthority(head, connectionToClient);
            var lhand = Instantiate(_handPrefab);
            lhand.GetComponent<MultiplayerDeviceTracker>().DeviceName = "VRLHand";
            NetworkServer.SpawnWithClientAuthority(lhand, connectionToClient);
            var rhand = Instantiate(_handPrefab);
            rhand.GetComponent<MultiplayerDeviceTracker>().DeviceName = "VRRHand";
            NetworkServer.SpawnWithClientAuthority(rhand, connectionToClient);
        }
    }
}
