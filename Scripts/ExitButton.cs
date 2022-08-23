using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("Submit"))
        {
            Application.Quit();
            Debug.Log("hahah");
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
