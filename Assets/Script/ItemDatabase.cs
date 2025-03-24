using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemDatabase", menuName = "NewItemDatabase")]
public class ItemDatabase : ScriptableObject
{
    public List<ItemData> itemList = new List<ItemData>();
}
