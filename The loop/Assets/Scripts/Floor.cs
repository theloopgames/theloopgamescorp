using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public GameObject Cell;
    public Transform Zero;
    public int Height, Width;

    public void Start()
    {
        Generate();
    }
    public void Generate()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                var cell = Instantiate(Cell, Zero);
                cell.transform.localPosition = new Vector2(x, y);
            }

        }
    }
}