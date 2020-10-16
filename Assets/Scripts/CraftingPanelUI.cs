using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class CraftingPanelUI : MonoBehaviour
{
    public Sprite emptyBox;
    public static CraftingPanelUI Instance;

    public int item1Index;
    // Start is called before the first frame update
    public Item item1;
    public Item item2;
    public Item resultingItem;

    public Item ash;

    public Image image1;
    public Image image2;
    public Image imageResult;

    public List<Recipe> recipes;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

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

    public void SetItem(Item item, int index)
    {
        if(index == item1Index)
        {
            return;
        }
        if(item1 == null)
        {
            item1Index = index;
            item1 = item;
            image1.sprite = item1.sprite;
        }
        else if(item2 == null)
        {
            item2 = item;
            image2.sprite = item2.sprite;
            //TODO: Check if the recipe exists!
            CheckRecipeBook();
        }
    }

    private void CheckRecipeBook()
    {
        resultingItem = null;
        foreach(Recipe recipe in recipes)
        {
            if( (recipe.item1 == item1 && recipe.item2 == item2) || (recipe.item1 == item2 && recipe.item2 == item1) )
            {
                print("RECIPE FOUND!");
                resultingItem = recipe.result;
                imageResult.sprite = recipe.result.sprite;
                break;
            }
        }
        if(resultingItem == null)
        {
            resultingItem = ash;
            imageResult.sprite = resultingItem.sprite;
        }
    }

    public void CraftItem()
    {
        GameManager.Instance.RemoveFromInventory(item1);
        GameManager.Instance.RemoveFromInventory(item2);
        GameManager.Instance.AddItemToInventory(resultingItem);
        gameObject.SetActive(false);
        image1.sprite = emptyBox;
        image2.sprite = emptyBox;
        imageResult.sprite = emptyBox;
        item1 = null;
        item1Index = -1;
        item2 = null;

    }

    public void ReturnItems()
    {
        if(item1 != null && item2==null)
        {
            item1 = null;
            item1Index = -1;
            GameManager.Instance.RefreshInventory();
            image1.sprite = emptyBox;
        }
    }
}