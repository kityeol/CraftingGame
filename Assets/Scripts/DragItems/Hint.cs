using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    bool isClosed;
    bool OnScreen = true;
    public GameObject hint;

    public void OpenCloseHint()
    {
        if (isClosed == true)
        {
            hint.SetActive(true);
            isClosed = false;
        }
        else
        {
            hint.SetActive(false);
            isClosed = true;
        }
    }

    public void CloseIntro()
    {
        if (OnScreen == true)
        {
            hint.SetActive(false);
            OnScreen = false;
        }
    }
}