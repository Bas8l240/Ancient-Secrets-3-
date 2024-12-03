using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManger : MonoBehaviour
{
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Storyboard");
    }

    public void StopGame()
    {
        Application.Quit();
    }
    public void invintory()
    {
        image.SetActive(true);
    }
    public void x_button()
    {
        image.SetActive(false);
    }
    
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
}
