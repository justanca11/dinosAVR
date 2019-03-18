using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Valve.VR;


public class DinoTowardsPlayer : MonoBehaviour
{

    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean hit;
    public SteamVR_Action_Boolean feed;

    private GameObject Player;
    public int MoveSpeed = 4;
    public int MaxDist = 30;
    public int MinDist = 10;

    private float timeOfAction = 0.0f;
    private bool timer = false;

    private GameObject spawnDino;
    private DinoSpawn setUpScript;
    //public bool switchInput = false;

    private DinoAnimation DinoAnimScript;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        DinoAnimScript = GameObject.Find("DinoAnim").GetComponent<DinoAnimation>();

        spawnDino = GameObject.Find("SpawnDino");
        setUpScript = spawnDino.GetComponent<DinoSpawn>();
    }

    public bool GetHit()
    {
        return hit.GetStateDown(handType);
    }

    public bool GetFeed()
    {
        return feed.GetStateDown(handType);
    }
    // Update is called once per frame
    void Update()
    {
        //always look at player
        transform.LookAt(Player.transform.position);
        if (GetHit())
        {
            print("hit");

        }
        if (GetFeed())
        {
            print("feed");

        }
        //if dino is far from player, go towards player.
        if (Vector3.Distance(transform.position, Player.transform.position) >= MinDist)
        {
            Vector3 change = transform.forward * MoveSpeed * Time.deltaTime;
            transform.position += change;
            transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
            //transform.position = new Vector3(transform.position.x + change.x, transform.position.y, transform.position.z + change.z);
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
            //If timer is active
            if (timer)
            {
                //Update time
                timeOfAction += Time.deltaTime;
                if (Input.GetButtonDown("Hit") || GetHit()) 
                {
                    if (setUpScript.switchInput)
                    {
                        WriteString("Feed", timeOfAction);
                    }
                    else
                    {
                        WriteString("Hit", timeOfAction);
                    }
                    timer = false;
                    Destroy(gameObject);
                }
                else if (Input.GetButtonDown("Feed") || GetFeed())
                {
                    if (setUpScript.switchInput)
                    {
                        WriteString("Hit", timeOfAction);
                    }
                    else
                    {
                        WriteString("Feed", timeOfAction);
                    }
                    timer = false;
                    Destroy(gameObject);
                }
            }
            //If timer is not yet active, activate
            else
            {
                timer = true;
                timeOfAction = 0.0f;
            }
        }
    }

    //Prinf function to log action and time
    static void WriteString(string action, float timeOfAction)
    {
        string path = "Assets/Resources/log.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(action + " " + timeOfAction);
        writer.Close();

        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path);
        TextAsset asset = Resources.Load<TextAsset>("log");

        //Print the text from the file
        //Debug.Log(asset.text);
    }
}