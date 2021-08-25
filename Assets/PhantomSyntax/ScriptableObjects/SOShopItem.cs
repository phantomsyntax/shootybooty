using UnityEngine;

[CreateAssetMenu(fileName = "NewShopItem", menuName = "Items/New Shop Item")]
public class SOShopItem : ScriptableObject
{
    [Header("Shop Item Settings")]
                     public Sprite itemIcon;
                     public string itemName;
                     public string itemDescription;
                     public string itemCost;
}