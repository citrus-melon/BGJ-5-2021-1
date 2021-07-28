using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float moveDelay = 1f;
    private Vector3 moveTarget;
    public LayerMask collidesWith;
    private bool diagonalHorizontal = false;
    private float timeToMove = 0;
    void Start()
    {
        moveTarget = transform.position;
        timeToMove = moveDelay;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveTarget, moveSpeed * Time.deltaTime);

        if (timeToMove > 0) {
            if (Vector3.Distance(transform.position, moveTarget) < .05f) timeToMove -= Time.deltaTime;
            return;
        }

        // Accept Input
        float vertical = JoystickManager.singleton.joystick.Vertical !=0 ? JoystickManager.singleton.joystick.Vertical: Mathf.Round(Input.GetAxisRaw("Vertical"));
        float horizontal = JoystickManager.singleton.joystick.Horizontal !=0 ? JoystickManager.singleton.joystick.Horizontal: Mathf.Round(Input.GetAxisRaw("Horizontal"));
        
        if (vertical == 0 && horizontal == 0) return;

        if (vertical != 0 && horizontal != 0) {
            if (diagonalHorizontal) {
                Move(horizontal, 0f);
            } else {
                Move(0f, vertical);
            }
            diagonalHorizontal = !diagonalHorizontal;
        }
        else {
            Move(horizontal, vertical);
        }

        timeToMove = moveDelay;
    }

    void Move(float x, float y) {
        Vector3 newTarget = moveTarget + new Vector3(x, y, 0f);
        if (!Physics2D.OverlapPoint(newTarget, collidesWith)) {
            moveTarget = newTarget;
            SfxPlayer.singleton.queueSound(1);
        }
    }
}