using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float horizontalMovement, verticalMovement;
    private bool jumping;

    public float HorizontalMovement { get => horizontalMovement; set => horizontalMovement = value; }
    public float VerticalMovement { get => verticalMovement; set => verticalMovement = value; }
    public bool Jumping { get => jumping; set => jumping = value; }

    public void ReadPlayerInput()
    {
        HorizontalMovement = Input.GetAxisRaw("Horizontal");
        VerticalMovement = Input.GetAxisRaw("Vertical");
        Jumping = Input.GetButton("Jump");
    }

}
