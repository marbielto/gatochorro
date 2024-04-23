using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject obstacle2;

    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;

    public float SpeedMultiplier;

    int chooseObstacle;

    private void Awake()
    {
        currentSpeed = MinSpeed;
        generateObstacle();
    }

    public void GenerateNextObstacleWithGap()
    {
        float randomWait = Random.Range(0.1f, 1.2f);
        Invoke("generateObstacle", randomWait);
        
    }


    public void generateObstacle()
    {
        chooseObstacle = Random.Range(1, 3);

        if(chooseObstacle == 1)
        {
            GameObject ObstacleIns = Instantiate(obstacle, transform.position, transform.rotation);
            ObstacleIns.GetComponent<ObstacleScript>().obstacleGenerator = this;
        }

        if (chooseObstacle == 2)
        {
            GameObject ObstacleIns2 = Instantiate(obstacle2, transform.position, transform.rotation);
            ObstacleIns2.GetComponent<ObstacleScript>().obstacleGenerator = this;
        }


    }
    // Update is called once per frame
    void Update()
    {
        if(currentSpeed < MaxSpeed)
        {
            currentSpeed += SpeedMultiplier;
        }
    }
}
