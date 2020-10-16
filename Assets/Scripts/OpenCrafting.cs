using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCrafting : MonoBehaviour
{
    bool isClosed;
    public GameObject craftMenu;

    public void OpenCloseCraft()
    {
        if (isClosed == true)
        {
            craftMenu.SetActive(true);
            isClosed = false;
        }
        else
        {
            craftMenu.SetActive(false);
            isClosed = true;
        }
    }
}
