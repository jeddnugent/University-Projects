using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    public PS4Controller sub;
    public monsterImpact subBody;
    public float impact;

    void OnTriggerEnter()
    {
        sub.rotationSpeedCurrent = impact;
        sub.playerSpeedCurrent = 0f;

        subBody.impact();

        Destroy(gameObject);
    }
}
