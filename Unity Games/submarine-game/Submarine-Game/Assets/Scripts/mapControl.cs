using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class mapControl : MonoBehaviour
{
    public GameObject map;
    Gamepad ctrl;

    void Awake()
    {
        ctrl = Gamepad.current;
    }

    void Update()
    {
        if (ctrl.dpad.down.isPressed && !map.activeInHierarchy)
            map.SetActive(true);

        if (!ctrl.dpad.down.isPressed && map.activeInHierarchy)
            map.SetActive(false);
    }
}
