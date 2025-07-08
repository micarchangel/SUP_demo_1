using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [Header("Объект вращения")]
    [SerializeField] private GameObject obj;

    [Header("Настройки вращения")]
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float minYAngle = -30f;
    [SerializeField] private float maxYAngle = 30f;
    [SerializeField] private float returnSpeed = 2f;
    [SerializeField] private float smoothness = 5f;

    private float currentYRotation = 0f;
    private float targetYRotation = 0f;
    private Vector2 lastMousePosition;
    private bool rotationEnabled;
    private bool isDragging = false;

    private void Update()
    {
        HandleInput();
        UpdateRotation();
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging && rotationEnabled)
        {
            Vector2 currentMousePosition = Input.mousePosition;
            float deltaX = (currentMousePosition.x - lastMousePosition.x) * rotationSpeed * Time.deltaTime;
            lastMousePosition = currentMousePosition;

            targetYRotation += deltaX;
            targetYRotation = Mathf.Clamp(targetYRotation, minYAngle, maxYAngle);
        }
        else if (!rotationEnabled)
        {
            targetYRotation = Mathf.Lerp(targetYRotation, 0f, returnSpeed * Time.deltaTime);
        }
    }

    private void UpdateRotation()
    {
        // Плавное вращение с использованием SmoothDamp
        currentYRotation = Mathf.SmoothDamp(currentYRotation, targetYRotation, ref velocity, 1f / smoothness);

        // Применяем вращение
        obj.transform.localEulerAngles = new Vector3(0f, currentYRotation, 0f);
    }

    private float velocity = 0f; // Для SmoothDamp

    public void SwitchRotationEnable()
    {
        rotationEnabled = true;
    }

    public void SwitchRotationDisable()
    {
        rotationEnabled = false;
    }
}