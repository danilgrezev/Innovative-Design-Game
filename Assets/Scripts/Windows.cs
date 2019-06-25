using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Windows : MonoBehaviour
{
    bool isLocked;
    bool flaff = false;

    public GameObject Player;
    public GameObject diedScreen;
    public GameObject miniMenuPanel;

    public static int flagM = 1;
    int flag = 0;
    int flagStop = 1;

    public int hp;
    public int arm;

    public Slider sliderArm;
    public Slider sliderHp;
    // Start is called before the first frame update
    void Start()
    {
        flagM = 1;

        arm = 100;
        hp = 100;

        SetCursorLock(true);
        Time.timeScale = 1;
    }
    public void SetCursorLock(bool isLocked)
    {
        this.isLocked = isLocked;
        Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
    }
    // Update is called once per frame
    void Update()
    {
        sliderHp.value = hp;
               
        if (Input.GetKeyDown(KeyCode.H))
        {
            hp -= 20;
        }
        if (hp > 100)
        {
            hp = 100;
        }
        if (Player.transform.position.y < -3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

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


        sliderArm.value = arm;
        if (Input.GetKeyDown(KeyCode.G))
        {
            arm -= 30;
        }
        if (arm > 100)
        {
            arm = 100;
        }
        if (arm < 0)
        {
            arm = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetCursorLock(false);
            flaff = !flaff;
            miniMenuPanel.SetActive(flaff);
            flagM = 0;
            Time.timeScale = 0;
        }

        if (!miniMenuPanel.activeSelf && !diedScreen.activeSelf)
        {
            flagM = 1;
            Time.timeScale = 1;
        }



    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void goToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
