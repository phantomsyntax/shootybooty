using UnityEngine;

public class Bullet : MonoBehaviour, IActorProperties
{
    [Header("Bullet Settings")]
    [SerializeField] private int bulletSpeed;
    [SerializeField] private int bulletHealth;
    [SerializeField] private int bulletHitPower;
                     public int BulletHealth
                    {
                        get { return bulletHealth; }
                        set { bulletHealth = value; }
                    }

    [Header("Bullet Prefab Objects")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private SOActorObject bulletActorObject;

    void Start()
    {
        NullChecks();

        PopulateStats(bulletActorObject);
        Destroy(gameObject, 1.5f);
    }

    private void NullChecks()
    {
        if (!bulletActorObject)
        {
            Debug.LogWarning("[Bullet] - No bulletActorObject is loaded!");
        }
    }

    public void PopulateStats(SOActorObject actorObject)
    {
        bulletHealth = actorObject.actorHealth;
        bulletSpeed = actorObject.actorSpeed;
        bulletHitPower = actorObject.actorHitPower;
        bulletPrefab = actorObject.actorPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletHealth <= 0)
        {
            Die();
        }

        Movement();
    }

    private void Movement()
    {
        transform.Translate(Vector3.right * (bulletSpeed * Time.deltaTime));
    }

    public int SendDamage()
    {
        return bulletHitPower;
    }

    public void TakeDamage(int incomingDamage)
    {
        bulletHealth -= incomingDamage;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && other.GetComponent<IActorProperties>() != null)
        {
            other.GetComponent<IActorProperties>().SendDamage();
        }
    }

    // This doesn't work..
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
