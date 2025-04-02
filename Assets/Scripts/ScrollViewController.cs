using UnityEngine;
using UnityEngine.UI;

public class ScrollViewController : MonoBehaviour
{
    private ScrollRect scrollRect;
    public float itemHeight; // Высота одного пункта в Scroll View
    public int scrollAmount; // Количество пунктов для прокрутки

    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        // Убедитесь, что scrollRect назначен
        if (scrollRect == null)
        {
            Debug.LogError("ScrollRect не назначен.");
            return;
        }
    }

    public void ScrollUp()
    {
        float newPosition = scrollRect.verticalNormalizedPosition + (scrollAmount * itemHeight / scrollRect.content.rect.height);
        scrollRect.verticalNormalizedPosition = Mathf.Clamp01(newPosition);
    }

    public void ScrollDown()
    {
        float newPosition = scrollRect.verticalNormalizedPosition - (scrollAmount * itemHeight / scrollRect.content.rect.height);
        scrollRect.verticalNormalizedPosition = Mathf.Clamp01(newPosition);
    }
}
