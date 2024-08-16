using UnityEngine;

public class JetSki : MonoBehaviour
{
    [SerializeField] private float speed = -10f; // Скорость гидроцикла
    [SerializeField] private float turnDistance = 3f; // Расстояние до игрока, при котором гидроцикл отворачивается
    [SerializeField] private Transform playerTransform;
    //private AudioSource audioSource;

    private Vector3 direction;

    void Start()
    {
        direction = Vector3.forward; // Начальное направление движения
        gameObject.GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        // Рассчитываем расстояние до игрока
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // Если гидроцикл находится близко к игроку, меняем направление
        if (distanceToPlayer < turnDistance)
        {
            direction = (transform.position - playerTransform.position).normalized;
        }


        // Двигаем гидроцикл в текущем направлении
        transform.Translate(direction * speed * Time.deltaTime);
    }

    //private void OnDestroy()
    //{
    //    //audioSource.Stop();
    //}
}
