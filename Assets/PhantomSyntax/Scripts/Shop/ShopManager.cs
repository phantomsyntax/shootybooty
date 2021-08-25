using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header("Shop Button Settings")]
    // TODO: refactor this whole thing by using a dictionary instead; populate from SO..
    [SerializeField] private GameObject[] shopButtons;
                     private GameObject targetButton;
                     private GameObject tempSelect;

    [Header("Shop Item Description Settings")]
    [SerializeField] private GameObject itemName;
    [SerializeField] private GameObject itemDescription;

    private void Start()
    {
        NullChecks();

        ButtonInit();
    }

    private void NullChecks()
    {
        if (shopButtons.Length < 1)
        {
            Debug.LogWarning("[ShopManager] - No shopButtons were added to the array!");
        }
    }

    private void ButtonInit()
    {
        for (int buttonIndex = 0; buttonIndex < shopButtons.Length; buttonIndex++)
        {
            // TODO: this was just a test, please to refactor
            // This turns the quad mesh highlight on each shop 'button' off
            shopButtons[buttonIndex].transform.Find("UpgradeSelection").gameObject.SetActive(false);
            itemName.GetComponent<TextMesh>().text = string.Empty;
            itemDescription.GetComponent<TextMesh>().text = string.Empty;
        }
    }

    private void Update()
    {
        SelectButton();
    }

    private void SelectButton()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitObject;
            targetButton = ReturnObject(out hitObject);
            if (targetButton && targetButton.transform.Find("UpgradeText"))
            {
                // Clear previous selection and activate new one
                ButtonInit();
                Activate();
                UpdateInfo(targetButton);
            }
        }
    }

    private GameObject ReturnObject(out RaycastHit raycastHit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction * 100, out raycastHit))
        {
            target = raycastHit.collider.gameObject;
        }
        return target;
    }

    private void Activate()
    {
        tempSelect = targetButton.transform.Find("UpgradeSelection").gameObject;
        tempSelect.SetActive(true);
    }

    private void UpdateInfo(GameObject targetButton)
    {
        itemName.GetComponent<TextMesh>().text = targetButton.GetComponent<ShopItem>().ShopObject.itemName;
        itemDescription.GetComponent<TextMesh>().text = targetButton.GetComponent<ShopItem>().ShopObject.itemDescription;
    }
}