public interface IInteractable
{
    string GetPrompt();  // Ekranda gösterilecek metin (örn: "Kapıyı aç (E)")
    void Interact();     // Oyuncu E'ye basınca ne olacak?
}
