using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSUncapper : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        Application.targetFrameRate = 60;
    }

}
