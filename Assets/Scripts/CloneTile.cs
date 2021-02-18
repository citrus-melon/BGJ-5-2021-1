using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneTile : MonoBehaviour
{
    public LayerMask trigger;
    public GameObject prefab;
    public Transform spawnPoint;
    public float triggerRadius = 0.05f;
    private bool current;

    private void Update() {
        Collider2D overlap = Physics2D.OverlapPoint(transform.position, trigger);
        if(overlap && Vector2.Distance(overlap.transform.position, transform.position) <= triggerRadius) {
            if (!current) Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            current = true;
        } else current = false;
    }
}
