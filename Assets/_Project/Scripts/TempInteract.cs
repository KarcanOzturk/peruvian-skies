using UnityEngine;

public class TempInteract : MonoBehaviour, IInteractable
{
    public string GetPrompt() => "Etkileş (E)";
    public void Interact()
    {
        Debug.Log("Etkileşim çalıştı!");
    }
}
