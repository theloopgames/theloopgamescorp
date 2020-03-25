using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour
{
    public GameObject Cell;
    public Transform Zero;
    public int Height, Width,N;
        
    public void Start()
    {
        Generate();
    }
    public void Generate()
    {
        for (int n = 0; n < N; n++)
        {
            var cell = Instantiate(Cell, Zero);
            cell.transform.localPosition = new Vector2(Random.Range(0, Width), Random.Range(0,Height));
        }
    }
}
