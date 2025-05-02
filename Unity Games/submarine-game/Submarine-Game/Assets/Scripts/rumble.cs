using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class rumble : MonoBehaviour
{
    [Header("Input")]
    public bool doInput; //used for crash rumble
    public char activeInput; //which sonar input is currently in use

    [Header("Direction")] //directions of left and right raycasts
    public Vector3 dir_l;
    public Vector3 dir_r;

    [Header("Sonar")]
    public float freq_min; //shortest gap between pulses
    public float freq_max; //longest gap between pulses
    float freq_co; //distance between min and max for math

    public float dist_min; //minimum distance before continuous pulse
    public float dist_max; //maximum distance before continuous pulse
    float dist_co;

    Gamepad ctrl;

    void Awake() //setup
    {
        //math
        freq_co = freq_max - freq_min;
        dist_co = dist_max - dist_min;

        //controller setup
        ctrl = Gamepad.current;

        if (ctrl == null)
            Debug.Log("sonar: no controller detected");
        else
            Debug.Log("sonar: controller detected");

        //StartCoroutine("pulse", Vector3.forward);
    }

    void FixedUpdate()
    {
        if (doInput) //dpad input
        {
            if (ctrl.dpad.up.isPressed)
            {
                if (activeInput != 'f')
                {
                    activeInput = 'f';
                    Debug.Log("dpad up");

                    StopCoroutine("pulse");
                    StartCoroutine("pulse", transform.forward);
                }
            }

            else if (ctrl.dpad.left.isPressed)
            {
                if (activeInput != 'l')
                {
                    activeInput = 'l';
                    Debug.Log("dpad left");

                    StopCoroutine("pulse");
                    StartCoroutine("pulse", transform.right * -1f);
                }
            }

            else if (ctrl.dpad.right.isPressed)
            {
                if (activeInput != 'r')
                {
                    activeInput = 'r';
                    Debug.Log("dpad right");

                    StopCoroutine("pulse");
                    StartCoroutine("pulse", transform.right);
                }
            }

            else
            {
                if (activeInput != 'n')
                {
                    activeInput = 'n';
                    Debug.Log("no dpad");

                    StopCoroutine("pulse");
                    ctrl.SetMotorSpeeds(0f, 0f);
                }
            }
        }
    }

    float sonarCast(Vector3 dir) //handles measuring distance for sonar
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, dir, out hit, dist_max))
            return hit.distance;
        else
            return dist_max;
    }

    IEnumerator pulse(Vector3 dir) //creates rumble pulse
    {
        while (true)
        {
            float freq;

            float hit = sonarCast(dir);

            if (hit == dist_max) //too far
                freq = freq_max;

            else if (hit <= dist_min) // too close
            {
                while (true)
                {
                    ctrl.SetMotorSpeeds(0.25f, 1f);

                    yield return null;

                    if (sonarCast(dir) > dist_min)
                        break;
                }

                freq = 0;
            }

            else
                freq = (hit - dist_min) / dist_co * freq_co; //normalising

            if (freq > 0) //pulse
            {
                ctrl.SetMotorSpeeds(0.25f, 1f);
                yield return new WaitForSeconds(0.25f);
                ctrl.SetMotorSpeeds(0f, 0f);
            }

            yield return new WaitForSeconds(freq);
        }
    }

    public void startCrash() //start crash rumble effect
    {
        doInput = false;
        activeInput = 'n';
        StopCoroutine("pulse");
        ctrl.SetMotorSpeeds(2f, 0.25f);
    }

    public void stopCrash() //stop crash rumble effect
    {
        doInput = true;
        ctrl.SetMotorSpeeds(0f, 0f);
    }
}
