using UnityEngine;

[CreateAssetMenu(fileName = "NewActor", menuName = "Actors/New Actor Object")]
public class SOActorObject : ScriptableObject
{
    public enum AttackType
    {
        player,
        bullet,
        enemyWave,
        enemyFlee
    }

    [Header("Attack Settings")]
                     public AttackType attackType = AttackType.enemyWave;
                     public int actorHitPower = 1;
                     public int actorPointValue = 200;

    [Header("Actor Description")]
                     public string actorName = "Actor Name";
                     public string actorDescription = "Actor Description";

    [Header("Actor Stats")]
                     public int actorHealth = 100;
                     public int actorSpeed = 1;

    [Header("Actor Prefabs")]
                     public GameObject actorPrefab;
                     public GameObject actorBulletPrefab;
}