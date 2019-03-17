using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoSpawn : MonoBehaviour
{

    private GameObject dino;

    public GameObject[] spawnPositions;

    [SerializeField]
    private GameObject realDinoPrefab; // 0
    [SerializeField]
    private GameObject unrealDinoPrefab; // 1

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Dinosaur") == null)
        {
            Spawn();
        }
        
    }

    private void Spawn()
    {
        //int dinoOption = Random.Range(0, 2); // returns 0 or 1
        int dinoOption = 1;

        int spawnPos = Random.Range(0, spawnPositions.Length);

        if (dinoOption == 0)
        {
            // Debug.Log("Spawning real");
            dino = (GameObject)Instantiate(realDinoPrefab, spawnPositions[spawnPos].transform.position, transform.rotation);
        }
        else
        {
            // Debug.Log("Spawning unreal");
            dino = (GameObject)Instantiate(unrealDinoPrefab, spawnPositions[spawnPos].transform.position, transform.rotation);
        }
    }
}
