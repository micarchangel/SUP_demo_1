using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingScreen : MonoBehaviour
{
    [Header("Настройки загрузки")]
    [SerializeField] private string[] scenesToLoad; // Сцены для загрузки
    [SerializeField] private float minLoadTime = 2f; // Минимальное время загрузки (для плавности)

    [Header("UI элементы")]
    [SerializeField] private Slider progressBar; // Слайдер прогресса
    [SerializeField] private Text progressText; // Текст прогресса
    [SerializeField] private GameObject loadingScreen; // Родительский объект загрузочного экрана

    private AsyncOperation loadingOperation;
    private float loadingProgress;
    private float timeElapsed;

    public void LoadScenes()
    {
        StartCoroutine(LoadScenesAsync());
    }

    private IEnumerator LoadScenesAsync()
    {
        // Активируем загрузочный экран
        loadingScreen.SetActive(true);
        progressBar.value = 0f;
        progressText.text = "0%";
        timeElapsed = 0f;

        // Начинаем загрузку всех сцен (первая будет активной)
        for (int i = 0; i < scenesToLoad.Length; i++)
        {
            if (i == 0)
                loadingOperation = SceneManager.LoadSceneAsync(scenesToLoad[i], LoadSceneMode.Single);
            else
                loadingOperation = SceneManager.LoadSceneAsync(scenesToLoad[i], LoadSceneMode.Additive);

            loadingOperation.allowSceneActivation = false;

            // Ждем завершения загрузки
            while (!loadingOperation.isDone)
            {
                timeElapsed += Time.deltaTime;

                // Рассчитываем прогресс (0-0.9, так как 1.0 - это активация сцены)
                loadingProgress = Mathf.Clamp01(loadingOperation.progress / 0.9f);

                // Обновляем UI
                UpdateProgressUI();

                // Ждем минимум указанное время и 90% загрузки
                if (loadingOperation.progress >= 0.9f && timeElapsed >= minLoadTime)
                {
                    loadingOperation.allowSceneActivation = true;
                }

                yield return null;
            }
        }
    }

    private void UpdateProgressUI()
    {
        // Можно добавить сглаживание прогресса
        float displayedProgress = Mathf.Lerp(progressBar.value, loadingProgress, Time.deltaTime * 5f);
        displayedProgress = Mathf.Clamp01(displayedProgress);

        progressBar.value = displayedProgress;
        progressText.text = Mathf.Round(displayedProgress * 100) + "%";
    }
}