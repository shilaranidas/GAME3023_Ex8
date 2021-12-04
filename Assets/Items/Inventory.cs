using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    string playerPrefsKey = "";
    List<ItemSlot> itemSlots = new List<ItemSlot>();

    [SerializeField]
    ItemTable itemTable;

    [SerializeField]
    GameObject inventoryPanel;


    void Start()
    {
        itemTable.AssignItemIDs();
        playerPrefsKey = gameObject.name + "Inventory"; //Not perfectly safe, but more or less ok

        GameSaver.OnSaveEvent.AddListener(SaveInventory);
        GameSaver.OnLoadEvent.AddListener(LoadInventory);

        //Read all itemSlots as children of inventory panel
        int numItemSlots = inventoryPanel.transform.childCount;
        for(int i = 0; i < numItemSlots; i++)
        {
            itemSlots.Add(inventoryPanel.transform.GetChild(i).GetComponent<ItemSlot>());
        }
    }

    //Go through all itemSlots, if they have an item, save their ID and count using PlayerPrefs
    void SaveInventory()
    {
        // Pack all items and counts into one long string
        // ItemID1, ItemCount1, ItemID2, ItemCount2, ItemID3... etc.
        string inventorySaveString = "";

        // For each item slot, encode it into two values to append to inventorySaveString
        for(int i = 0; i < itemSlots.Count; i++)
        {
            string id = "-1"; // -1 means no item
            string count = "0";

            ItemSlot slot = itemSlots[i];
            if(slot.itemInSlot != null)
            {
                id = slot.itemInSlot.Id.ToString();
                count = slot.ItemCount.ToString();
            }

            //Append to the string with our new information
            inventorySaveString += id + "," + count + ",";
        }

        PlayerPrefs.SetString(playerPrefsKey, inventorySaveString);
        Debug.Log("Inventory Saved!");
    }

    //Go through all itemSlots, read their ID and count using PlayerPrefs
    void LoadInventory()
    {
        if(!PlayerPrefs.HasKey(playerPrefsKey))
        {
            Debug.Log("Inventory: No save data?");
            return;
        }

        string loadedString = PlayerPrefs.GetString(playerPrefsKey, "");
        // Break the string down into pairs

        //Parse strings into ints
        char[] delimiters = { ',' };
        string[] itemDataStrings = loadedString.Split(delimiters);

        for (int i = 0; i < itemSlots.Count; i++)
        {
            int id =    int.Parse(itemDataStrings[(2 * i) + 0]);
            int count = int.Parse(itemDataStrings[(2 * i) + 1]);

            if (id >= 0)
            {
                itemSlots[i].itemInSlot = itemTable.GetItemFromID(id);
                itemSlots[i].ItemCount = count;
            } else
            {
                itemSlots[i].itemInSlot = null;
            }
            itemSlots[i].RefreshInfo();
        }

        Debug.Log("Inventory Loaded: " + loadedString);
    }

}
