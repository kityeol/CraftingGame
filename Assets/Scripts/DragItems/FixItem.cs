using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FixItem : MonoBehaviour, IDropHandler
{
    public GameObject exclamation;
    public string nameofItem;
    public Sprite ItemToFix;
    public Button nextScreen;
    // Start is called before the first frame update
    void Start()
    {
        nextScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        if (GameManager.Instance.draggingItem.name == nameofItem)
        {
            GameManager.Instance.RemoveFromInventory(GameManager.Instance.draggingItem);
            GetComponent<Image>().sprite = ItemToFix;
            nextScreen.enabled = true;
            Invoke("Destroy", 1);
        }
    }

    private void Destroy()
    {
        Destroy(exclamation);
    }
}