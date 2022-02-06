using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] 
        private float moveSpeed;

        private Rigidbody rb;
        private PlayerInput playerInput;
        private Vector3 mouseWorldPosition;
        private float moveSpeedMultiplier = 1;

        public float MoveSpeedMultiplier {
            get 
            {
                return moveSpeedMultiplier;
            }
            set
            {
                if (moveSpeedMultiplier != 0)
                {
                    moveSpeedMultiplier = value;
                }
                else
                    moveSpeedMultiplier = 1;
            }
        }

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            HandleMovement();
        }

        public void HandleMovement()
        {
            playerInput.ReadPlayerInput();
            Move();
        }

        private void Move()
        {
            Vector3 movement = new Vector3(playerInput.HorizontalMovement, 0.0f, playerInput.VerticalMovement);
            rb.AddForce(-movement * moveSpeed * moveSpeedMultiplier, ForceMode.Acceleration);
        }
    }
}