using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
   
    public int Attack;
    public int AddHealth;
    public int AddBron;
    public int Point;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            col.GetComponent<Windows>().hp -= Attack;
            col.GetComponent<Windows>().hp += AddHealth;
            col.GetComponent<Windows>().arm += AddBron;
        }
    }
}
