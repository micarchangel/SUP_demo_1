using UnityEngine;
using UnityEngine.UI;

public class PersController : MonoBehaviour
{
    public float speed = 5f;
    public float moveSpeed = 1f;
    Vector3 direction;
    CharacterController controller;

    public bool EscapeMenu;
    public GameObject escape;
    public Button pause;


    void Awake()
    {
        controller = GetComponent<CharacterController>();
        escape.gameObject.SetActive(false);
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        direction = new Vector3(-x*speed, 0, -(moveSpeed + z));

        controller.Move(direction * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!EscapeMenu)
            {
                escape.SetActive(true);
                pause.gameObject.SetActive(false);
                EscapeMenu = true;
                Time.timeScale = 0f;
            }
            else
            {
                escape.SetActive(false);
                pause.gameObject.SetActive(true);
                EscapeMenu = false;
                Time.timeScale = 1f;
            }
        }
    }
}
