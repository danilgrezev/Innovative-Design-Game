using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//public delegate void LoadLvl
public class LoadLvl : MonoBehaviour
{    
    public int scen = int.Parse(SceneManager.GetActiveScene().name);
    //public string playerTag;
    public void OnTriggerStay(Collider other)
    {
        Debug.Log(scen);
        Debug.Log("In Trigg");
        if(other.tag == "Player")
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E");
                SceneManager.LoadScene(scen + 1);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Q");
                SceneManager.LoadScene(scen - 1);
            }
        }
    }
}
