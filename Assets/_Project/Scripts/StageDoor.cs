using UnityEngine;

public class StageDoor : MonoBehaviour, IInteractable
{
    [Header("Gereken eşyalar (hepsi olmalı)")]
    [SerializeField] string[] requiredItems;
    [SerializeField] string lockedText = "Kilitli — Gerekenler eksik";

    [Header("Animasyon")]
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

    bool HasAllRequirements()
    {
        if (requiredItems == null || requiredItems.Length == 0) return true;
        if (Inventory.Instance == null) return false;

        foreach (var item in requiredItems)
            if (!Inventory.Instance.Has(item)) return false;

        return true;
    }

    public string GetPrompt()
    {
        if (!isOpen && !HasAllRequirements()) return lockedText;
        return isOpen ? "Kapıyı kapat (E)" : "Kapıyı aç (E)";
    }

    public void Interact()
    {
        if (!isOpen && !HasAllRequirements()) return;
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
