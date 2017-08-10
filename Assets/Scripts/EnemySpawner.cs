using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public Transform[] sp;
    int numEnemies;
    int maxEnemies = 20;

	// Use this for initialization
	void Start () {

        InvokeRepeating("SpawnEnemy", 4, 4);
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void SpawnEnemy()
    {
        if (numEnemies < maxEnemies)
        {
            Transform randomSP = sp[Random.Range(0, sp.Length)];
            if (randomSP != null)
            {
                Vector3 location = new Vector3(3 * numEnemies, 2, 0);
                Instantiate(enemy, randomSP.position, randomSP.rotation);
                numEnemies++;
            }
        }
    }
    public void killEnemy()
    {
        numEnemies--;
    }
}
