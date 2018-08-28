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
        [SerializeField]
        private GameObject _headPrefab;

        /// <summary>
        /// when local player is connected, spawns HMD assets
        /// </summary>
        public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();
            CmdSpawnHMD();
        }

        /// <summary>
        /// spawns HMD assets on the server
        /// </summary>
        [Command]
        public void CmdSpawnHMD()
        {
            var head = Instantiate(_headPrefab);
            NetworkServer.SpawnWithClientAuthority(head, connectionToClient);
        }
    }
}
