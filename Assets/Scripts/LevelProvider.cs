using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelProvider {
    public static string[] getLevels()
    {
        /*
        TextAsset txt = (TextAsset)Resources.Load("levelOrder", typeof(TextAsset));
        Debug.Log(txt.text.Split('\n')[0]);
        return txt.text.Split('\n');
        */
        /*
        string filePath = Path.Combine(Application.streamingAssetsPath, "levelOrder.txt");
        if (filePath.Contains("://"))
        {
            WWW www = new WWW(filePath);
            return www.text.Split('\n');
        }
        else if (File.Exists(filePath))
        {
            return File.ReadAllLines(filePath);
        }
        else
         * */
        {
            return new string[] {
                "A-1", 
                "A-2",
                "A-3",
                "A-4",
                "A-5",
                "A-6",
                "B-1",
                "B-2",
                "B-3",
                "B-4",
                "B-5",
                "B-6",
                "C-1",
                "C-2",
                "C-3",
                "C-4",
                "D-1",
                "D-2",
                "D-3",
                "D-4",
                "D-5"
            };
        }


    }
}
