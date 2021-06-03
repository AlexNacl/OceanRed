using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVController : MonoBehaviour
{
    public GameObject Left;
    public GameObject Right;
    public static bool DisabledLeft = false;
    public static bool DisabledRight = false;
    public static bool DisabledUp = false;
    
    void Update()
    {
        if (DisabledLeft)
        {
            Left.SetActive(false);
        } else {
            Left.SetActive(true);
        }
        if (DisabledRight)
        {
            Right.SetActive(false);
        } else {
            Right.SetActive(true);
        }
    }
}
