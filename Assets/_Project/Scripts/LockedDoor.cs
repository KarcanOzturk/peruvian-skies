using UnityEngine;

public class LockedDoor : MonoBehaviour, IInteractable
{
    [Header("Lock")]
    [SerializeField] string requiredItemName = "Anahtar";
    [SerializeField] string lockedText = "Kilitli — Anahtar gerekli";

    [Header("Animation")]
    [SerializeField] float openAngle = 90f;
    [SerializeField] float speed = 6f;

    bool isOpen = false;
    bool animBusy = false;
    Quaternion closedRot;
    Quaternion openRot;

    void Awake()
    {
        closedRot = transform.localRotation;
        openRot = Quaternion.Euler(transform.localEulerAngles + new Vector3(0, openAngle, 0));
    }

    bool HasKey() => Inventory.Instance != null && Inventory.Instance.Has(requiredItemName);

    public string GetPrompt()
    {
        if (!HasKey() && !isOpen) return lockedText;
        return isOpen ? "Kapıyı kapat (E)" : "Kapıyı aç (E)";
    }

    public void Interact()
    {
        if (!HasKey() && !isOpen) { Debug.Log("Kapı kilitli: Anahtar yok"); return; }
        if (animBusy) return;

        StopAllCoroutines();
        StartCoroutine(RotateDoor(isOpen ? openRot : closedRot, isOpen ? closedRot : openRot));
        isOpen = !isOpen;
    }

    System.Collections.IEnumerator RotateDoor(Quaternion from, Quaternion to)
    {
        animBusy = true;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * speed;
            transform.localRotation = Quaternion.Slerp(from, to, t);
            yield return null;
        }
        animBusy = false;
    }
}
