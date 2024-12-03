using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MoveLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject player;
    public Player playerScript;
    
    bool LeftIsPressed = false;

    public AudioSource footsteps;
    public Animator playerAnim;

    void Update()
    {
        if (LeftIsPressed)
        {
            player.transform.rotation = new Quaternion(0, 180, 0, 0);
            player.transform.Translate(0, 0, -playerScript.walkSpeed * Time.deltaTime);
            footsteps.enabled = true;
            playerAnim.SetTrigger("PlayerRunningRight");
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        LeftIsPressed = true;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        LeftIsPressed = false;
        footsteps.enabled = false;

        playerAnim.ResetTrigger("PlayerRunningRight");
        playerAnim.SetTrigger("PlayerStopped");
    }

}
