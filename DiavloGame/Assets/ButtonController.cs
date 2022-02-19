﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Name: Sree Bandi & Daniel Rusetski 
//Date: November 12, 2020
//Assignment: ICS3U1 Culminating Assignment 
//Script Name: ButtonController
//Purpose: Controls the movement of the buttons/animates the button sprites to accurately reflect when they are being pressed down. 
//Public class can be accessed by other scripts.
public class ButtonController : MonoBehaviour //Auto-generated by Unity, MonoBehaviour is the base class from which every Unity script derives. See https://docs.unity3d.com/ScriptReference/MonoBehaviour.html.
{
    //Public variable so that value can be set in the inspector (usually done by clicking and dragging the desired component into the box, this is also why there is no =), this is an empty variable meant for the component SpriteRenderer which can be found in the inspector, it is used to render the sprites and make them visible in the game.
    public SpriteRenderer TheSR;
    //Public variable so that value can be set in the inspector (usually done by clicking and dragging the desired sprite into the box, this is also why there is no =), this is an empty variable in which we can set the desired sprite by dropping it into the box created by the inspector. A sprite is an image which is a game object. 
    public Sprite DefaultImage;
    //Public variable so that value can be set in the inspector (usually done by clicking and dragging the desired sprite into the box, this is also why there is no =), this is an empty variable in which we can set the desired sprite by dropping it into the box created by the inspector. A sprite is an image which is a game object. 
    public Sprite PressedImage;
    //Public variable so that value can be set in the inspector (usually done by choosing the key the variable binds to with the inspector box this is also why there is no =), this is an empty variable for a keyboard key bind.
    public KeyCode KeyPressed;
    //Public variable so that value can be set in the inspector (usually done by choosing the key the variable binds to with the inspector box this is also why there is no =), this is an empty variable for a keyboard key bind.
    public KeyCode StartKey; 
    // Start is called before the first frame update
    void Start()//Auto-generated by Unity, this code means that the code in this method (A method is a code block that contains a series of statements). This is not a private void so it can be accessed by any class, as it has the Start() function it and runs once upon the start of the program (for one frame). 
    {
        //GetComponent retrieves a specified component from the inspector, in this we are setting TheSR to equal to the SpriteRenderer by retrieving the component of SpriteRenderer for the object the script is attached to. 
        TheSR = GetComponent<SpriteRenderer>();
        //This disables SpriteRenderer so that the sprites do not appear until the StartKey is pressed. 
        TheSR.enabled = false;
    }
    // Update is called once per frame
    void Update()//Auto-generated by Unity, Update is called every frame, if the MonoBehaviour is enabled, this means that the code within the update method repeats once every frame.The void keyword is used in method signatures to declare a method that does not return a value.
    {
        //This if statements ensures that this block of code will run only when the StartKey is pressed, as Input.GetKeyDown refers to when the input of a key on the keyboard being pressed. The key in the brackets is the variable that was bound to a specific key.  
        if (Input.GetKeyDown(StartKey))
        {
            //This enables SpriteRenderer so that the sprites do appear if the StartKey is pressed. 
            TheSR.enabled = true;
            //These if statements is used to animate the button (when it being pressed). 
            //This if statement states that if the KeyPressed is pressed down then the PressedImage sprite with be rendered (the PressedImage sprite will be the one that can be seen/present in game).
            if (Input.GetKeyDown(KeyPressed))
            {
                //The PressedImage sprite is rendered by the SpriteRenderer. 
                TheSR.sprite = PressedImage;
            }
            //This if statement states that if the KeyPressed comes up then the DefaultImage sprite with be rendered (the DefaultImage sprite will be the one that can be seen/present in game).
            if (Input.GetKeyUp(KeyPressed))
            {
                //The DefaultImage sprite is rendered by the SpriteRenderer. 
                TheSR.sprite = DefaultImage;
            }
        }
    }
}
