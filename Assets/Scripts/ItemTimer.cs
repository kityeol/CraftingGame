using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class ItemTimer : MonoBehaviour
{
    private bool success = false;
    public Item itemToGet;
    public Image inventoryImage;
    //public Image myImage;
    public Image timer;

    public float timeTillRegen = 10;
    public float maxTimeRegen;

    public Sprite treeResourceReady;
    public Sprite treeResourceDepleted;

    public ItemType itemType;

    // Start is called before the first frame update
    void Start()
    {
        maxTimeRegen = timeTillRegen;
        timeTillRegen = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (success == true)
        {
            timeTillRegen -= Time.deltaTime;
        }
        timer.fillAmount = timeTillRegen / maxTimeRegen;
        if (timeTillRegen <= 0)
        {
            //myImage.sprite = treeResourceReady;
            success = false;
        }
    }

    public void TEST_BUTTON_PRESS()
    {
        if (success == false)
        {
            success = GameManager.Instance.AddItemToInventory(itemToGet);
            if (success == true)
            {
                timeTillRegen = maxTimeRegen;
                //Destroy(this.gameObject);
                //myImage.sprite = treeResourceDepleted;
            }
            else
            {
                print("you can't get anything from this stump!");
            }
        }
    }
}