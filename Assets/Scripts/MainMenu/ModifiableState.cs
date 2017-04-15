using UnityEngine;
using System.Collections;

public class ModifiableState : MonoBehaviour {

    public string CurrentLevel
    {
        get { return persistentState.currentLevel; }
        set { persistentState.currentLevel = value; }
    }
    
    public PersistentState persistentState;

    void Awake()
    {
        GameObject persistentGameObject = GameObject.Find("PersistentState");

        if (persistentGameObject == null)
        {
            persistentGameObject = new GameObject("PersistentState");
            persistentState = persistentGameObject.AddComponent<PersistentState>();
            DontDestroyOnLoad(persistentGameObject);
        }
        else
        { 
            persistentState = persistentGameObject.GetComponent<PersistentState>();
        }

    }
}
