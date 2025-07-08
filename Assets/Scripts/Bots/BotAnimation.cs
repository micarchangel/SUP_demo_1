using UnityEngine;
using System.Linq;

public class BotAnimation : MonoBehaviour
{
    [System.Serializable]
    public class CharacterSetup
    {
        public GameObject model;
        public GameObject veslo;
    }

    [SerializeField]
    private CharacterSetup[] characterSetups;

    private GameObject activeModel;
    private GameObject activeVeslo;
    private Animator animator;
    private ChangeParentVeslo vesloController;
    private Vector3 lastPosition;
    private Quaternion lastRotation;
    private float horizontalInput;
    private float verticalInput;
    private bool isMoving;

    private void Start()
    {
        InitializeRandomCharacter();
        lastRotation = transform.parent.rotation;
        lastPosition = transform.parent.position;
    }

    private void Update()
    {
        if (activeModel == null || !activeModel.activeSelf)
        {
            return;
        }

        CalculateMovementInput();
        UpdateMovementState();
        UpdateAnimatorParameters();
        UpdateLastTransform();
    }

    private void InitializeRandomCharacter()
    {
        if (characterSetups == null || characterSetups.Length == 0)
        {
            Debug.LogError("No character setups assigned!");
            return;
        }

        // Деактивируем все модели и весла
        for (int i = 0; i < characterSetups.Length; i++)
        {
            if (characterSetups[i].model != null)
            {
                characterSetups[i].model.SetActive(false);
            }
            if (characterSetups[i].veslo != null)
            {
                characterSetups[i].veslo.SetActive(false);
            }
        }

        // Выбираем случайный набор
        int randomIndex = Random.Range(0, characterSetups.Length);
        CharacterSetup selectedSetup = characterSetups[randomIndex];

        // Активируем выбранные модель и весло
        activeModel = selectedSetup.model;
        activeVeslo = selectedSetup.veslo;

        if (activeModel != null)
        {
            activeModel.SetActive(true);
            animator = activeModel.GetComponent<Animator>();
            if (animator == null)
            {
                Debug.LogWarning("No Animator component found on active model!");
            }
        }

        if (activeVeslo != null)
        {
            activeVeslo.SetActive(true);
            vesloController = activeVeslo.GetComponent<ChangeParentVeslo>();
        }
    }

    private void CalculateMovementInput()
    {
        horizontalInput = Mathf.Sign(lastRotation.y - transform.parent.rotation.y);
        verticalInput = Mathf.Sign(lastPosition.z - transform.parent.position.z);
        Debug.Log($"Movement input - H: {horizontalInput}, V: {verticalInput}");
    }

    private void UpdateMovementState()
    {
        isMoving = Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f;
    }

    private void UpdateAnimatorParameters()
    {
        if (animator == null)
        {
            return;
        }

        animator.SetFloat("verticalMove", verticalInput);
        animator.SetFloat("horizontalMove", verticalInput);
        animator.SetBool("isMove", isMoving);
    }

    private void UpdateLastTransform()
    {
        lastPosition = transform.parent.position;
        lastRotation = transform.parent.rotation;
    }

    public void SwitchToRandomCharacter()
    {
        if (characterSetups == null || characterSetups.Length < 2)
        {
            return;
        }

        // Получаем все наборы, кроме текущего
        CharacterSetup[] availableSetups = characterSetups.Where(setup => setup.model != activeModel).ToArray();
        if (availableSetups.Length == 0)
        {
            return;
        }

        // Деактивируем текущие
        if (activeModel != null)
        {
            activeModel.SetActive(false);
        }
        if (activeVeslo != null)
        {
            activeVeslo.SetActive(false);
        }

        // Выбираем новый случайный набор
        int newIndex = Random.Range(0, availableSetups.Length);
        CharacterSetup newSetup = availableSetups[newIndex];

        // Активируем новые
        activeModel = newSetup.model;
        activeVeslo = newSetup.veslo;

        if (activeModel != null)
        {
            activeModel.SetActive(true);
            animator = activeModel.GetComponent<Animator>();
        }

        if (activeVeslo != null)
        {
            activeVeslo.SetActive(true);
            vesloController = activeVeslo.GetComponent<ChangeParentVeslo>();
        }
    }
}