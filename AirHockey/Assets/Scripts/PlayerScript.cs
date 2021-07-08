using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update

    bool canMove;
    bool dragging;

    Rigidbody2D rb;
    Vector2 startingPosition;

    float radius;

    public Transform boundaryHolder;

    Boundary botBoundary;

    void Start()
    {
        canMove = false;
        dragging = false;

        rb = GetComponent<Rigidbody2D>();
        radius = GetComponent<SpriteRenderer>().bounds.extents.x;
        botBoundary = new Boundary(boundaryHolder.GetChild(0).position.y,
                                   boundaryHolder.GetChild(1).position.y,
                                   boundaryHolder.GetChild(2).position.x,
                                   boundaryHolder.GetChild(3).position.x);
        startingPosition = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            bool inXRange = mousePos.x <= transform.position.x + radius && mousePos.x >= transform.position.x - radius;
            bool inYRange = mousePos.y <= transform.position.y + radius && mousePos.y >= transform.position.y - radius;

            if (inXRange && inYRange)
                canMove = true;
            else
                canMove = false;
            dragging = canMove;
        }
        if (dragging)
        {
            Vector2 clampedMousePos = new Vector2(Mathf.Clamp(mousePos.x, botBoundary.left, botBoundary.right),
                                                  Mathf.Clamp(mousePos.y, botBoundary.down, botBoundary.up));
            rb.MovePosition(clampedMousePos);
        }
        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
            dragging = false;
        }
    }

    public void ResetPosition()
    {
        rb.position = startingPosition;
        canMove = false;
        dragging = false;
    }
}
