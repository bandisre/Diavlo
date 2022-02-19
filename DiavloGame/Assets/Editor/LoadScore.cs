using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;

public class HandleTextFile
{
    public Text Lvl1TotalScore;
    [MenuItem("Tools/Read file")]
    public void ReadString()
    {
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(Application.persistentDataPath + "/user.data1");
        string TextRead = (reader.ReadToEnd());
        reader.Close();
        Lvl1TotalScore.text = TextRead;
    }
}