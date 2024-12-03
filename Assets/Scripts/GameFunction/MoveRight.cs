using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MoveRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject player;
    public Player playerScript;
    bool RightIsPressed = false;

    public AudioSource footsteps;
    public Animator playerAnim;

    void Update()
    {
        if (RightIsPressed)
        {
            player.transform.rotation = new Quaternion(0, 0, 0, 0);
            player.transform.Translate(0, 0, -playerScript.walkSpeed * Time.deltaTime);
            footsteps.enabled = true;
            playerAnim.SetTrigger("PlayerRunningRight");
        }
     
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        RightIsPressed = true;
 
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        RightIsPressed = false;
        footsteps.enabled = false;

        playerAnim.ResetTrigger("PlayerRunningRight");
        playerAnim.SetTrigger("PlayerStopped");
    }

}
