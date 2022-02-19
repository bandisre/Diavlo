﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
//Name: Sree Bandi & Daniel Rusetski 
//Date: November 12, 2020
//Assignment: ICS3U1 Culminating Assignment 
//Script Name: GameManager
//Purpose of Script: Handles all the background processing, calculations and changing texts etc.; Manages the game. 
//Public class can be accessed by other scripts.
public class GameManager : MonoBehaviour //Auto-generated by Unity, MonoBehaviour is the base class from which every Unity script derives. See https://docs.unity3d.com/ScriptReference/MonoBehaviour.html.
{
    //Public variables so that value can be set in the inspector (usually done by clicking and dragging the desired component into the box, this is also why there is no =), this creates an empty variable in the inspector for which the desired component/desired value can be dragged into/typed in to set the value. 
    //This is declared as a static variable so that the GameManager will be the same object throughout the scene and so there aren't multiple instances created. 
    public static GameManager instance;
    //Type Audiosource so that the desired audio/music can be played when the scene runs. 
    public AudioSource TheMusic;
    //Type bool determining if the player has started playing is true or false 
    public bool StartPlaying;
    //This is an empty variable for a keyboard key bind. The key used to start the game when pressed.
    public KeyCode StartKey;
    //This is an empty variable for a keyboard key bind. The key used to move back to the start menu at the end of the level. 
    public KeyCode BackKey;
    //This is an empty variable for a keyboard key bind. The key used to move onto the next level if the current level is cleared.
    public KeyCode NextKey;
    //This is an empty variable used to record the number of notes which were normal hits.
    public int MissedHitsNumber;
    //This is an empty variable used to record the number of notes which were missed hits.
    public int NormalHitsNumber;
    //This is an empty variable used to record the number of notes which were good hits.
    public int GoodHitsNumber;
    //This is an empty variable used to record the number of notes which were perfect hits.
    public int PerfectHitsNumber;
    //This is an empty variable used to record the current score of the player without the multiplier.
    public int CurrentScore;
    //This is the variable which records the health of the player overtime.
    public int CurrentHealth = 100;
    //This is the health which is lost per note missed. 
    public int HealthLostPerNote = 5;
    //This is an empty variable used to record the current multiplier.
    public int CurrentMultiplier = 0;
    //This is a parallel array to NoteTypeScores each index number meaning to represent and store the different the note types hit, the datatype is int because it is used to record the number of each of the type of note which is hit. These variables are necessary because NormalHitsNumber etc. are being used to store the total amount of points earned for each note type hit. 
    public int[] NoteTypes;
    //This is a parallel array to NoteTypes containing the values for the points each type of note is worth. 
    public int[] NoteTypeScores = {100, 125, 150, 0};
    //This is the variable which records the total score of the player overtime with the multiplier.
    public int TotalScore = 0;
    //This is the variable which records the total notes in the level; 
    public int TotalNotes;
    //This is a public int variable so that the passing score can be easily modified to change the diffculties of each level, this variable is used to store the minimum score required to clear the level. 
    public int PassingScore; 
    //This is the variable used to input/store the game object Start Screen.
    public GameObject StartScreen;
    //This is the variable used to input/store the game object Results Screen.
    public GameObject ResultsScreen;
    //This is the variable used to input/store the game object Results Screen 2.
    public GameObject GameOver;
    //This array is for the datatype Text used to store all the text that will be changed on the results screen to reflect the final results of the level according to the players success. 
    public Text[] ResultText;
    //This variable is for the datatype text used to display the current score of the player as they are playing.
    public Text ScoreText;
    //This variable is for the datatype text used to display the multiplier of the player as they are playing.
    public Text MultiText;
    //This is a public bool for if the player is currently allowed to continue the level or not.
    public bool Winning = true;
    //Set variable for how much health you regenerate per hit.
    public int NoteRegen;
    //The int for the Scene Build Index. 
    public int BuildIndex;
    //The string to specify the folder name for the text file. 

    //Start is called before the first frame update
    void Start()//Auto-generated by Unity, this code means that the code in this method (A method is a code block that contains a series of statements). This is not a private void so it can be accessed by any class, as it has the Start() function it and runs once upon the start of the program (for one frame). The void keyword is used in method signatures to declare a method that does not return a value.
    {
        //For this specific GameManager (this instance of GameManager), for when we call of the methods inside of GameManager in other scripts.
        instance = this;
        //This is used to find the amount of total notes without counting them, FindObjectOfType finds the game objects which have a specifeid type in this case which have the note itneraction script/component. .Length we have used in Windows Form and Consoles as well, in this case it finds the length of all the game objects which have the NoteInteraction script, thus giving us the number of total notes.
        TotalNotes = FindObjectsOfType<NoteInteraction>().Length;
        //This sets the game object Start Screen as active (as it is true) so that it shows up on the screen before the gameplay begins. 
        StartScreen.SetActive(true);
        //The text UI object for the multiplier displays the following string as nothing.
        MultiText.text = "";
        //The text UI object for the score displays the following string as nothing.
        ScoreText.text = ""; 
    }
    // Update is called once per frame
    void Update()//Auto-generated by Unity, Update is called every frame, if the MonoBehaviour is enabled, this means that the code within the update method repeats once every frame.The void keyword is used in method signatures to declare a method that does not return a value.
    {
        //This sets the game object Result Screen as not active (as it is set false) so that it doesn't show up on the screen before the gameplay begins.
        ResultsScreen.SetActive(false);
        //This sets the game object Result Screen 2 as not active (as it is set false) so that it doesn't show up on the screen before the gameplay begins.
        GameOver.SetActive(false);
        //This if statement is used to execute a block of code by determining if the player has started playing or not with the bool StartPlaying, if the player has not started playing so StartPlaying is false, then by pressing the StartKey the game will start as the bool will become true.
        if (!StartPlaying)
        {
            //This if statements ensures that this block of code will run only when the StartKey is pressed, as Input.GetKeyDown refers to when the input of a key on the keyboard being pressed. The key in the brackets is the variable that was bound to a specific key.
            if (Input.GetKeyDown(StartKey))
            {
                //The bool StartPlaying becomes true.
                StartPlaying = true;
                //The audiosource inserted into TheMusic will play.
                TheMusic.Play();
                //The game object Start Screen will be destroyed with no delay so that it isn't seen during gameplay. 
                Destroy(StartScreen, 0f);
                //The text UI object for the multiplier displays the following string.
                MultiText.text = "Multiplier: x1";
                //The text UI object for the score displays the following string.
                ScoreText.text = "Score: ";
            }
        }
        //This if statement is used to ensure that this block of code will only run if the boolean StartPlaying is true. 
      else if(StartPlaying == true )
      {
            if (Winning == false)//If the player loses all health during the song, they will end prematurely.
            {
                GameOver.SetActive(true);//This will bring up the game over UI for the player.
                if (Input.GetKeyDown(BackKey))
                {
                    //This is using the Unity Scene Manager, when the Nextkey is pressed the second scene in the build index will load, this is the next level scene. 
                    SceneManager.LoadScene("MainMenu");
                }
            }
            //This if statement is used to ensure that this block of code will only run if the music is not playing and the results screen is not already active in the hierachy (the game objects list). 
            if (!TheMusic.isPlaying && !ResultsScreen.activeInHierarchy)
            {
                //This variable is used to store the value of the amount of notes hit, it is calculate the total amount of notes hit by adding the amount of normal notes, good notes and perfect notes hit.
                float TotalNotesHit = NoteTypes[0] + NoteTypes[1] + NoteTypes[2];
                //This variable is used to store the value for the precentage of notes hit by dividing total notes hit by total notes then multiplying the valable by 100.
                float PercentageNotesHit = Mathf.Round((TotalNotesHit / TotalNotes) * 100);
                //The game object results screen is set to active and now can be seen.
                ResultsScreen.SetActive(true);
                //ResultsText.text displays the string and int designated to be shown after the = as a text, ResultsText[0] is the variable which is the first element in the ResultsText array, index 0, this is the text for the text (UI element) in the corresponding box in the inspector. 
                ResultText[0].text = "" + NoteTypes[0];
                //ResultsText.text displays the string and int designated to be shown after the = as a text, ResultsText[1] is the variable which is the second element in the ResultsText array, index 1, this is the text for the text (UI element) in the corresponding box in the inspector.
                ResultText[1].text = "" + NoteTypes[1];
                //ResultsText.text displays the string and int designated to be shown after the = as a text, ResultsText[2] is the variable which is the third element in the ResultsText array, index 2, this is the text for the text (UI element) in the corresponding box in the inspector. 
                ResultText[2].text = "" + NoteTypes[2];
                //ResultsText.text displays the string and int designated to be shown after the = as a text, ResultsText[3] is the variable which is the fourth element in the ResultsText array, index 3, this is the text for the text (UI element) in the corresponding box in the inspector.
                ResultText[3].text = "" + NoteTypes[3];
                //ResultsText.text displays the string and int designated to be shown after the = as a text, ResultsText[4] is the variable which is the fifth element in the ResultsText array, index 4, this is the text for the text (UI element) in the corresponding box in the inspector.
                ResultText[4].text = "" + PercentageNotesHit + "%";
                //ResultsText.text displays the string and int designated to be shown after the = as a text, ResultsText[5] is the variable which is the sixth element in the ResultsText array, index 5, this is the text for the text (UI element) in the corresponding box in the inspector.
                ResultText[5].text = "" + TotalScore;
                //This if statement is to execute the block of code within it if the total score achieved by the player is greater than 20,000 as it is used to display the level cleared congratulations message and unlocks the next level.
                if(TotalScore >= PassingScore)
                {
                    //ResultsText.text displays the string and designated to be shown after the = as a text, ResultsText[6] is the variable which is the sixth element in the ResultsText array, index 6, this is the text for the text (UI element) in the corresponding box in the inspector.
                    ResultText[6].text = "Congratulations you have cleared this level! Press the Esc key to go back or Tab to move onto the next level, however if you choose to go back your progress will be lost and you will have to begin again from level 1";
                    //This if statements ensures that this block of code will run only when the BackKey is pressed, as Input.GetKeyDown refers to when the input of a key on the keyboard being pressed. The key in the brackets is the variable that was bound to a specific key.
                    if (Input.GetKeyDown(BackKey))
                    {
                        //This is using the Unity Scene Manager, when the BacKkey is pressed the third scene in the build index will load, this is the main menu scene. 
                        SceneManager.LoadScene("MainMenu");
                    }
                    //This if statements ensures that this block of code will run only when the NextKey is pressed, as Input.GetKeyDown refers to when the input of a key on the keyboard being pressed. The key in the brackets is the variable that was bound to a specific key.
                    else if (Input.GetKeyDown(NextKey))
                    {
                        //This is using the Unity Scene Manager, when the Nextkey is pressed the second scene in the build index will load, this is the next level scene. 
                        SceneManager.LoadScene(BuildIndex);
                    }
                }
                //Otherwise if the player did not acheive a score high enough to pass the level then this block of code will execute.
                else
                {
                    //ResultsText.text displays the string and designated to be shown after the = as a text, ResultsText[6] is the variable which is the sixth element in the ResultsText array, index 6, this is the text for the text (UI element) in the corresponding box in the inspector.
                    ResultText[6].text = "Unfortunately you have not cleared this level, GAME OVER. Press the Esc key to go back and start again";
                    //This if statements ensures that this block of code will run only when the BackKey is pressed, as Input.GetKeyDown refers to when the input of a key on the keyboard being pressed. The key in the brackets is the variable that was bound to a specific key.
                    if (Input.GetKeyDown(BackKey))
                    {
                        //This is using the Unity Scene Manager, when the BacKkey is pressed the third scene in the build index will load, this is the main menu scene. 
                        SceneManager.LoadScene("MainMenu");
                    }
                }
            }
      }
    }
    //This is new public method (see the comment on void Start() for defintion of method) can be accessed by any class. This method is called NoteMissed(). This method is for whenever a note is missed. 
    //The void keyword is used in method signatures to declare a method that does not return a value.
    public void NoteMissed()
    {
        //As it is in the note missed method whenever a note is missed the current health will decrease by 5 health for every note missed, this is due to my use of a subtracting accumulator, CurrenHealth is only evaluated once with this method. Equal to CurrentHealth = CurrentHealth - HealthLostPerNote. 
        CurrentHealth -= HealthLostPerNote;
        //Accumulator for missed notes which is index element 3 of the array NoteTypes, this variable records the amount of missed notes. 
        NoteTypes[3]++; 
        //This if statment states this the block of code will only run if CurrentHealth is equal to or less than 0.
        if (CurrentHealth <= 0)
        {
            //This sets the winning bool to be false. 
            Winning = false;
        }
    }
    //This is new public method (see the comment on void Start() for defintion of method) can be accessed by any class. This method is called NoteHit(). This method is for whenever a note is hit. 
    //The void keyword is used in method signatures to declare a method that does not return a value.
    public void NoteHit()
    {
        //This if statment states this the block of code will only run if CurrentHealth is equal to or less than 90.
        if (CurrentHealth <= 90)
        {
            //This is an accumulator which adds 10 health to current health as NoteRegen is 10. 
            CurrentHealth = CurrentHealth + NoteRegen;
        }
        //This if statement ensures that the block of code contained within it will only run if health is equal to or greater than 75.
        if (CurrentHealth >= 75)
        {
            //This loop causes the multiplier to increase by 10 for each note hit 
            for (int i = 0; i < 10; i++)
            {
                CurrentMultiplier++;
            }
            //This if statement caps the multiplier at 100 by only executing the code within if the multiplier is equal to or greater than 100.
            if (CurrentMultiplier >= 100)
            {
                //The text UI object for the multiplier displays the following string after the =.
                MultiText.text = "Multiplier: x100, you've reached max multiplier spell power!";
                //The current score is calculated by the NormalHitsNumber added with the GoodHitsNumber added with the PerfectHitsNumber. 
                CurrentScore = NormalHitsNumber + GoodHitsNumber + PerfectHitsNumber;
                //The total score is calculated as currentscore multiplied by the max multiplier.
                TotalScore = CurrentScore * 100;
                //The text UI object for the score displays the following string and int after the =.
                ScoreText.text = "Score: " + TotalScore;
            }
            // Otherwise this block of code runs when multiplier can still increase (is not equal to or greater than 100). 
            else
            {
                //The text UI object for the multiplier displays the following string after the =.
                MultiText.text = "Multiplier: x" + CurrentMultiplier;
                //The current score is calculated by the NormalHitsNumber added with the GoodHitsNumber added with the PerfectHitsNumber. 
                CurrentScore = NormalHitsNumber + GoodHitsNumber + PerfectHitsNumber;
                //The total score is calculated as currentscore multiplied by the current multiplier earned.
                TotalScore = CurrentScore * CurrentMultiplier;
                //The text UI object for the score displays the following string and int after the =.
                ScoreText.text = "Score: " + TotalScore;
            }
        }
        //This if statement is to ensure that if health is less than 75 or score is equal to 0 then to execute the block of code within it. 
        else if (CurrentHealth < 75 || CurrentScore == 0)
        {
            MultiText.text = "Multiplier: Health too low for multiplier spell!";
            //The current score is calculated by the NormalHitsNumber added with the GoodHitsNumber added with the PerfectHitsNumber. 
            CurrentScore = NormalHitsNumber + GoodHitsNumber + PerfectHitsNumber;
            //The total score is equal to the current score as there is no multiplier. 
            TotalScore = CurrentScore;
            //The text UI object for the score displays the following string and int after the =.
            ScoreText.text = "Score: " + TotalScore;
        }
    }
    //This is new public method (see the comment on void Start() for defintion of method) can be accessed by any class. This method is called NormalHit(). This method is for whenever a note is a normal hit. 
    //The void keyword is used in method signatures to declare a method that does not return a value.
    public void NormalHit()
    {
        //This is an accumulator which adds the designated points for a normal hit for every normal hit that occurs. 
        NormalHitsNumber += NoteTypeScores[0];
        //Accumulates the number of normal hits that occur. 
        NoteTypes[0]++;
        //This is calling the NoteHit() method to identify if a note is hit
        NoteHit();
    }
    //This is new public method (see the comment on void Start() for defintion of method) can be accessed by any class. This method is called GoodHit(). This method is for whenever a note is a good hit. 
    //The void keyword is used in method signatures to declare a method that does not return a value.
    public void GoodHit()
    {
        //This is an accumulator which adds the designated points for a good hit for every good hit that occurs. 
        GoodHitsNumber += NoteTypeScores[1];
        //Accumulates the number of good hits that occur. 
        NoteTypes[1]++;
        //This is calling the NoteHit() method to identify if a note is hit
        NoteHit();
    }
    //This is new public method (see the comment on void Start() for defintion of method) can be accessed by any class. This method is called PerfectHit(). This method is for whenever a note is a perfect hit. 
    //The void keyword is used in method signatures to declare a method that does not return a value.
    public void PerfectHit()
    {
        //This is an accumulator which adds the designated points for a perfect hit for every perfect hit that occurs. 
        PerfectHitsNumber += NoteTypeScores[2];
        //Accumulates the number of perfect hits that occur. 
        NoteTypes[2]++;
        //This is calling the NoteHit() method to identify if a note is hit .
        NoteHit();
    }
    void CreateText()
    {
        //This creates the path of the file.
        string path = Application.dataPath + "/Score.txt";
        //This if statement ensures that the filepath does not already exist and then creates it .
        if (!File.Exists(path))
        {
            //This write the path and names the file.
            File.WriteAllText(path, "TotalScores");
        }
        //This is what will be written in the file.
        string content = "Your total score: was" + TotalScore + "\n";
        //Opens a file, appends the specified string to the file, and then closes the file. If the file does not exist, this method creates a file, writes the specified string to the file, then closes the file.
        File.AppendAllText(path, content);
    }
}