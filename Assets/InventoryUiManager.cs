using UnityEngine;

public class InventoryUiManager : MonoBehaviour
{
    public GameObject storeInventoryUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            storeInventoryUI.SetActive(!storeInventoryUI.activeSelf);
        }
    }
    private void OnEnable()
    {
        //ShelfActive.OnTriggerInventory += HandleInventoryShelf;
    }
    private void OnDisable()
    {
        //ShelfActive.OnTriggerInventory -= HandleInventoryShelf;
    }
    private void HandleInventoryShelf(bool isActive)
    {
        if (isActive)
        {
            transform.GetChild(0).gameObject.SetActive(isActive);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(isActive);

        }
    }



}
