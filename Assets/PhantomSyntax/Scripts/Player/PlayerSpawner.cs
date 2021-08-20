using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [Header("Player Spawn Settings")]
    [SerializeField] private SOActorObject playerActorObject;
    [SerializeField] private GameObject playerShipPrefab;
    [SerializeField] private Vector3 playerSpawnPosition = Vector3.zero;
    [SerializeField] private Quaternion playerSpawnRotation = Quaternion.Euler(0, 0, 0);

    [Header("Player Initialize Settings")]
    [SerializeField] private string playerObjectName = "Player";
    [SerializeField] private Vector3 playerObjectScale = new Vector3(1.0f, 1.0f, 1.0f);

    private void Start()
    {
        NullChecks();

        Spawn(playerSpawnPosition, playerSpawnRotation);
        Initialize(playerObjectName, playerObjectScale);
    }

    private void NullChecks()
    {
        if (!playerShipPrefab)
        {
            Debug.LogWarning($"[PlayerSpawner] - playerShipPrefab has no GameObject attached!");
        }
        if (!playerActorObject)
        {
            Debug.LogWarning($"[PlayerSpawner] - playerActorObject has no SOActorObject attached!");
        }
    }

    private void Spawn(Vector3 position, Quaternion rotation)
    {
        playerShipPrefab = Instantiate(playerActorObject.actorPrefab, position, rotation, transform);
        playerShipPrefab.GetComponent<IActorProperties>().PopulateStats(playerActorObject);
    }

    private void Initialize(string name, Vector3 scale)
    {
        playerShipPrefab.name = name;
        playerShipPrefab.transform.localScale = scale;
    }
}