using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Name: Sree Bandi & Daniel Rusetski 
//Date: November 12, 2020
//Assignment: ICS3U1 Culminating Assignment 
//Script Name: SecondAnim
//Purpose of Script: Handles all enemy animations
public class SecondAnim : MonoBehaviour
{
    Animator animator;//Info obtained from sharpcoderblog.com
    public static SecondAnim instance2;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();//get the animator component of the object
        instance2 = this;//set the instance as the script
    }


    public void NormalHit()//a function to be called apon in noteinteraction on any successful hit
    {
        animator.Play("Wobble");//play a wobble animation as the player has hit the enemy
    }
    public void NoteMissed()//a function to be called apon in noteinteraction on any non-successful hit
    {
        if (Input.GetKeyDown(KeyCode.Z))//every input is associated with a animation
        {
            animator.Play("Punch1");//attack animations play as the player has made a mistake and the foe takes advantage and strikes
        }
        if (Input.GetKeyDown(KeyCode.X))//Code waits for the specified key to be pressed, in this instance, x
        {
            animator.Play("Hook");
        }
        if (Input.GetKeyDown(KeyCode.N))//these lines all have a unique animation associated with a keypress
        {
            animator.Play("Punch2");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            animator.Play("Punch3");
        }
    }
}
