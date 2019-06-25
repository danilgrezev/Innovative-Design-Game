using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    bool isLocked = true;
    bool flaff = false;
    public GameObject settings;
    public GameObject diedScreen;
    public GameObject miniMenuPanel;  

    public float maxHp;
    public float hp;
    public Slider sliderHp;

    public double maxArm;
    public double arm;
    public Slider sliderArm;

    int start = 0;
    public static int flag = 0;
    public static int flagM;

    void Start()
    {
        flagM = 1;
        maxArm = 100;
        arm = maxArm;

        maxHp = 100;
        hp = maxHp;

        SetCursorLock(true);

        start++;
        diedScreen.SetActive(false);

        Time.timeScale = 1;

    }

    public void SetCursorLock(bool isLocked)
    {
        this.isLocked = isLocked;
        Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }    

    public void Settings()
    {
        settings.SetActive(!settings.activeSelf);
    }

    public void Exit()
    {
        Application.Quit();   
    }
<<<<<<< GenerationDG
=======
   
    // Update is called once per frame
    void Update()
    {
        sliderHp.value = hp;

        if (Input.GetKeyDown(KeyCode.H))
        {
            hp -= 20;
        }
        if (hp > maxHp)
        {
            hp = maxHp;
        }        
        if (hp <= 0)
        {
            hp = 0;
            flag = 1;
        }
        if (flag == 1)
        {
            flagM = 0;
            SetCursorLock(false);
            diedScreen.SetActive(true);
            Time.timeScale = 0;
        }

        sliderArm.value = (float)arm;
        if (Input.GetKeyDown(KeyCode.G))
        {
            arm -= 30;
        }
        if (arm > maxArm)
        {
            arm = maxArm;
        }
        if (arm < 0)
        {
            arm = 0;
        }
        int esc = 0;

        if (Input.GetKeyDown(KeyCode.Escape) && esc == 0)
        {
            esc = 1;
            SetCursorLock(flaff);
            Debug.Log("flaff  " + flaff);
            flaff = !flaff;
            miniMenuPanel.SetActive(!miniMenuPanel.activeSelf);
        }        
        else if (Input.GetKeyDown(KeyCode.Escape) && esc > 0)
        {
            SetCursorLock(flaff);
            miniMenuPanel.SetActive(miniMenuPanel.activeSelf);
            Cursor.lockState = CursorLockMode.Locked;

        }

        

        //if (Input.GetKey(KeyCode.Escape))
        //{
        //    switch (esc)
        //    {
        //        case 0:
        //            SetCursorLock(flaff);
        //            Debug.Log("flaff  " + flaff);
        //            flaff = !flaff;
        //            miniMenuPanel.SetActive(!miniMenuPanel.activeSelf);
        //            flagM = 0;
        //            Time.timeScale = 0;
        //            esc = 1;
        //            break;

        //        case 1:
        //            Time.timeScale = 1;
        //            miniMenuPanel.SetActive(miniMenuPanel.activeSelf);
        //            Cursor.lockState = CursorLockMode.Locked;
        //            flagM = 1;
        //            esc = 0;
        //            break;
        //    }

        //}

    }

    public void restartGame()
    {
        SceneManager.LoadScene(GenerationObjects.sceneName);
    }

    public void goToMenu()
    {
        SceneManager.LoadScene(0);
    }
>>>>>>> local
}
