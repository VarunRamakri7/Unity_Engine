using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayMenuScript : MonoBehaviour
{
    public Button arcadeBack;
    public Button quickBack;
    public Button locationBack;
    public GameObject quickStartPopup;
    public GameObject locationPopup;
    public GameObject arcadePopup;

    private void Start()
    {
        quickStartPopup.SetActive(false);
        locationPopup.SetActive(false);
        arcadePopup.SetActive(false);
    }

    public void ArcadeClick()
    {
        arcadePopup.SetActive(true);
    }

    public void LocationClick()
    {
        locationPopup.SetActive(true);
    }

    public void QuickClick()
    {
        quickStartPopup.SetActive(true);
    }

    public void ArcadeBack()
    {
        arcadePopup.SetActive(false);
        SceneManager.LoadScene("PlayScene");
    }

    public void QuickBack()
    {
        quickStartPopup.SetActive(false);
        SceneManager.LoadScene("PlayScene");
    }

    public void LocationBack()
    {
        locationPopup.SetActive(false);
        SceneManager.LoadScene("PlayScene");
    }

    public void BackMain()
    {
        SceneManager.LoadScene(0);
    }

}