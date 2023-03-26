using Unity.Netcode;
using UnityEngine;

namespace Exercises.Multiplayer.Scripts
{
    public class PlayerNetworkFreeCamera : NetworkBehaviour
    {
        [SerializeField] private float mouseSensibility = 2.8f;
        [SerializeField] private float movementSpeed = 20f;
        [SerializeField] private float movementSprint = 50f;
        private float _initMovementSpeed;    
        [SerializeField] private float upAndDownMovementSpeed = 10f;
        
        public override void OnNetworkSpawn()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            //Store initial movement to later use it for the sprint
            _initMovementSpeed = movementSpeed;
            base.OnNetworkSpawn();
        }
        private void Update()
        {
            if(!IsOwner)
                return;
            Movement();
            Rotation();
            ExitServer();
        }

        private void Movement()
        {
            transform.Translate(Vector3.forward * (movementSpeed * Time.deltaTime * Input.GetAxis("Vertical")));
            transform.Translate(Vector3.right * (movementSpeed * Time.deltaTime * Input.GetAxis("Horizontal")));

            if (Input.GetKey(KeyCode.E))
                transform.Translate(Vector3.up * (upAndDownMovementSpeed * Time.deltaTime));

            if (Input.GetKey(KeyCode.Q))
                transform.Translate(Vector3.down * (upAndDownMovementSpeed * Time.deltaTime));

            movementSpeed = Input.GetKey(KeyCode.LeftShift) ? movementSprint : _initMovementSpeed;
        }

        private void Rotation()
        {
            // Vertical Rotation
            transform.rotation *= Quaternion.AngleAxis(-Input.GetAxis("Mouse Y") * mouseSensibility, Vector3.right);

            // Horizontal Rotation
            var eulerAngles = transform.eulerAngles;
            transform.rotation = Quaternion.Euler(eulerAngles.x,
                eulerAngles.y + Input.GetAxis("Mouse X") * mouseSensibility, eulerAngles.z);
        }

        private void ExitServer()
        {
            if (Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.Escape))
                NetworkManager.Singleton.Shutdown();
            
            //Set default cursor        
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
