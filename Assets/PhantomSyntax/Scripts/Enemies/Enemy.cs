using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IActorProperties
{
    [Header("Enemy Settings")]
    [SerializeField] private int enemyHealth;
    [SerializeField] private int enemyHitPower;
    [SerializeField] private int enemyFireSpeed;
    [SerializeField] private int enemyTravelSpeed;
    [SerializeField] private int enemyPointValue;

    [Header("Enemy Wave Settings")]
    [SerializeField] private float verticalSpeed = 1.0f;
    [SerializeField] private float verticalAmplitude = 1.0f;
                     private Vector3 sineVector;
                     private float sineTime;

    private void Start()
    {
        NullChecks();
    }

    private void NullChecks()
    {

    }

    public void PopulateStats(SOActorObject actorObject)
    {
        enemyHealth = actorObject.actorHealth;
        enemyHitPower = actorObject.actorHitPower;
        enemyTravelSpeed = actorObject.actorSpeed;
        enemyPointValue = actorObject.actorPointValue;
    }

    private void Update()
    {
        if (enemyHealth <= 0)
        {
            Die();
        }

        Attack();
    }

    private void Attack()
    {
        sineTime += Time.deltaTime;
        sineVector.y = Mathf.Sin(sineTime * verticalSpeed) * verticalAmplitude;
        transform.position = new Vector3(transform.position.x + (enemyTravelSpeed * Time.deltaTime),
                                         transform.position.y + sineVector.y,
                                         0.0f);
    }

    public int SendDamage()
    {
        return enemyHitPower;
    }

    public void TakeDamage(int incomingDamage)
    {
        enemyHealth -= incomingDamage;
    }

    public void Die()
    {
        GameManager.Instance.GetComponent<ScoreManager>().UpdateScore(enemyPointValue);
        Destroy(gameObject);
        print("Enemy has died");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IActorProperties>() != null)
        {
            enemyHealth -= other.GetComponent<IActorProperties>().SendDamage();
        }
    }
}