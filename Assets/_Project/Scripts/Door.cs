using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] float openAngle = 90f;   // +90 sola açılır, -90 ters yöne
    [SerializeField] float speed = 6f;        // açılma hızı

    bool isOpen = false;
    bool animBusy = false;
    Quaternion closedRot;
    Quaternion openRot;

    void Awake()
    {
        closedRot = transform.localRotation;
        openRot = Quaternion.Euler(transform.localEulerAngles + new Vector3(0, openAngle, 0));
    }

    public string GetPrompt() => isOpen ? "Kapıyı kapat (E)" : "Kapıyı aç (E)";

    public void Interact()
    {
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
