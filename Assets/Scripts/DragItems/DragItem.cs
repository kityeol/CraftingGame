using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IDropHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameManager.Instance.RemoveFromInventory(GameManager.Instance.draggingItem);
        Invoke("Destroy", 1);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}