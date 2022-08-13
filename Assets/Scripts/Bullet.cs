using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] float damage = 3.0f;
    [SerializeField] float speed = 10.0f;
    public Rigidbody Rigidbody;

    public float Damage { get => damage; set => damage = value; }
    public float Speed { get => speed; set => speed = value; }

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();    
    }
}
