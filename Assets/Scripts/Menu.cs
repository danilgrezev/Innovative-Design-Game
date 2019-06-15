using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject settings;

	public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ContineGame()
    {
        //f
    }

    public void Settings()
    {
        settings.SetActive(!settings.activeSelf);
    }

    public void Exit()
    {
        Application.Quit();   
    }
}
