using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class noMouse : MonoBehaviour
{
    bool isLocked;
    // Start is called before the first frame update
    void Start()
    {
        SetCursorLock(true);
    }

   public void SetCursorLock(bool isLocked)
    {
        Debug.Log("noMouse");
        this.isLocked = isLocked;
        Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
    }
    // Update is called once per frame
    void Update()
    {
       if( Input.GetKeyDown(KeyCode.Tab))
        {
            SetCursorLock(!isLocked);
        }
    }
}
