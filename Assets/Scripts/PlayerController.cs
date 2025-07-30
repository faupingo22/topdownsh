using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector3 movement;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public Camera mainCamera;
    public int maxHealth = 100;
    public int currentHealth;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        rb = GetComponent<Rigidbody>();
        
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameManager.Instance.PlayerDefeated();

        gameObject.SetActive(false);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

        RotateTowardsMouse();
    }

    void RotateTowardsMouse()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        Plane groundPlane = new Plane(Vector3.up, transform.position);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLookAt = cameraRay.GetPoint(rayLength);

            transform.LookAt(new Vector3(pointToLookAt.x, transform.position.y, pointToLookAt.z));
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
