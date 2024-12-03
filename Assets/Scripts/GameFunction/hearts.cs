using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hearts : MonoBehaviour
{
    public GameObject Heart1, Heart2, Heart3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateHearts();
    }

    void updateHearts()
    {
        switch (Player.HP)
        {
            case 3:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                break;
            case 2:
                Heart1.SetActive(false);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                break;
            case 1:
                Heart1.SetActive(false);
                Heart2.SetActive(false);
                Heart3.SetActive(true);
                break;
            case 0:
                Heart1.SetActive(false);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                break;
        }
    }
}
