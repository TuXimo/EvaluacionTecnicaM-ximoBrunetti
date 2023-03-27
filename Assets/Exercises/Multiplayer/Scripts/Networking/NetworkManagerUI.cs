using Unity.Netcode;
using UnityEngine;

namespace Exercises.Multiplayer.Scripts.Networking
{
    public class NetworkManagerUI : MonoBehaviour
    {
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.None;
        }

        public void StartServer()
        {
            NetworkManager.Singleton.StartServer();
        }
    
        public void HostServer()
        {
            NetworkManager.Singleton.StartHost();
        }
    
        public void ClientServer()
        {
            NetworkManager.Singleton.StartClient();
        }
    }
}