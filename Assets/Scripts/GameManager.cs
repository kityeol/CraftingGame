using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Item draggingItem = null;
    public static GameManager Instance;
    public Sprite emptySprite;
    public List<Item> inventory;
    public GameObject craftingPanel;
    public Image[] itemImages;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AddItemToInventory(Item item)
    {
        if(inventory.Count >= 4)
        {
            print("YOU HAVE TOO MANY ITEMS!");
            return false;
        }
        else
        {
            inventory.Add(item);
            RefreshInventory();
            //itemImages[inventory.IndexOf(item)].sprite = item.sprite;
            return true;
        }
        
    }

    public void RefreshInventory()
    {
            for (int i = 0; i < itemImages.Length; i++)
            {
                if (i < inventory.Count)
                {
                    itemImages[i].sprite = inventory[i].sprite;
                }
                else
                {
                    itemImages[i].sprite = emptySprite;
                }
            }
    }

    public Item GetItemAt(int index)
    {
        if(index >= inventory.Count)
        {
            print("ERROR! Out of bounds inventory!");
            return null;
        }
        
        return inventory[index];
    }

    public bool RemoveFromInventory(Item item)
    {
        if(inventory.Count <= 0)
        {
            print("YOU DON'T HAVE ANY ITEMS!");
            return false;
        }
        else
        {
            int index = inventory.IndexOf(item);
            //itemImages[index].sprite = emptySprite;
            inventory.Remove(item);
            for(int i = 0; i < itemImages.Length; i++)
            {
                if(i < inventory.Count)
                {
                    itemImages[i].sprite = inventory[i].sprite;
                }
                else
                {
                    itemImages[i].sprite = emptySprite;
                }
            }
            return true;
        }
    }
    
}

public enum ItemType
{
    ROCK,
    PAPER,
    WOOD,
    WATER,
    FIRE
}
