using UnityEngine;

public class ShooterAI : MonoBehaviour
{
    public Transform player;
    public GameObject enemyBulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    private float nextFire = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.LookAt(player);

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(enemyBulletPrefab, firePoint.position, firePoint.rotation);
    }

    public int damage = 10;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
        Destroy(gameObject); 
    }
}
