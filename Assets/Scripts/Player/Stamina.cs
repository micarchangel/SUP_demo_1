using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stamina : MonoBehaviour
{
     
    [SerializeField] private GameObject _player;
    [SerializeField] private float staminaLost;
    [SerializeField] private float staminaAdd;
    [SerializeField] private float speedMultiplier = 2.0f; // Коэффициент увеличения скорости
    //[SerializeField] private float boostDuration = 5.0f;   // Длительность ускорения
    [SerializeField] private float delay; // время задержки перед восполнением SP
    //[SerializeField] private float _minSP = 0; // уровень СП при котором активируется задержка
    [SerializeField] private float _maxSP;
    [SerializeField] private UnityEvent<float> SpChanged;
    [SerializeField] private UnityEvent<float> SpChangedPercent;
    
    private float _currentSP;
    private float _s;
    private Rigidbody _rb;
    private Vector3 _direction;
    private Transform _supTransform;

    public float SP
    {
        get => _currentSP;
        set
        {
            _currentSP = value > _maxSP ? _maxSP : value;
            SpChanged?.Invoke(_currentSP);
            SpChangedPercent?.Invoke(_currentSP / _maxSP);
            //Debug.Log("Stamina = " + _currentSP);
        }
    }
    private void Start()
    {
        Init();
        _rb = _player.GetComponent<Rigidbody>();
        _supTransform = _rb.GetComponent<Transform>();
    }

    private void Update()
    {
        _direction = _supTransform.TransformDirection(Vector3.forward);
    }

    void FixedUpdate()
    {
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && SP > 0)
        {
            StopAllCoroutines();
            if (Input.GetButton("Fire3"))
            {
                //Debug.Log("Shift нажат");
                _rb.AddForce(_direction * -speedMultiplier, ForceMode.Force);
                LoseStamina(staminaLost);
            }
        }
        else
        {
            StartCoroutine(DelayCoroutine(delay));
        }
    }

    public void Init()
    {
        SP = _maxSP;
    }

    public void LoseStamina(float value)
    {
        SP -= value;
    }

    public void AddStamina(float value)
    {
        SP += value;
    }

    private IEnumerator DelayCoroutine(float delay)
    {
        if (SP < _maxSP)
        {
            yield return new WaitForSeconds(delay);
            AddStamina(staminaAdd);
        }
    }
}
