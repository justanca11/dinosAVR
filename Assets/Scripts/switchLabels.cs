using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchLabels : MonoBehaviour
{
    private GameObject spawnDino;
    private DinoSpawn setUpScript;

    private GameObject leftLabel;
    private GameObject rightLabel;

    public Sprite hit;
    public Sprite feed;

    // Start is called before the first frame update
    void Start()
    {
        spawnDino = GameObject.Find("SpawnDino");
        setUpScript = spawnDino.GetComponent<DinoSpawn>();

        leftLabel = GameObject.Find("left label");
        rightLabel = GameObject.Find("right label");
        if (setUpScript.switchInput)
        {
            leftLabel.GetComponent<SpriteRenderer>().sprite = feed;
            rightLabel.GetComponent<SpriteRenderer>().sprite = hit;
        }
        else
        {
            leftLabel.GetComponent<SpriteRenderer>().sprite = hit;
            rightLabel.GetComponent<SpriteRenderer>().sprite = feed;
        }
    }
}
