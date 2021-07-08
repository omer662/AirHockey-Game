using UnityEngine;

public class BotScript : MonoBehaviour
{

    public float MaxMovementSpeed;
    private Rigidbody2D rb;
    private Vector2 startingPosition;

    public Rigidbody2D Puck;
    public SpriteRenderer PuckRenderer;
    private float puckRadius;

    public Transform BotBoundaryHolder;
    private Boundary botBoundary;

    public Transform PuckBoundaryHolder;
    private Boundary puckBoundary;

    private Vector2 targetPosition;

    private bool isFirstTimeInOpponentsHalf = true;
    private float offsetYFromTarget;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;

        botBoundary = new Boundary(BotBoundaryHolder.GetChild(0).position.y,
                              BotBoundaryHolder.GetChild(1).position.y,
                              BotBoundaryHolder.GetChild(2).position.x,
                              BotBoundaryHolder.GetChild(3).position.x);

        puckBoundary = new Boundary(PuckBoundaryHolder.GetChild(0).position.y,
                              PuckBoundaryHolder.GetChild(1).position.y,
                              PuckBoundaryHolder.GetChild(2).position.x,
                              PuckBoundaryHolder.GetChild(3).position.x);

        puckRadius = PuckRenderer.bounds.extents.x;
    }

    private void FixedUpdate()
    {
        if (!PuckScript.WasGoal)
        {
            float movementSpeed;

            if (Puck.position.x < puckBoundary.left)
            {
                if (isFirstTimeInOpponentsHalf)
                {
                    isFirstTimeInOpponentsHalf = false;
                    offsetYFromTarget = Random.Range(-1f, 1f);
                }

                movementSpeed = MaxMovementSpeed * Random.Range(0.1f, 0.3f);
                targetPosition = new Vector2(startingPosition.x, Mathf.Clamp(Puck.position.y + offsetYFromTarget, botBoundary.down, botBoundary.up));
            }
            else
            {
                isFirstTimeInOpponentsHalf = true;

                movementSpeed = Random.Range(MaxMovementSpeed * 0.4f, MaxMovementSpeed);

                float addX, addY;

                if (Puck.position.x > rb.position.x) addX = puckRadius; else if (Puck.position.x == rb.position.x) addX = 0; else addX = puckRadius * -1;
                if (Puck.position.y > rb.position.y) addY = puckRadius; else if (Puck.position.y == rb.position.y) addY = 0; else addY = puckRadius * -1;

                targetPosition = new Vector2(Mathf.Clamp(Puck.position.x + addX, botBoundary.left, botBoundary.right),
                                             Mathf.Clamp(Puck.position.y + addY, botBoundary.down, botBoundary.up));
            }

            rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, movementSpeed * Time.fixedDeltaTime));
        }
    }

    public void ResetPosition()
    {
        rb.position = startingPosition;
        isFirstTimeInOpponentsHalf = true;
    }
}