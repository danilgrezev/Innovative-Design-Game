using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Windows : MonoBehaviour
{
    bool isLocked;
    public GameObject Player;
    public GameObject diedScreen;
    public GameObject miniMenuPanel;

   // public int maxHp;
    public int hp;
    

   // public int maxArm;
    public int arm;
    public Slider sliderArm;
    public Slider sliderHp;

    int start = 0;
    // Start is called before the first frame update
    void Start()
    {

        //maxArm = 100;
        arm = 100;

        //maxHp = 100;
        hp = 100;

        SetCursorLock(true);

        start++;

    }
    public void SetCursorLock(bool isLocked)
    {
        Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
    }
    // Update is called once per frame
    void Update()
    {
        sliderHp.value = hp;

        //if (theEnemy.tag == "Health" && Player.transform.position == theEnemy.transform.position)
        //{
        //    hp += 15;
        //    Debug.Log(hp);
        //}
        if (Input.GetKeyDown(KeyCode.H))
        {
            hp -= 20;
        }
        //if (hp > maxHp)
        //{
        //    hp = maxHp;
        //}
        if (Player.transform.position.y < -3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        if (hp <= 0)
        {
            hp = 0;
            SetCursorLock(isLocked);
            diedScreen.SetActive(true);

        }


        sliderArm.value = arm;
        if (Input.GetKeyDown(KeyCode.G))
        {
            arm -= 30;
        }
        //if (arm > maxArm)
        //{
        //    arm = maxArm;
        //}
        if (arm < 0)
        {
            arm = 0;
        }
        int esc = 0;
        if (Input.GetKeyDown(KeyCode.Escape) && esc == 0)
        {
            esc++;
            SetCursorLock(isLocked);
            miniMenuPanel.SetActive(!miniMenuPanel.activeSelf);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && esc > 0)
        {
            esc = 0;
            SetCursorLock(!isLocked);
            miniMenuPanel.SetActive(miniMenuPanel.activeSelf);
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
