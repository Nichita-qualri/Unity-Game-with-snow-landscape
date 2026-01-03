using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<string> keys = new List<string>();

    public void AddKey(string keyName)
    {
        if (!keys.Contains(keyName))
        {
            keys.Add(keyName);
            Debug.Log("Получен ключ: " + keyName);
        }
    }

    public bool HasKey(string keyName)
    {
        return keys.Contains(keyName);
    }

    public void UseKey(string keyName)
    {
        if (keys.Contains(keyName))
        {
            keys.Remove(keyName);
            Debug.Log("Использован ключ: " + keyName);
        }
    }
}
