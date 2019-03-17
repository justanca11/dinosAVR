using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoTowardsPlayer : MonoBehaviour
{

    private GameObject Player;
    public int MoveSpeed = 4;
    public int MaxDist = 30;
    public int MinDist = 10;

    private DinoAnimation DinoAnimScript;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        DinoAnimScript = GameObject.Find("DinoAnim").GetComponent<DinoAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        //always look at player
        transform.LookAt(Player.transform.position);

        //if dino is far from player, go towards player.
        if (Vector3.Distance(transform.position, Player.transform.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            DinoAnimScript.walking = true;


            if (Vector3.Distance(transform.position, Player.transform.position) <= MaxDist)
            {
                   //if dino is within max distance
                   //don't do anything with this I think
            }

        }
        //if dino close to player
        else
        {
            DinoAnimScript.idle = true;
        }
    }
}
