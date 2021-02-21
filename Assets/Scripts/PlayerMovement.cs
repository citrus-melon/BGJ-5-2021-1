using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Transform moveTarget;
    public LayerMask collidesWith;
    private bool diagonalHorizontal = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveTarget.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, moveTarget.position) > .05f) return;

        float vertical = JoystickManager.singleton.joystick.Vertical !=0 ? JoystickManager.singleton.joystick.Vertical: Mathf.Round(Input.GetAxisRaw("Vertical"));
        float horizontal = JoystickManager.singleton.joystick.Horizontal !=0 ? JoystickManager.singleton.joystick.Horizontal: Mathf.Round(Input.GetAxisRaw("Horizontal"));

        if (vertical != 0 && horizontal != 0) {
            if (diagonalHorizontal) {
                MoveHorizontal(horizontal);
            } else {
                MoveVertical(vertical);
            }
            diagonalHorizontal = !diagonalHorizontal;
        }
        else if(horizontal != 0) {
            MoveHorizontal(horizontal);
        }
        else if(vertical != 0) {
            MoveVertical(vertical);
        }
    }

    void MoveVertical(float input) {
        Vector3 newTarget = moveTarget.position + new Vector3(0f, input, 0f);
        if (!Physics2D.OverlapPoint(newTarget, collidesWith)) {
            moveTarget.position = newTarget;
            SfxPlayer.singleton.queueSound(1);
        }
    }

    void MoveHorizontal(float input) {
        Vector3 newTarget = moveTarget.position + new Vector3(input, 0f, 0f);
        if (!Physics2D.OverlapPoint(newTarget, collidesWith)) {
            moveTarget.position = newTarget;
            SfxPlayer.singleton.queueSound(1);
        }
    }
}