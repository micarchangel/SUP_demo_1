using UnityEngine;
using UnityEngine.UI;

public class ModelSelector : MonoBehaviour
{
    public GameObject[] models;
    public Button[] buttons;

    private int selectedCharacterIndex = 0;

    void Start()
    {
        UpdateCharacterDisplay();

        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OnCharacterButtonClick(index));
        }
    }

    void OnCharacterButtonClick(int index)
    {
        selectedCharacterIndex = index;
        UpdateCharacterDisplay();
    }

    void UpdateCharacterDisplay()
    {
        foreach (GameObject model in models)
        {
            model.SetActive(false);
        }
        models[selectedCharacterIndex].SetActive(true);
    }

}
