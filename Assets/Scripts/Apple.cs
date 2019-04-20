using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{

    public float velocity = 1;
    private Vector3 _direction;

    void Start()
    {
        float randomValue = Random.Range(-1.0f, 1.0f);
        float x = Mathf.Sign(randomValue);
        _direction = new Vector3(x, 1.0f, 0.0f);
        _direction.Normalize();
    }

    void Update()
    {
        transform.position += _direction * velocity * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _direction = Vector3.Reflect(_direction, collision.contacts[0].normal);
        _direction.Normalize();
    }
}
