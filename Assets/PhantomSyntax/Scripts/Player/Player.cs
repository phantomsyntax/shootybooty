using UnityEngine;

public class Player : MonoBehaviour, IActorProperties
{
    [Header("Player Settings")]
    [SerializeField] private int playerSpeed;
    [SerializeField] private int playerHealth;
    [SerializeField] private int playerHitPower;
                     public int PlayerHealth
                    {
                        get { return playerHealth; }
                        set { playerHealth = value; }
                    }

    [Header("Player Prefab Objects")]
    [SerializeField] private GameObject playerShipPrefab;
    [SerializeField] private GameObject playerBullet;
                     public GameObject PlayerBullet
                    {
                        get { return playerBullet; }
                        set { playerBullet = value; }
                    }

    [Header("Player Boundary Settings")]
    [SerializeField] private float boundaryHeight;
    [SerializeField] private float boundaryWidth;

    private void Start()
    {
        NullChecks();

        SetPlayerBoundary();
    }

    private void NullChecks()
    {

    }

    public void PopulateStats(SOActorObject actorObject)
    {
        // Updates stats from the assigned SOActorObject
        playerHealth = actorObject.actorHealth;
        playerSpeed = actorObject.actorSpeed;
        playerHitPower = actorObject.actorHitPower;
        playerBullet = actorObject.actorBulletPrefab;
    }

    private void Update()
    {
        if (playerHealth <= 0)
        {
            Die();
        }

        Movement();
        Attack();

        // Hideous code. Redo this. Awful.
        if (transform.localPosition.x < -14.0f)
        {
            transform.localPosition = new Vector3(-14.0f, transform.localPosition.y, 0.0f);
        }
        if (transform.localPosition.x > 0.0f)
        {
            transform.localPosition = new Vector3(0.0f, transform.localPosition.y, 0.0f);
        }
        if (transform.localPosition.y < -7.5f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, -7.5f, 0.0f);
        }
        if (transform.localPosition.y > 7.5f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 7.5f, 0.0f);
        }
    }
    private void SetPlayerBoundary()
    {
        // Divides the screen resolution to figure out the player movement clamp boundaries
        // TODO: this needs to be refactored
        boundaryWidth = 1 / (Camera.main.WorldToViewportPoint(new Vector3(1.0f, 1.0f, 0.0f)).x - 0.5f);
        boundaryHeight = 1 / (Camera.main.WorldToViewportPoint(new Vector3(1.0f, 1.0f, 0.0f)).y - 0.5f);
    }

    private void Movement()
    {
        // Using old Input Manager
        // Checks for horizontal axis input within the movement boundary
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            transform.localPosition += new Vector3((Input.GetAxisRaw("Horizontal") * playerSpeed) * Time.deltaTime, 0.0f, 0.0f);
        }
        // Checks for vertical axis input within the movement boundary
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            transform.localPosition += new Vector3(0.0f, (Input.GetAxisRaw("Vertical") * playerSpeed) * Time.deltaTime, 0.0f);
        }
    }

    private void Attack()
    {
        if (Input.GetButtonDown("Fire1"))  
        {
            GameObject bullet = Instantiate(playerBullet, transform.position, Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
        }
    }

    public int SendDamage()
    {
        return playerHitPower;
    }

    public void TakeDamage(int incomingDamage)
    {
        playerHealth -= incomingDamage;
    }

    public void Die()
    {
        Destroy(gameObject);
        print("Player has died");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Come back and do the energy clone code for health > 1
        if (other.tag == "Enemy")
        {
            playerHealth -= other.GetComponent<IActorProperties>().SendDamage();
        }
    }
}