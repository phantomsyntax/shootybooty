using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [Header("Shop Item Settings")]
    [SerializeField] private SOShopItem shopObject;
                     public SOShopItem ShopObject
                    {
                        get { return shopObject; }
                        set { shopObject = value; }
                    }

    private void Awake()
    {
        PopulateStats();
    }

    private void PopulateStats()
    {
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        TextMesh textMesh = GetComponentInChildren<TextMesh>();

        if (!spriteRenderer)
        {
            spriteRenderer.sprite = shopObject.itemIcon;
        }
        if (transform.Find("UpgradeText"))
        {
            textMesh.text = shopObject.itemCost;
        }
    }
}