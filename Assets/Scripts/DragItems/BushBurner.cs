using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class BushBurner : MonoBehaviour, IDropHandler
{
    public GameObject exclamation;
    public string nameofItem;
    public Sprite burningBush;
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
            GetComponent<Image>().sprite = burningBush;
            nextScreen.enabled = true;
            Invoke("Destroy", 1);
            Invoke("DestroyExclamation", 1);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void DestroyExclamation()
    {
        Destroy(exclamation);
    }
}