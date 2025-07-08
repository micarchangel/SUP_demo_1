using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour
{
    public enum MenuState
    {
        Hidden,         // Все меню скрыты
        MainMenu,       // Открыто главное меню
        Settings,       // Открыты настройки
        Sounds,
        About,          // Открыто "Об игре"
        CharacterSelect // Открыт выбор персонажа (но его мы не программируем)
    }

    [Header("Панели меню")]
    [SerializeField] private RectTransform mainMenuPanel;
    [SerializeField] private RectTransform settingsPanel;
    [SerializeField] private RectTransform aboutPanel;
    [SerializeField] private RectTransform soundPanel;

    [Header("Кнопки")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button aboutButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button soundButton;
    [SerializeField] private Button soundBackButton;
    [SerializeField] private Button settingsBackButton;
    [SerializeField] private Button aboutBackButton;
    [SerializeField] private Button characterSelectBackButton;

    [Header("Позиции")]
    [SerializeField] private Vector2 offScreenRightPos;
    [SerializeField] private Vector2 centerPos;

    [Header("Настройки анимации")]
    [SerializeField] private float transitionDuration = 0.01f;
    [SerializeField] private AnimationCurve easeCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    private MenuState currentState = MenuState.Hidden;
    private bool isTransitioning;

    private void Awake()
    {
        // Инициализация позиций
        mainMenuPanel.anchoredPosition = offScreenRightPos;
        settingsPanel.anchoredPosition = offScreenRightPos;
        aboutPanel.anchoredPosition = offScreenRightPos;
        soundPanel.anchoredPosition = offScreenRightPos;

        // Подписка на кнопки
        startButton.onClick.AddListener(() => StartCoroutine(TransitionToState(MenuState.CharacterSelect)));
        settingsButton.onClick.AddListener(() => StartCoroutine(TransitionToState(MenuState.Settings)));
        aboutButton.onClick.AddListener(() => StartCoroutine(TransitionToState(MenuState.About)));
        soundButton.onClick.AddListener(() => StartCoroutine(TransitionToState(MenuState.Sounds)));
        exitButton.onClick.AddListener(OnExitClicked);
        settingsBackButton.onClick.AddListener(() => StartCoroutine(TransitionToState(MenuState.MainMenu)));
        aboutBackButton.onClick.AddListener(() => StartCoroutine(TransitionToState(MenuState.MainMenu)));
        soundBackButton.onClick.AddListener(() => StartCoroutine(TransitionToState(MenuState.Settings)));
        characterSelectBackButton.onClick.AddListener(() => StartCoroutine(TransitionToState(MenuState.MainMenu)));

    }

    private void Start()
    {
        StartCoroutine(TransitionToState(MenuState.MainMenu));
    }

    private IEnumerator TransitionToState(MenuState newState)
    {
        if (isTransitioning) yield break;
        isTransitioning = true;

        // Запускаем анимацию скрытия текущего состояния
        yield return HandleExitAnimation(currentState);

        // Меняем состояние
        currentState = newState;

        // Запускаем анимацию входа нового состояния
        yield return HandleEnterAnimation(newState);

        isTransitioning = false;
    }

    private IEnumerator HandleEnterAnimation(MenuState state)
    {
        switch (state)
        {
            case MenuState.MainMenu:
                yield return MovePanel(mainMenuPanel, centerPos);
                break;

            case MenuState.Settings:
                yield return MovePanel(settingsPanel, centerPos);
                break;

            case MenuState.Sounds:
                yield return MovePanel(soundPanel, centerPos);
                break;

            case MenuState.About:
                yield return MovePanel(aboutPanel, centerPos);
                break;
        }
    }

    private IEnumerator HandleExitAnimation(MenuState state)
    {
        switch (state)
        {
            case MenuState.MainMenu:
                yield return MovePanel(mainMenuPanel, offScreenRightPos);
                break;

            case MenuState.Settings:
                yield return MovePanel(settingsPanel, offScreenRightPos);
                break;

            case MenuState.Sounds:
                yield return MovePanel(soundPanel, offScreenRightPos);
                break;

            case MenuState.About:
                yield return MovePanel(aboutPanel, offScreenRightPos);
                break;
        }
    }

    private IEnumerator MovePanel(RectTransform panel, Vector2 targetPos)
    {
        Vector2 startPos = panel.anchoredPosition;
        float elapsed = 0f;

        while (elapsed < transitionDuration)
        {
            elapsed += Time.deltaTime;
            float t = easeCurve.Evaluate(elapsed / transitionDuration);
            panel.anchoredPosition = Vector2.Lerp(startPos, targetPos, t);
            yield return null;
        }

        panel.anchoredPosition = targetPos;
    }

    private void OnExitClicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}