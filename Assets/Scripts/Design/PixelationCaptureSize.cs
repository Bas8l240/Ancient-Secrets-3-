using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PixelationCaptureSize : MonoBehaviour
{

    public RenderTexture pixelator;
    private int screenHeight = Screen.height;
    private int screenWidth = Screen.width;

    public Camera playerCam;

    void Start()
    {
        float xFactor = Screen.width / 1920f;
        float yFactor = Screen.height / 1080f;

        Camera.main.rect = new Rect(0, 0, 1, xFactor / yFactor);

        screenHeight = Screen.height;
        screenWidth = Screen.width;

        pixelator.height = (int)(screenHeight / (1 / 0.3f));
        pixelator.width = (int)(screenWidth / (1 / 0.3f));

    }
}
