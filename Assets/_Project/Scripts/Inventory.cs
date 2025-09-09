using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }
    HashSet<string> items = new HashSet<string>();

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        // İstersen sahneler arası kalıcı olsun:
        // DontDestroyOnLoad(gameObject);
    }

    public bool Has(string item) => items.Contains(item);
    public void Add(string item)
    {
        if (string.IsNullOrWhiteSpace(item)) return;
        items.Add(item);
        Debug.Log($"Envantere eklendi: {item}");
    }
    public bool Remove(string item) => items.Remove(item);
}
