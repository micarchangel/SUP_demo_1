using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChooseHeroController : MonoBehaviour
{
    public enum ChooseState
    {
        None,
        Heroes,
        Boards
    }

    [Header("Префабы моделей")]
    [SerializeField] private RectTransform heroesPref;
    [SerializeField] private RectTransform boardsPref;


    [Header("Кнопки")]
    [SerializeField] private Button heroesButton;
    [SerializeField] private Button boardsButton;


    [Header("Позиции")]
    [SerializeField] private Vector3 rightPos;
    [SerializeField] private Vector3 centerPos;
    [SerializeField] private Vector3 leftPos;

    [Header("Настройки анимации")]
    [SerializeField] private float transitionDuration = 0.5f;
    [SerializeField] private AnimationCurve easeCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    private ChooseState currentState = ChooseState.Heroes;
    private bool isTransitioning;
    private bool isMoving;

    private void Awake()
    {
        // Инициализация позиций
        heroesPref.transform.position = rightPos;
        boardsPref.transform.position = leftPos;


        // Подписка на кнопки
        heroesButton.onClick.AddListener(() => StartCoroutine(TransitionToState(ChooseState.Heroes)));
        boardsButton.onClick.AddListener(() => StartCoroutine(TransitionToState(ChooseState.Boards)));


    }

    private void Start()
    {
        StartCoroutine(TransitionToState(ChooseState.None));
    }

    private IEnumerator TransitionToState(ChooseState newState)
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

    private IEnumerator HandleEnterAnimation(ChooseState state)
    {
        switch (state)
        {
            case ChooseState.Heroes:
                yield return MovePanel(heroesPref, centerPos);
                break;

            case ChooseState.Boards:
                yield return MovePanel(boardsPref, centerPos);
                break;
        }
    }

    private IEnumerator HandleExitAnimation(ChooseState state)
    {
        switch (state)
        {
            case ChooseState.Heroes:
                yield return MovePanel(heroesPref, rightPos);
                break;

            case ChooseState.Boards:
                yield return MovePanel(boardsPref, leftPos);
                break;

        }
    }

    private IEnumerator MovePanel(Transform obj, Vector3 targetPos)
    {
        if (isMoving) yield break;
        isMoving = true;

        Vector3 startPos = obj.position;
        float elapsed = 0f;

        while (elapsed < transitionDuration)
        {
            elapsed += Time.deltaTime;
            float t = easeCurve.Evaluate(elapsed / transitionDuration);

            // Плавное перемещение по X, Y и Z
            obj.position = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }

        obj.position = targetPos;
        isMoving = false;
    }

    private void OnExitClicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}