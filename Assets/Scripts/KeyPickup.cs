using UnityEngine;
using System.Collections;

public class KeyPickup : MonoBehaviour
{
    public string keyName = "HouseKey";
    [Tooltip("Задержка до фактического подъёма (сек) — подстраивай под длительность анимации)")]
    public float pickupDelay = 0.8f;

    private bool playerInside = false;
    private PlayerInventory playerInventory;
    private bool isPickingUp = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            playerInventory = other.GetComponent<PlayerInventory>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            playerInventory = null;
        }
    }

    private void Update()
    {
        if (!isPickingUp && playerInside && playerInventory != null && Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(PickupCoroutine());
        }
    }

    private IEnumerator PickupCoroutine()
    {
        isPickingUp = true;

        yield return new WaitForSeconds(pickupDelay);

        playerInventory.AddKey(keyName);
        Debug.Log("Ключ поднят: " + keyName);
        Destroy(gameObject);
    }
}
