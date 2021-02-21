using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxPlayer : MonoBehaviour
{
    public AudioSource move;
    public AudioSource merge;
    public AudioSource delete;
    public AudioSource win;
    public static SfxPlayer singleton;

    private int soundID = 0;
    void Awake()
    {
        singleton = this;
    }
    public void queueSound(int sound) {
        soundID = Mathf.Max(sound, soundID);
    }
    private void LateUpdate() {
        if (soundID == 4) {
            win.Play();
        } else if (soundID == 3) {
            delete.Play();
        } else if (soundID == 2) {
            merge.Play();
        } else if (soundID == 1) {
            move.Play();
        }
        soundID = 0;
    }
}
