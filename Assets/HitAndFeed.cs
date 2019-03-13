using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class HitAndFeed : MonoBehaviour
{
    public float timeOfAction = 0.0f;
    public bool timer = true;
    public GameObject dinosaur;
    public bool switchInput = false;

    // Update is called once per frame
    void Update()
    {
        if (timer)
        {
            timeOfAction += Time.deltaTime;
            if (Input.GetButtonDown("Fire1"))//Hit
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
            } else if (Input.GetButtonDown("Fire2"))//Feed
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
        Debug.Log(asset.text);
    }

}
