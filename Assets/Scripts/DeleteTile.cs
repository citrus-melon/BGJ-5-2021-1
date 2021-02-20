using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTile : MonoBehaviour
{
    public LayerMask trigger;
    public float triggerRadius = 0.05f;
    private void Update() {
        Collider2D other = Physics2D.OverlapPoint(transform.position, trigger);
        if(other && Vector2.Distance(other.transform.position, transform.position) <= triggerRadius) {
            SfxPlayer.singleton.queueSound(3);
            Destroy(other.transform.parent.gameObject);
        }
    }
}
