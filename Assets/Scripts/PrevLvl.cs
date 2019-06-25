using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrevLvl : MonoBehaviour
{
    public int scen = SceneManager.GetActiveScene().buildIndex;
    //public string playerTag;
    public void OnTriggerStay(Collider other)
    {
        Debug.Log("In Trigg");
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(scen - 1);

        }
    }
}
