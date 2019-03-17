using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoAnimation : MonoBehaviour
{
    [HideInInspector]
    public bool walking = true;
    [HideInInspector]
    public bool idle = false;

    private Animator dinoAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dinoAnim = GameObject.FindWithTag("Dinosaur").GetComponent<Animator>();

        if (walking == true)
        {
            PlayWalkingAnim();
        }
        if(idle == true)
        {
            PlayIdleAnim();
        }
        
    }

    void PlayWalkingAnim()
    {
       dinoAnim.SetBool("Walking", true);
        walking = false;
    }

    void PlayIdleAnim()
    {
        dinoAnim.SetBool("Walking", false);
        idle = false;
    }
}
