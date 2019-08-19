using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour 
{
    public Button play;
    public Button settings;
    public Button exit;
    public Button yes;
    public Button no;
    public GameObject exitPopup;

    private void Start()
    {
        exitPopup.SetActive(false);
    }

    public void PlayClick ()
	{
		play.image.rectTransform.sizeDelta *= 2;

		SceneManager.LoadScene ("PlayScene");
	}

    public void SettingsClick ()
	{
		settings.image.rectTransform.sizeDelta *= 2;
		SceneManager.LoadScene ("SettingsScene");
	}

    public void ExitClick ()
	{
        exit.image.rectTransform.sizeDelta *= 2;
        exitPopup.SetActive(true);
	}

    public void YesClick()
    {
        Application.Quit();
    }

    public void NoClick()
    {
        //exitPopup.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
