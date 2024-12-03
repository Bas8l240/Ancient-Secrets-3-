using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle6Controller : MonoBehaviour
{

    public GameObject fl1;
    public GameObject fl2;

    public GameObject fl1DMG;
    public GameObject fl2DMG;

    // Update is called once per frame
    void Start()
    {
        float iTime = Random.Range(0.0f, 2.0f);
        float diTime = Random.Range(3.5f, 4.0f);

        InvokeRepeating("ToggleOn", diTime, diTime);
        InvokeRepeating("ToggleOff", iTime, iTime);
    }

    void ToggleOn()
    {
        fl1.GetComponent<ParticleSystem>().Play();
        fl2.GetComponent<ParticleSystem>().Play();

        Wait(0.2f);

        fl1DMG.SetActive(true);
        fl2DMG.SetActive(true);
    }

    void ToggleOff()
    {
        fl1.GetComponent<ParticleSystem>().Stop();
        fl2.GetComponent<ParticleSystem>().Stop();

        Wait(0.2f);

        fl1DMG.SetActive(false);
        fl2DMG.SetActive(false);
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
