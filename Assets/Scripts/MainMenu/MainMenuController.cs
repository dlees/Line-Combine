using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuController : MonoBehaviour {

    public Canvas MainCanvas;
    public Canvas OptionsCanvas;
    public Canvas LevelSelectCanvas;
    public Canvas CreditsCanvas;
    public Canvas HelpScreenCanvas;


    void Awake()
    {
        OptionsCanvas.enabled = false;
        LevelSelectCanvas.enabled = false;
        CreditsCanvas.enabled = false;
        HelpScreenCanvas.enabled = false;
	}

    public void OptionsOn()
    {
        OptionsCanvas.enabled = true;
        MainCanvas.enabled = false;
    }

	public void ReturnOn () {

        OptionsCanvas.enabled = false;
        LevelSelectCanvas.enabled = false;
        CreditsCanvas.enabled = false;
        HelpScreenCanvas.enabled = false;
        MainCanvas.enabled = true;
	}

    public void LevelSelectOn()
    {
        MainCanvas.enabled = false;
        LevelSelectCanvas.enabled = true;
    }

    public void CreditsOn()
    {
        MainCanvas.enabled = false;
        CreditsCanvas.enabled = true;
    }

    public void HelpScreenOn()
    {
        MainCanvas.enabled = false;
        HelpScreenCanvas.enabled = true;
    }

    public void GoToWebsite()
    {
        Application.OpenURL("http://whats-in-a-game.com/blog/line-combine?utm_source=game&utm_medium=linecombine");
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
