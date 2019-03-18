using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Valve.VR;

public class HitAndFeed : MonoBehaviour
{
    public float timeOfAction = 0.0f;
    public bool timer = true;
    private GameObject dinosaur;
    public bool switchInput = false;

    void Start()
    {
        WriteString("New User", 0.0f);
        Input.GetJoystickNames();
    }

    // Update is called once per frame
    void Update()
    {
        dinosaur = GameObject.FindWithTag("Dinosaur");
        if(Input.anyKeyDown)
        {
            print(Input.inputString);
            
        }
        if (timer)
        {
            timeOfAction += Time.deltaTime;
            if (Input.GetButtonDown("Hit"))//Hit
            {
                if (switchInput)
                {
                    WriteString("Feed", timeOfAction);
                }
                else
                {
                    WriteString("Hit", timeOfAction);
                }
                dinosaur.SetActive(false);
                timer = false;
            } else if (Input.GetButtonDown("Feed"))//Feed
            {
                if (switchInput)
                {
                    WriteString("Hit", timeOfAction);
                }
                else
                {
                    WriteString("Feed", timeOfAction);
                }
                dinosaur.SetActive(false);
                timer = false;
            }
        }
        if (Input.GetButtonDown("Reset"))
        {
            timer = true;
            timeOfAction = 0.0f;
            dinosaur.SetActive(true);
        }
    }

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
