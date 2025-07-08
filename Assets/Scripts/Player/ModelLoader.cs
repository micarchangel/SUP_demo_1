using UnityEngine;

public class ModelLoader : MonoBehaviour
{
    public GameObject[] models;
    public string playerPrefsKey = "SelectedModelIndex";

    void Start()
    {
        int selectedIndex = PlayerPrefs.HasKey(playerPrefsKey) ? PlayerPrefs.GetInt(playerPrefsKey) : 0;

        for (int i = 0; i < models.Length; i++)
        {
            models[i].SetActive(i == selectedIndex);
        }
    }
}