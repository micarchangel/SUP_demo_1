using UnityEngine;

public class JetSki : MonoBehaviour
{
    public float speed = -10f; // Скорость гидроцикла
    public float turnDistance = 3f; // Расстояние до игрока, при котором гидроцикл отворачивается
    public Transform player;

    private Vector3 direction;

    void Start()
    {
        direction = Vector3.forward; // Начальное направление движения
    }

    void Update()
    {
        // Рассчитываем расстояние до игрока
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Если гидроцикл находится близко к игроку, меняем направление
        if (distanceToPlayer < turnDistance)
        {
            direction = (transform.position - player.position).normalized;
        }

        // Двигаем гидроцикл в текущем направлении
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
