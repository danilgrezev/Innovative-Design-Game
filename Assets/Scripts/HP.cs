using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    public int maxHp;
    public int hp;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        maxHp = 100;
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = hp;
        if (Input.GetKeyDown(KeyCode.H))
        {
            hp -= 20;
        }
        if( hp > maxHp)
        {
            hp = maxHp;
        }
        if (transform.position.y < 0)
        {
            hp = 0;
        }
        if ( hp <= 0)
        {
            hp = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

    }
}
