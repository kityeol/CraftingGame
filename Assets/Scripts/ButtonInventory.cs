using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonInventory : MonoBehaviour, IDragHandler, IEndDragHandler
{
    bool isDragging = false;
    private Vector3 startingPos;
    public int inventoryIndex;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        if(GameManager.Instance.GetItemAt(inventoryIndex) == null)
        {
            return;
        }

        GameManager.Instance.draggingItem = GameManager.Instance.GetItemAt(inventoryIndex);
        isDragging = true;
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameManager.Instance.draggingItem = null;
        isDragging = false;
        transform.position = startingPos;
    }

    public void ButtonPressed()
    {
        if (!isDragging)
        {
            GameManager.Instance.craftingPanel.SetActive(true);
            Item item = GameManager.Instance.GetItemAt(inventoryIndex);
            if (CraftingPanelUI.Instance)
            {
                CraftingPanelUI.Instance?.SetItem(item, inventoryIndex);
                GetComponent<Image>().sprite = GameManager.Instance.emptySprite;
            }
        }
    }
}