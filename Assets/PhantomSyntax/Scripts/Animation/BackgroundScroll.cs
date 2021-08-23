using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [Header("Background Settings")]
    [SerializeField] private GameObject backgroundPrefab;
    [SerializeField] private float scrollSpeed = 1.0f;
                     private enum Direction
                    {
                        Left,
                        Right,
                        Stop
                    }
    [SerializeField] private Direction direction;
                     private Vector3 backgroundStartPosition;

    private void Start()
    {
        NullChecks();

        backgroundStartPosition = backgroundPrefab.transform.position;
    }

    private void NullChecks()
    {
        if (!backgroundPrefab)
        {
            backgroundPrefab = gameObject;
        }
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        // TODO: figure out math to check background object size for auto scaling
        if (backgroundPrefab.transform.position.x < -25.0f)
        {
            backgroundPrefab.transform.position = backgroundStartPosition;
        }

        switch (direction)
        {
            case Direction.Left:
                Left();
                break;
            case Direction.Right:
                Right();
                break;
            default:
                break;
        }
    }

    private void Left()
    {
        backgroundPrefab.transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
    }

    private void Right()
    {
        backgroundPrefab.transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
    }
}