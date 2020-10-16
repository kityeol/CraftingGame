using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;


public class Trash : MonoBehaviour, IDropHandler
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
    }
}
