using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMerge : MonoBehaviour
{
    public LayerMask trigger;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public float triggerRadius = 0.05f;
    public int stage = 1;

    private void Update() {
        Collider2D other = Physics2D.OverlapPoint(transform.position, trigger);
        if(other && Vector2.Distance(other.transform.position, transform.position) <= triggerRadius) {
            if(other.gameObject == gameObject) return;
            int otherStage = other.GetComponent<PlayerMerge>().stage;
            if (otherStage == stage) {
                stage ++;
                SfxPlayer.singleton.queueSound(2);
            } else {
                stage = Mathf.Max(stage, otherStage);
                SfxPlayer.singleton.queueSound(3);
            }
            Destroy(other.transform.parent.gameObject);
            spriteRenderer.sprite = sprites[Mathf.Min(stage-1, 5)];
        }
    }
}
