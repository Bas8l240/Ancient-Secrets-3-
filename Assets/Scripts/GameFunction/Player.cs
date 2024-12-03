using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    public Button jumpButton;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    public GameObject collection, playerCamera;
    public static float transitondetecer = 0;
    public GameObject door;
    public static int HP = 2;
    private Vector3 velocity;
    private bool isGrounded;
    public float walkSpeed = 5;
    private Vector3 lastCheckpoint;
    private CharacterController characterController;
    private float currentSpeed;
    private Vector3 respawnPosition;
    public Transform currentCheckpoint;
    private Transform playerTransform;
    public float teleportDistance = 1.0f;
    public string playerTag = "Player";
    public float moveSpeed = 5f;

    private float progressSlicer;
    public ObstacleManager obM;

    public GameObject GameOverUI;
   
    private float moveDirection = 0f;

    bool cameraMoveOrder = false;
    Vector3 cameraPosition;

    public static GameObject currentArea;
    public Animator playerAnim;

    void Start()
    {
        // Add a listener to the button to call the Jump method when pressed
        jumpButton.onClick.AddListener(Jump);
        characterController = GetComponent<CharacterController>();
        playerTransform = GameObject.FindGameObjectWithTag(playerTag)?.transform;
        HP = 3;
        progressSlicer = 100 / obM.gameLength;
    }

    void Update()
    {
        Vector3 movement = new Vector3(0f, 0f, moveDirection);
        characterController.Move(movement * moveSpeed * Time.deltaTime);
        ApplyGravity();

        if (characterController.isGrounded)
        {
            playerAnim.ResetTrigger("RunToJump");
            playerAnim.SetTrigger("JumpToStand");
            velocity.y = 0f;
        }

        velocity.y += gravity * Time.deltaTime;


        if (cameraMoveOrder)
        {
            playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, cameraPosition, 3f * Time.deltaTime);

            if (Vector3.Distance(playerCamera.transform.position, cameraPosition) < 0.01f)
            {
                playerCamera.transform.position = cameraPosition;
                cameraMoveOrder = false;
            }
        }

    }

    public void Jump()
    {
        isGrounded = characterController.isGrounded;

        if (isGrounded)
        {
            playerAnim.SetTrigger("RunToJump");
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "date")
        {
            Debug.Log("collide");

            if (HP < 3)
            {
                Destroy(other.gameObject);
                HP++;
            }

        }

        if (other.gameObject.tag == "Trap")
        {
            HP--;

            if(HP <= 0)
            {
                GameOverUI.SetActive(true);
                Time.timeScale = 0;
            }
        }

        if (other.gameObject.tag == "collecter")
        {
            Destroy(other.gameObject);
            collection.SetActive(true);
            Debug.Log("coo");
           

        }

        if(other.gameObject.tag == "quicksand")
        {

            walkSpeed = 2;
        }

        if (other.gameObject.tag == "InstantDeathTrap")
        {

            HP = 0;
            Destroy(gameObject);
            GameOverUI.SetActive(true);
            Time.timeScale = 0;
        }
        
        if (other.gameObject.tag == "Camera Volume")
        {
            cameraPosition = other.gameObject.transform.parent.transform.Find("CameraPosition").transform.position;

            cameraMoveOrder = true;

            playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, cameraPosition, 0.1f);
            currentArea = other.gameObject.transform.parent.gameObject;
            transitondetecer++;


            ProgressBar.progress += progressSlicer;
            print("good");

            GameObject.Destroy(other.gameObject);

            TeleportBehindPlayer();
        }

        if(other.gameObject.tag == "Checkpoint")
        {
            currentCheckpoint = other.gameObject.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "quicksand")
        {
            walkSpeed = 5;
        }
    }

   

    public void xbutton()
    {
        collection.SetActive(false);
    }

    public void Respawn()
    {
        transform.position = currentCheckpoint.position;
    }

    void TeleportBehindPlayer()
    {
        if (playerTransform != null && door != null)
        {
            // Move the door behind the player by 1 meter
            Vector3 teleportPosition = playerTransform.position - new Vector3(0, 0, -0.5f) * teleportDistance;
            door.transform.position = teleportPosition;
        }
    }

    public void MoveLeft()
    {
        moveDirection = 1f; 
    }

    
    public void MoveRight()
    {
        moveDirection = -1f;  
    }

    
    public void StopMovement()
    {
        moveDirection = 0f;
    }

}
