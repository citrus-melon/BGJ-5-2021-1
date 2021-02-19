using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource audioSource;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music"); // find all musics
        if (objs.Length > 1) // if the list of musics is more than myself (aka theres already a music)
        {
            Destroy(this.gameObject); // delete myself because theres already another music
        }
        DontDestroyOnLoad(this.gameObject); // otherwise im the first music, and I should stay with the player forever!
        audioSource.volume = PlayerPrefs.GetFloat("musicVolume", audioSource.volume); // load volume from storage
    }

    public void ChangeVolume(float value) {
        audioSource.volume = value; // set volume
        PlayerPrefs.SetFloat("musicVolume", value); // save to storage
        PlayerPrefs.Save();
    }
}
