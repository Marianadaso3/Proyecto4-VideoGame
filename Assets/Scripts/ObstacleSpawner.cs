using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    void Start()
    {
        //inicio de los obstaculos hasta que inicie el jugador .
        StartCoroutine(SpawnObstacle());
    }

    
    private IEnumerator SpawnObstacle()
    {
        while (true) //hacer que los obstaculos salgan de manera aleatoria
        {
            int randomIndex = Random.Range (0, obstacles.Length);
            //tiempo aletorio
            float minTime = 1.5f;
            float maxTime = 2.5f;
            float randomTime = Random.Range(minTime, maxTime);


            Instantiate(obstacles[randomIndex], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(randomTime);
        }
    }

    //metodo para qeu se eliminen los obstaculos 
    private void OnTriggerEnter(Collider collision) 
    {
        Destroy(collision.gameObject);
    }

}

