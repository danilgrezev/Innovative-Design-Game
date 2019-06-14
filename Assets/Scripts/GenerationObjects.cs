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
        while (enemyCount < 10)
        {
            xPos = Random.Range(5, 115);
            zPos = Random.Range(5, 108);
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
