using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable
{
    [SerializeField] string itemName = "Anahtar";
    [SerializeField] bool destroyOnPickup = true;

    public string GetPrompt() => $"{itemName} al (E)";

    public void Interact()
    {
        Debug.Log($"Aldın: {itemName}");
        if (destroyOnPickup)
        {
            Destroy(gameObject);
        }
        else
        {
            var col = GetComponent<Collider>();
            if (col) col.enabled = false;
            var rend = GetComponentInChildren<Renderer>();
            if (rend) rend.enabled = false;
        }
    }
}
