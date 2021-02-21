using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickManager : MonoBehaviour
{
    public static JoystickManager singleton;
    public FloatingJoystick joystick;

    void Awake()
    {
        singleton = this;
    }
}
