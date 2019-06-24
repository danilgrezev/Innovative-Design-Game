using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerationObjects : MonoBehaviour
{    
    public GameObject theEnemy;
    public GameObject theEnemy1;
    public GameObject theEnemy2;
    public GameObject theEnemy3;
    public int xPos;
    public int zPos;
    public int enemyCount;
    // Start is called before the first frame updates
    void Start()
    {
        StartCoroutine(EnemyDrop());
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
            Instantiate(theEnemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
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
            Instantiate(theEnemy1, new Vector3(xPos, 1, zPos), Quaternion.identity);
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
            Instantiate(theEnemy2, new Vector3(xPos, 1, zPos), Quaternion.identity);
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
            Instantiate(theEnemy3, new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
