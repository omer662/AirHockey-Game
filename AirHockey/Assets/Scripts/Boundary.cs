using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Boundary
{
    public float up, down, left, right;

    public Boundary(float Up, float Down, float Left, float Right)
    {
        up = Up; down = Down; left = Left; right = Right;
    }
}
