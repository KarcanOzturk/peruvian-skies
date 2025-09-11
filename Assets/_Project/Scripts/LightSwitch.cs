using UnityEngine;

public class LightSwitch : MonoBehaviour, IInteractable
{
    [SerializeField] Light targetLight;              // Lamp01 altında Point Light'ı buraya bağlayacağız
    [SerializeField] string onText = "Işığı kapat (E)";
    [SerializeField] string offText = "Işığı aç (E)";

    public string GetPrompt()
    {
        bool isOn = targetLight != null && targetLight.enabled;
        return isOn ? onText : offText;
    }

    public void Interact()
    {
        if (targetLight == null) { Debug.LogWarning("LightSwitch: targetLight bağlanmamış."); return; }
        targetLight.enabled = !targetLight.enabled;
    }
}
