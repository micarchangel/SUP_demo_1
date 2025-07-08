using UnityEngine;
using UnityEngine.UI;

public class ModelSelector : MonoBehaviour
{
    public GameObject[] models;  // Массив моделей (персонажи/транспорт и т. п.)
    public Button[] buttons;    // Кнопки выбора
    public string playerPrefsKey = "SelectedModelIndex"; // Ключ для сохранения в PlayerPrefs

    private int selectedIndex = 0;

    void Start()
    {
        // Загружаем сохранённый индекс, если есть
        if (PlayerPrefs.HasKey(playerPrefsKey))
        {
            selectedIndex = PlayerPrefs.GetInt(playerPrefsKey);
        }

        UpdateModelDisplay();

        // Назначаем обработчики кнопок
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OnModelSelected(index));
        }
    }

    void OnModelSelected(int index)
    {
        selectedIndex = index;
        PlayerPrefs.SetInt(playerPrefsKey, selectedIndex);
        PlayerPrefs.Save(); // Сохраняем изменения
        UpdateModelDisplay();
    }

    void UpdateModelDisplay()
    {
        // Отключаем все модели, включаем только выбранную
        for (int i = 0; i < models.Length; i++)
        {
            models[i].SetActive(i == selectedIndex);
        }
    }
}