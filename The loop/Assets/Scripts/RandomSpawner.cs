using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject Cell, Cell_1;
    public Transform Zero;
    public int Height, Width, N;
    private GameObject k;

    public void Start()
    {
        Generate();
    }
    public void Generate()
    {
        if (Random.Range(0, 2) == 0)
        {
            k = Cell;
        }
        else
        {
            k = Cell_1;
        }
        for (int n = 0; n < N; n++)
        {
            var cell = Instantiate(k, Zero);
            cell.transform.localPosition = new Vector2(Random.Range(0, Width), Random.Range(0, Height));
        }
    }
}
