using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float _damage;
    [SerializeField] int _score;

    public float Damage => _damage;
    public int Score => _score;
}
