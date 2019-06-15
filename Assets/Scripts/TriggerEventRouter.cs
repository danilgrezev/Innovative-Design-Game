using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void TriggerEventHandler(GameObject trigger, GameObject other);
//public delegate void LoadLvlHandler(Collider other);

public class TriggerEventRouter : MonoBehaviour
{
    public TriggerEventHandler callback;
    //public LoadLvlHandler loadLvl;
    public int scen = int.Parse(SceneManager.GetActiveScene().name);
    public int scenNext;
    public int scenPrev;
    
    void OnTriggerEnter(Collider other)
    {
        if (callback != null)
        {
            callback(this.gameObject, other.gameObject);
            
        }        

    }
    public void OnTriggerStay(Collider other)
    {
        
        scenNext = scen + 1;
        scenPrev = scen - 1;
        Debug.Log("scen"+scen);
        Debug.Log("next"+scenNext);
        Debug.Log("prev"+scenPrev);
        Debug.Log("In Trigg");
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && scen <= 1)
            {
                Debug.Log("E");
                SceneManager.LoadScene(scenNext + 1);
                scen++;
            }
           
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Q");
                SceneManager.LoadScene(scenPrev +2);
            }





            
        }
    }

}

//public delegate void TriggerEventHandler(GameObject trigger, GameObject other);

//public class TriggerEventRouter : MonoBehaviour
//{
//    public TriggerEventHandler callback;

//    void OnTriggerEnter(Collider other)
//    {
//        if (callback != null)
//        {
//            callback(this.gameObject, other.gameObject);
//        }
//    }


//}
