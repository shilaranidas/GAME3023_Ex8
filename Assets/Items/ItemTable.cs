using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attribute that allows us to right click->create
[CreateAssetMenu(fileName = "NewItemTable", menuName = "ItemSystem/ItemTable")]
public class ItemTable : ScriptableObject
{
    [SerializeField]
    private List<Item> table = new List<Item>();

    public void AssignItemIDs()
    { 
        for(int i = 0; i < table.Count; i++)
        {
            try
            {
                table[i].Id = i;
            } catch (ItemModifiedException)
            {
                // It's ok
                Debug.Log("Item: " + table[i].name + " assigned ID: " + i);
            }
        }
    }

    public Item GetItemFromID(int id)
    {
        return table[id];
    }
}
