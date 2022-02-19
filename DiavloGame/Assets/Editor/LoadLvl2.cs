using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;

public class HandleTextFile1
{
    public Text Lvl2TotalScore;
    [MenuItem("Tools/Read file")]
    public void ReadString()
    {
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(Application.persistentDataPath + "/user.data2");
        string TextRead = (reader.ReadToEnd());
        reader.Close();
        Lvl2TotalScore.text = TextRead;
    }
}


