using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody rb;

    void Start()
    {
        rb.linearVelocity = transform.forward * speed;
        Destroy(gameObject, 3f); 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); 
        }
        Destroy(gameObject);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.EnemyDefeated();

            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }

}
