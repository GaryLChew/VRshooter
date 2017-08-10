using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    //Currently, i = 0 is HP, 1 is Ammo
    public GameObject[] itemOptions;
    public GameObject currItem;
    public int currItemID;
    public PlayerData player;

    int numEnemies;
    int maxEnemies = 20;

    void Start()
    {
        SpawnItem();
    }

    private void SpawnItem()
    {
        currItemID = Random.Range(0, itemOptions.Length);
        currItem = Instantiate(itemOptions[currItemID], this.transform.position, this.transform.rotation);
        numEnemies++;
    }   
    
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag=="Player"&&currItem!=null) {
            print("deleting");
            Destroy(currItem);
            doAction();
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(10);
        SpawnItem();
    }

    private void doAction()
    {
        if (currItemID == 0)
        {
            player.heal(10);
        }
        else if(currItemID == 1)
        {
            player.addAmmo(12);
        }
    }
}
