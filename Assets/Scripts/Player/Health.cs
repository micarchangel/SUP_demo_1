using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHP;
    [SerializeField] private UnityEvent Die;
    [SerializeField] private UnityEvent<float> HpChanged;
    [SerializeField] private UnityEvent<float> HpChangedPercent;
    private float _currentHP;

    public float HP
    {
        get => _currentHP;
        set
        {
            _currentHP = value;
            HpChanged?.Invoke(_currentHP);
            HpChangedPercent?.Invoke(_currentHP / _maxHP);


            if (_currentHP <= 0)
            {
                EndGame.Success = false;
                Die?.Invoke();
            }
        }
    }

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        HP = _maxHP;
    }

    public void GetDamage(float damage)
    {
        HP -= damage;
        Debug.Log("HP = " + HP);
    }

    public void AddHealth(float hp)
    {
        HP += hp;
    }
}
