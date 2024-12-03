using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksGoDown : MonoBehaviour
{
    public GameObject holder;
    public GameObject linkTo;

    GameObject playerArea = Player.currentArea;

    public float delayTime = 0f;
    bool destroyed = false;

    void Start()
    {
        linkTo = gameObject.transform.parent.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        playerArea = Player.currentArea;
        
        if (playerArea == linkTo && destroyed == false)
        {
            
            destroyed = true;
            StartCoroutine("Wait", delayTime);
        }
        
    }

    void Disappear()
    {
        holder.SetActive(false);
    }

    IEnumerator Wait(float s)
    {
        yield return new WaitForSecondsRealtime(s);
        Disappear();
    }
}
