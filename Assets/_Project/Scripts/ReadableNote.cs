using UnityEngine;

public class ReadableNote : MonoBehaviour, IInteractable
{
    [SerializeField] string noteTitle = "Not";
    [TextArea(4, 10)]
    [SerializeField] string noteBody = "Soğuk bir rüzgar kapı aralığından içeri süzülüyor...";
    [SerializeField] NoteUI noteUI; // NotePanel'deki NoteUI bileşenini bağlayacağız

    public string GetPrompt() => "Notu oku (E)";

    public void Interact()
    {
        if (noteUI != null) noteUI.Show(noteTitle, noteBody);
        else Debug.LogWarning("NoteUI referansı eksik!");
    }
}
