using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterImpact : MonoBehaviour
{
    public rumble rmbl;
    public AudioSource clip;

    public void impact()
    {
        StartCoroutine("impactRumble");
        clip.Play();
    }

    IEnumerator impactRumble()
    {
        rmbl.startCrash();
        yield return new WaitForSeconds(5f);
        rmbl.stopCrash();
    }
}
