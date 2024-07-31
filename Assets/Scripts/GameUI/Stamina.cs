using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stamina : MonoBehaviour
{
     
    [SerializeField] private GameObject _player;
    [SerializeField] private float staminaLost;
    [SerializeField] private float speedMultiplier = 2.0f; // Коэффициент увеличения скорости
    [SerializeField] private float boostDuration = 5.0f;   // Длительность ускорения
    [SerializeField] private float _maxSP;
    [SerializeField] private UnityEvent<float> SpChanged;
    [SerializeField] private UnityEvent<float> SpChangedPercent;
    
    private float _currentSP;
    private float _s;
    private Rigidbody _rb;
    private Vector3 _direction;
    private Transform supTransform;
    

    public float SP
    {
        get => _currentSP;
        set
        {
            _currentSP = value;
            SpChanged?.Invoke(_currentSP);
            SpChangedPercent?.Invoke(_currentSP / _maxSP);
        }
    }
    private void Start()
    {
        Init();
        _rb = _player.GetComponent<Rigidbody>();
        supTransform = _rb.GetComponent<Transform>();
    }

    private void Update()
    {
        _direction = supTransform.TransformDirection(Vector3.forward);
    }

    void FixedUpdate()
    {
        //_s = Input.GetAxis("Fire3");
        Debug.Log(_rb.velocity);

        if (Input.GetButton("Fire3") && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)))
        {
            //Debug.Log("Shift нфжфт");
            _rb.AddForce(_direction * -speedMultiplier, ForceMode.Force);
            LoseStamina(staminaLost);
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


}
