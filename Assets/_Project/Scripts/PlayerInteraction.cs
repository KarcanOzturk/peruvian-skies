using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] float range = 3f;
    [SerializeField] LayerMask mask = ~0;
    [SerializeField] TextMeshProUGUI promptText;

    IInteractable current;

    void Update()
    {
        var ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, range, mask, QueryTriggerInteraction.Ignore))
        {
            current = hit.collider.GetComponentInParent<IInteractable>();
            if (current != null)
            {
                if (promptText) { promptText.text = current.GetPrompt(); promptText.alpha = 1f; }
                if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
                    current.Interact();
                return;
            }
        }

        current = null;
        if (promptText) promptText.alpha = 0f;
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * range);
    }
#endif
}
