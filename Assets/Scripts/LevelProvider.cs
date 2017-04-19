using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelProvider {
    public static string[] getLevels()
    {
        string[] levels;

        levels = File.ReadAllLines("Assets/Resources/Levels/levelOrder.txt");

        return levels;
    }
}
