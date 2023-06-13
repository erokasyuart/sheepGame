using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawn : MonoBehaviour
{
    public bool canSpawn = true;
    public GameObject sheepPrefab;
    public List<Transform> sheepSpawnPositions = new List<Transform>();
    private List<GameObject> sheepList = new List<GameObject>();
    public float timeBetweenSpawns;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());//
    }

    private void SpawnSheep(){
        Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position;
        //random range of the length of the sheepspawnpositions (1-3) and their positions is saved to randomPosition
        GameObject sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation);
        sheepList.Add(sheep);
        sheep.GetComponent<Sheep>().SetSpawner(this);
    }

    private IEnumerator SpawnRoutine(){
        while(canSpawn){
            SpawnSheep();
            if(timeBetweenSpawns >= 1f)
            {
                timeBetweenSpawns = timeBetweenSpawns - 0.05f;
            }            
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    public void RemoveSheep(GameObject sheep) //removes sheep from list - gets called
    {
        sheepList.Remove(sheep);
    }

    public void DestroyAllSheep()
    {
        foreach(GameObject sheep in sheepList)
        {
            Destroy(sheep);
        }
        sheepList.Clear();
    }
}
