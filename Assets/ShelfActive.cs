using UnityEngine;
using System;
public class ShelfActive : MonoBehaviour
{
    public static event Action<bool> OnTriggerInventory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInParent<Outline>().enabled = true;
        
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnTriggerInventory?.Invoke(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInParent<Outline>().enabled = false;
        }
    }
}
