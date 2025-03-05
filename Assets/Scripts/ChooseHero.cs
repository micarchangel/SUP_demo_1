using UnityEngine;
using UnityEngine.UI;

public class ChooseHero : MonoBehaviour
{
    public GameObject[] characterModels;
    public Button[] characterButtons;

    private int selectedCharacterIndex = 0;

    void Start()
    {
        UpdateCharacterDisplay();

        for (int i = 0; i < characterButtons.Length; i++)
        {
            int index = i;
            characterButtons[i].onClick.AddListener(() => OnCharacterButtonClick(index));
        }
    }

    void OnCharacterButtonClick(int index)
    {
        selectedCharacterIndex = index;
        UpdateCharacterDisplay();
    }

    void UpdateCharacterDisplay()
    {
        foreach (GameObject model in characterModels)
        {
            model.SetActive(false);
        }
        characterModels[selectedCharacterIndex].SetActive(true);
    }

}
