using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    public GoalTile[] goals;
    public GameObject winScreen;

    // Update is called once per frame
    void Update()
    {
        foreach (GoalTile goal in goals)
        {
            if (!goal.fufilled) return;
        }
        winScreen.SetActive(true);
        PlayerMovement[] movementScripts = FindObjectsOfType<PlayerMovement>();
        foreach (PlayerMovement script in movementScripts) {
            script.enabled = false;
        }
    }
}
