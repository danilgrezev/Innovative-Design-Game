using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GenerationObjects : MonoBehaviour
{
    bool isLocked;

    public GameObject Player;
    public GameObject PlayerCam;
    public GameObject theEnemy;
    public GameObject theEnemy1;
    public GameObject theEnemy2;
    public GameObject theEnemy3;

    public GameObject diedScreen;
    public GameObject miniMenuPanel;   

    public int maxHp;
    public int hp;
    public Slider sliderHp;

    public int maxArm;
    public int arm;
    public Slider sliderArm;

    int start = 0;

    public int xPos;
    public int zPos;
    public int enemyCount;

    private float height1 = 1.08f;
    private float height2 = 4.58f;

    // Start is called before the first frame updates
    void Start()
    {

            maxArm = 100;
            arm = maxArm;

            maxHp = 100;
            hp = maxHp;

            SetCursorLock(true);

            theEnemy.GetComponent<RealEnemy>().player = PlayerCam.transform;
            theEnemy.GetComponent<RealEnemy>().height = height1;
            theEnemy1.GetComponent<RealEnemy>().player = PlayerCam.transform;
            theEnemy1.GetComponent<RealEnemy>().height = height1;
            theEnemy2.GetComponent<RealEnemy>().player = PlayerCam.transform;
            theEnemy2.GetComponent<RealEnemy>().height = height2;
            theEnemy3.GetComponent<RealEnemy>().player = PlayerCam.transform;
            theEnemy3.GetComponent<RealEnemy>().height = height1;

            start++;
        
        StartCoroutine(EnemyDrop());
    }

    public void SetCursorLock(bool isLocked)
    {
        
       
        Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 2)
        {
            //float wallo = wall[0].transform.position;
            var maxx = GameController.hei;
            var maxz = GameController.hai;

            xPos = Random.Range(5, maxz * 3);//чтобы **у
            zPos = Random.Range(5, maxx * 3);
            Instantiate(theEnemy, new Vector3(xPos, height1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
        enemyCount = 0;
        while (enemyCount < 2)
        {
            //float wallo = wall[0].transform.position;
            var maxx = GameController.hei;
            var maxz = GameController.hai;

            xPos = Random.Range(5, maxz * 3);//чтобы **у
            zPos = Random.Range(5, maxx * 3);
            Instantiate(theEnemy1, new Vector3(xPos, height1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
        enemyCount = 0;
        while (enemyCount < 2)
        {
            //float wallo = wall[0].transform.position;
            var maxx = GameController.hei;
            var maxz = GameController.hai;

            xPos = Random.Range(5, maxz * 3);//чтобы **у
            zPos = Random.Range(5, maxx * 3);
            Instantiate(theEnemy2, new Vector3(xPos, height2, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
        enemyCount = 0;
        while (enemyCount < 2)
        {
            //float wallo = wall[0].transform.position;
            var maxx = GameController.hei;
            var maxz = GameController.hai;

            xPos = Random.Range(5, maxz * 3);//чтобы **у
            zPos = Random.Range(5, maxx * 3);
            Instantiate(theEnemy3, new Vector3(xPos, height1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(sliderHp.value);
        Debug.Log(hp);
        sliderHp.value = hp;

        if (theEnemy.tag == "Health" && Player.transform.position == theEnemy.transform.position)
        {
            hp += 15;
            Debug.Log(hp);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            hp -= 20;
        }
        if (hp > maxHp)
        {
            hp = maxHp;
        }
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
            esc++;
            SetCursorLock(isLocked);
            miniMenuPanel.SetActive(!miniMenuPanel.activeSelf);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && esc > 0)
        {
            esc=0;
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
