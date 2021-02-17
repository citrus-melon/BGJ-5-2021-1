using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Transform moveTarget;
    public LayerMask collidesWith;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveTarget.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, moveTarget.position) > .05f) return;

        if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {
            Vector3 newTarget = moveTarget.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            if (!Physics2D.OverlapPoint(newTarget, collidesWith)) moveTarget.position = newTarget;
        }
        if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {
            Vector3 newTarget = moveTarget.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            if (!Physics2D.OverlapPoint(newTarget, collidesWith)) moveTarget.position = newTarget;
        }
    }
}