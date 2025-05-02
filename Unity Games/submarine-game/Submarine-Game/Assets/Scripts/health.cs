using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    public int HP;
    public int criticalLevel; //level at which you get a "leak" sound
    public AudioSource leak;
    public GameObject ctrl; //PS4Controller
    public GameObject rotor; //propeller
    public rumble rmbl;

    [Header("fade to black")]
    public RawImage fadeBlack;
    public float fadeDuration;

    public void damage()
    {
        HP--;

        if (HP <= 0)
            kill();

        else if (HP == criticalLevel)
            leak.Play();
    }

    void kill()
    {
        Debug.Log("submarine destroyed!");
        ctrl.SetActive(false);
        rotor.SetActive(false);

        StartCoroutine("fade");
    }

    IEnumerator fade()
    {
        float current = 0f;

        while (current < 1)
        {
            Debug.Log("opacity at " + current);
            current = Mathf.MoveTowards(current, 1f, (1f / fadeDuration) * Time.deltaTime);
            fadeBlack.color = new Color(0f, 0f, 0f, current);
            yield return null;
        }
        rmbl.stopCrash();
    }
}
