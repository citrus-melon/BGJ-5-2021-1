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

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f && Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {
            if (diagonalHorizontal) {
                MoveHorizontal();
            } else {
                MoveVertical();
            }
            diagonalHorizontal = !diagonalHorizontal;
        }
        else if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {
            MoveHorizontal();
        }
        else if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {
            MoveVertical();
        }
    }

    void MoveVertical() {
        Vector3 newTarget = moveTarget.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
        if (!Physics2D.OverlapPoint(newTarget, collidesWith)) moveTarget.position = newTarget;
    }

    void MoveHorizontal() {
        Vector3 newTarget = moveTarget.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        if (!Physics2D.OverlapPoint(newTarget, collidesWith)) moveTarget.position = newTarget;
    }
}