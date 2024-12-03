using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiMangerplayer : MonoBehaviour
{
    public GameObject Collection, GameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Xbutton()
    {
        Collection.SetActive(false);
        Time.timeScale = 1;
    }
    public void Retry()
    {
        SceneManager.LoadScene("GamePlay");
        GameOver.SetActive(false);
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GameOver.SetActive(false);
        Time.timeScale = 1;
    }
}
