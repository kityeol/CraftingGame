using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Hint : MonoBehaviour
{
    bool isClosed;
    bool OnScreen = true;
    public GameObject hint;
    public string itemName;
    public Text numberOfItems;

    private void Update()
    {
        var items = GameManager.Instance.inventory.FindAll(x => x.name == itemName);
        numberOfItems.text = items.Count.ToString() + "/1";
    }

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
            numberOfItems.text = "";
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

    public void DestroyHint()
    {
        hint.SetActive(false);
        OnScreen = false;
        numberOfItems.text = "";
        Destroy(this);
    }
}