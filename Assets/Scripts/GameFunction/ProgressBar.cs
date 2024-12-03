using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBar : MonoBehaviour
{
    public TextMeshProUGUI PercentText;
    public static float progress = 0;
    public Slider slider;

    void Update()
    {

        slider.value = progress;
        PercentText.text = progress.ToString() + '%';
    }

}
