using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{

    public float velocity = 1;
    public GameObject woodParticle, leavesParticle;
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
        ColliderCreator colliderCreator = collision.gameObject.GetComponent<ColliderCreator>();
        Platform platform = collision.gameObject.GetComponent<Platform>();
        Vector2 normal = collision.contacts[0].normal;
        bool isGameOver = false;

        if (colliderCreator != null && normal == Vector2.up)
        {
            isGameOver = true;
        } 
        else if (platform)
        {
            leavesParticle.transform.position = platform.transform.position;
            leavesParticle.GetComponent<ParticleSystem>().Play();

            if (normal != Vector2.up)
            {
                isGameOver = true;
            }
        }
        else if (!colliderCreator && !platform)
        {
            SpriteRenderer renderer = collision.gameObject.GetComponent<SpriteRenderer>();
            Vector3 woodenPlankPos = collision.gameObject.transform.position;
            Vector3 particleInitPos = new Vector3(woodenPlankPos.x + renderer.bounds.extents.x, woodenPlankPos.y - renderer.bounds.extents.y, -1);

            GameObject particle = (GameObject) Instantiate(woodParticle, particleInitPos, Quaternion.identity);
            ParticleSystem particleSystem = particle.GetComponent<ParticleSystem>();

            Destroy(collision.gameObject);
            Destroy(particle, particleSystem.startLifetime + particleSystem.duration);
            GameManager.points++;
        }

        if (isGameOver)
        {
            GameManager.GameOver();
        }
        else
        {
            _direction = Vector3.Reflect(_direction, collision.contacts[0].normal);
            _direction.Normalize();
        }
    }
}
