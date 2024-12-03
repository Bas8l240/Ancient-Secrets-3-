using UnityEngine;

public class Checkpointmanger : MonoBehaviour
{
    public static Vector3 lastCheckpointPosition;

    void start()
    {

    }
    void update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            lastCheckpointPosition = transform.position;
        }
    }
}
