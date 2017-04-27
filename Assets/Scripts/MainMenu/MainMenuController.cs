using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuController : MonoBehaviour {

    public Canvas MainCanvas;
    public Canvas OptionsCanvas;
    public Canvas LevelSelectCanvas;


    void Awake()
    {
        OptionsCanvas.enabled = false;
        LevelSelectCanvas.enabled = false;
	}

    public void OptionsOn()
    {
        OptionsCanvas.enabled = true;
        MainCanvas.enabled = false;
    }

	public void ReturnOn () {

        OptionsCanvas.enabled = false;
        LevelSelectCanvas.enabled = false;
        MainCanvas.enabled = true;
	}

    public void LevelSelectOn()
    {
        MainCanvas.enabled = false;
        LevelSelectCanvas.enabled = true;
    }
    

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}
