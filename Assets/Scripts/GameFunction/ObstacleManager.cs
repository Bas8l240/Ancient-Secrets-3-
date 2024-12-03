    using System.Collections;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject playerCamera;

    public GameObject[] region1Obstacles;
    public GameObject[] region2Obstacles;
    public GameObject[] region3Obstacles;
    public GameObject[] region4Obstacles;

    public LightmapData[] obstacleLightmapData;

    public int regionCount = 4;

    public Transform spawnPoint;   // The spawn point for new obstacles

    private GameObject currentObstacle; // The current active obstacle

    public GameObject checkpointOBJ;

    public int gameLength = 30;
    public int occlusionDistance = 20;
    public float yIncreaser;
    public GameObject[] levelsGenerated;

    void Start()
    {
        Random.InitState(Time.frameCount);
        levelsGenerated = new GameObject[gameLength];

        GenerateObstacles();
    }


    void Update()
    {
        for(int i = 0; i < levelsGenerated.Length; i++)
        {
            float distanceFromPlayer = (playerCamera.transform.position - levelsGenerated[i].transform.position).magnitude;

            if(distanceFromPlayer > occlusionDistance)
            {
                levelsGenerated[i].SetActive(false);
            }
            else
            {
                levelsGenerated[i].SetActive(true);
            }
        }
    }

    void GenerateObstacles()
    {
        int randomIndex = 0;
        int lastRandomIndex = -1;
        int checkpointChance = 0;

        GameObject obstacleCheckpoint = null;

        int currentRegion = 1;
        GameObject[] regionObstacleArray;

        float regionDivision = Mathf.Ceil(gameLength / regionCount);

        int divisionCounter = 0;

        LightmapData currentObstacleLightmapData = null;

        Renderer obR = null;
        GameObject ob = null;

        for(int j = 0; j < gameLength; j++)
        {
            divisionCounter++;

            if(divisionCounter == regionDivision)
            {
                divisionCounter = 0;
                currentRegion++;
            }

            switch (currentRegion)
            {
                case 1:
                    regionObstacleArray = region1Obstacles;
                    break;
                case 2:
                    regionObstacleArray = region2Obstacles;
                    break;
                case 3:
                    regionObstacleArray = region3Obstacles;
                    break;
                case 4:
                    regionObstacleArray = region4Obstacles;
                    break;
                default:
                    regionObstacleArray = region4Obstacles;
                    break;
            }

            if (j == 0)
            {
                randomIndex = 0;
            }
            else
            {
                do
                {
                    randomIndex = Random.Range(0, regionObstacleArray.Length);

                } while (randomIndex == lastRandomIndex);
                
                checkpointChance = Random.Range(0, 5);
            }

            // Update the lastRandomIndex with the current randomIndex
            lastRandomIndex = randomIndex;

            currentObstacle = Instantiate(regionObstacleArray[randomIndex], spawnPoint.position, Quaternion.identity);
            
            switch(currentObstacle.layer)
            {
                case 6:
                    currentObstacleLightmapData = obstacleLightmapData[0];
                    ob = currentObstacle.transform.Find("Obstacle1").gameObject;
                    obR = currentObstacle.transform.Find("Obstacle1").GetComponent<Renderer>();
                    break;
                case 7:
                    currentObstacleLightmapData = obstacleLightmapData[1];
                    ob = currentObstacle.transform.Find("Obstacle2").gameObject;
                    obR = currentObstacle.transform.Find("Obstacle2").GetComponent<Renderer>();
                    break;
                case 8:
                    currentObstacleLightmapData = obstacleLightmapData[2];
                    ob = currentObstacle.transform.Find("Obstacle3").gameObject;
                    obR = currentObstacle.transform.Find("Obstacle3").GetComponent<Renderer>();
                    break;
                case 9:
                    currentObstacleLightmapData = obstacleLightmapData[3];
                    ob = currentObstacle.transform.Find("Obstacle4").gameObject;
                    obR = currentObstacle.transform.Find("Obstacle4").GetComponent<Renderer>();
                    break;
                case 10:
                    currentObstacleLightmapData = obstacleLightmapData[4];
                    ob = currentObstacle.transform.Find("Obstacle5").gameObject;
                    obR = currentObstacle.transform.Find("Obstacle5").GetComponent<Renderer>();
                    break;
                case 11:
                    currentObstacleLightmapData = obstacleLightmapData[5];
                    ob = currentObstacle.transform.Find("Obstacle2Inverted").gameObject;
                    obR = currentObstacle.transform.Find("Obstacle2Inverted").GetComponent<Renderer>();
                    break;
                case 12:
                    currentObstacleLightmapData = obstacleLightmapData[6];
                    ob = currentObstacle.transform.Find("Obstacle6").gameObject;
                    obR = currentObstacle.transform.Find("Obstacle6").GetComponent<Renderer>();
                    break;
                default:
                    break;
            }

            if (checkpointChance == 1)
            {
                obstacleCheckpoint = Instantiate(checkpointOBJ, ob.transform.Find("CheckpointPosition").transform.position, Quaternion.identity);
                obstacleCheckpoint.SetActive(true);
            }

            obR.lightmapIndex = currentObstacleLightmapData.lightmapIndex;
            obR.lightmapScaleOffset = currentObstacleLightmapData.lightmapScaleOffset;

            currentObstacle.SetActive(true);

            if (currentObstacle.tag == "HeightIncreaser")
            {
                spawnPoint.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y + yIncreaser, spawnPoint.position.z - 10);
            }
            else if (currentObstacle.tag == "HeightDecreaser")
            {
                currentObstacle.transform.position = new Vector3(currentObstacle.transform.position.x, currentObstacle.transform.position.y - yIncreaser, currentObstacle.transform.position.z);
                spawnPoint.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y - yIncreaser, spawnPoint.position.z - 10);  
            }
            else
            {
                spawnPoint.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z - 10);  
            }
            
            if (currentObstacle != null)
            {
                levelsGenerated[j] = currentObstacle;
            }
        }
    }

}
