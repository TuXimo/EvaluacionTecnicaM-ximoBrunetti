using Unity.Netcode;
using UnityEngine.UIElements;
using UnityEngine;

namespace Exercises.Multiplayer.Scripts
{
    public class NetworkManagerUI : MonoBehaviour
    {
        private void Awake()
        {
            UnityEngine.Cursor.lockState = CursorLockMode.None;
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