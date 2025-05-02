using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PS4Controller : MonoBehaviour
{
    [Header("movement")]
    public float playerSpeed;
    public float playerAccel;
    public float playerSpeedCurrent; //using this to accel and decel speed
    public float playerDecel;
    public propeller rotor; //visual

    [Header("rotation")]
    public float rotationSpeed;
    public float rotationAccel;
    public float rotationSpeedCurrent; //same as above
    public float rotationDecel;
    public float superDecel;
    private float rotationInput;
    GameObject subModel = null;

    GameObject player = null;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            Debug.Log(Gamepad.all[i].name);
        }

        Debug.Log(Gamepad.all.Count);
        player = GameObject.Find("Player");
        subModel = GameObject.Find("sub_Model");

    }
    void OnEnable()
    {
        InputSystem.EnableDevice(Gamepad.current);
    }

    void OnDisable()
    {
        InputSystem.DisableDevice(Gamepad.current);
    }
    // Update is called once per frame
    void Update()
    {
        if (Gamepad.all.Count > 0)
        {

            if (Gamepad.current.rightTrigger.isPressed)
            {
                playerSpeedCurrent = Mathf.MoveTowards(playerSpeedCurrent, playerSpeed, (playerSpeed / playerAccel) * Time.fixedDeltaTime);

                //player.transform.position += player.transform.forward * playerSpeed * Time.fixedDeltaTime;
                //Debug.Log("DEBUG: right trigger hit");
            }

            if (Gamepad.current.leftTrigger.isPressed)
            {
                playerSpeedCurrent = Mathf.MoveTowards(playerSpeedCurrent, playerSpeed * -1f, (playerSpeed / playerAccel) * Time.fixedDeltaTime);

                //player.transform.position -= player.transform.forward * playerSpeed * Time.fixedDeltaTime;
                //Debug.Log("DEBUG: left trigger hit");
            }

            if (!(Gamepad.current.leftTrigger.isPressed) && !(Gamepad.current.rightTrigger.isPressed))
            {
                /*float rotationAccelTemp;
                if (rotationSpeedCurrent > rotationSpeed)
                    rotationAccelTemp = superDecel;
                else
                    rotationAccelTemp = (rotationSpeed / rotationAccel) * Time.fixedDeltaTime;*/

                playerSpeedCurrent = Mathf.MoveTowards(playerSpeedCurrent, 0f, (playerSpeed / playerDecel) * Time.fixedDeltaTime);
            }

            if (Gamepad.current.rightStick.left.isPressed || Gamepad.current.rightStick.right.isPressed)
            {
                /*
                float rotationAccelTemp;
                if (rotationSpeedCurrent > rotationSpeed)
                    rotationAccelTemp = superDecel;
                else
                    rotationAccelTemp = (rotationSpeed / rotationAccel) * Time.fixedDeltaTime;*/

                rotationInput = Gamepad.current.rightStick.x.ReadValue();
                
                rotationSpeedCurrent = Mathf.MoveTowards(rotationSpeedCurrent, rotationSpeed * rotationInput, (rotationSpeed / rotationAccel) * Time.fixedDeltaTime);

                //player.transform.Rotate(0, rotationInput * rotationSpeed * Time.fixedDeltaTime, 0);
                //Debug.Log("DEBUG: Right trigger hit");
            }
            else
            {
                /*
                float rotationAccelTemp;
                if (rotationSpeedCurrent > rotationSpeed)
                    rotationAccelTemp = superDecel;
                else
                    rotationAccelTemp = (rotationSpeed / rotationDecel) * Time.fixedDeltaTime;*/

                rotationSpeedCurrent = Mathf.MoveTowards(rotationSpeedCurrent, 0f, (rotationSpeed / rotationDecel) * Time.fixedDeltaTime);
            }
        }

        player.transform.Rotate(0, rotationSpeedCurrent * Time.fixedDeltaTime, 0);
        subModel.transform.Rotate(0, rotationSpeedCurrent * Time.fixedDeltaTime, 0);

        player.transform.position += player.transform.forward * playerSpeedCurrent * Time.fixedDeltaTime;
        rotor.speed = playerSpeedCurrent;
    }
}
   