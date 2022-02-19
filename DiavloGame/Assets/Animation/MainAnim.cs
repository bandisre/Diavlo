using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Name: Sree Bandi & Daniel Rusetski 
//Date: November 12, 2020
//Assignment: ICS3U1 Culminating Assignment 
//Script Name: MainAnim
//Purpose of Script: Handles all player animations
public class MainAnim : MonoBehaviour
{
    Animator animator;//Info obtained from sharpcoderblog.com

    public static MainAnim instance1;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();//get the animator component of the object
        instance1 = this;//set the instance as the script
    }


    public void NoteMissed()//a function to be called apon in noteinteraction on any non-successful hit
    {
        animator.Play("Wobble");//play a wobble animation as the enemy has hit the player
    }
    public void NormalHit()//a function to be called apon in noteinteraction on any successful hit
    {
        if (Input.GetKeyDown(KeyCode.Z))//attack animations play as the player is attacking
        {
            animator.Play("Punch1");
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
