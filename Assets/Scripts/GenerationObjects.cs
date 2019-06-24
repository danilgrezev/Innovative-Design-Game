using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationObjects : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }
    IEnumerator EnemyDrop()
    {
        while (enemyCount < 50)
        {
            var maxx = GameController.hei;
            var maxz = GameController.hai;
            xPos = Random.Range(5, maxz*3);//чтобы у
            zPos = Random.Range(5, maxx*3);
            Instantiate(theEnemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
