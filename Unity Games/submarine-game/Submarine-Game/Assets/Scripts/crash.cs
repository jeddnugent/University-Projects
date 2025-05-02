using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crash : MonoBehaviour
{
    public rumble rumbleScript;
    public health HP;

    public AudioSource sfxScrape;

    void OnCollisionEnter()
    {
        Debug.Log("beginning crash");
        rumbleScript.startCrash();

        sfxScrape.Play();

        HP.damage();
    }

    void OnCollisionExit()
    {
        Debug.Log("ending crash");
        rumbleScript.stopCrash();

        sfxScrape.Stop();
    }
}
