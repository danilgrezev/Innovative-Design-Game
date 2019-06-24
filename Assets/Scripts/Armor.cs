using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Armor : MonoBehaviour
{
    public int maxArm;
    public int arm;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        maxArm = 100;
        arm = maxArm;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = arm;
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

    }
}
