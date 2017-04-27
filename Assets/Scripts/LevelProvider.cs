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
                "levelA-1", 
                "levelA-2",
                "levelA-3",
                "levelA-4",
                "levelA-5",
                "levelB-1",
                "level9",
                "level9hard",
                "level10",
                "level1-2",
                "level1-4",
                "level1-3",
                "level2-2",
                "level2",
                "level11",
                "level12",
                "level2-3",
                "level3-4",
                "level3-3",
                "level8",
                "level3",
                "level3-2"
            };
        }


    }
}
