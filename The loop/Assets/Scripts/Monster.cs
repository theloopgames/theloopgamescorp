using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    int[] nums = new int[5];
    int i;
    public GameObject Cell, Cell_1, Cell_2, Cell_3, Cell_4, Cell_5;
    public Transform Zero;
    public int Height, Width, N;
    private GameObject[] k = new GameObject[5];
    public void Start()
    {
        Generate();
    }
    public void Generate()
    {
        nums[0] = -1;
        nums[1] = -1;
        for (int x = 2; x < 5; x++)
        {
            i = Random.Range(0, 6);
            nums[x] = i;
            if (nums[x] == nums[x - 1] || nums[x] == nums[x - 2])
            {
                x--;
            }
        }
        for (int j = 2; j < 5; j++)
        {
            switch (nums[j])
            {
                case 0:
                    k[j] = Cell;
                    break;
                case 1:
                    k[j] = Cell_1;
                    break;
                case 2:
                    k[j] = Cell_2;
                    break;
                case 3:
                    k[j] = Cell_3;
                    break;
                case 4:
                    k[j] = Cell_4;
                    break;
                case 5:
                    k[j] = Cell_5;
                    break;
            }
        }
        for (int j = 2; j < 5; j++)
        {
            for (int n = 0; n < N; n++)
            {
                var cell = Instantiate(k[j], Zero);
                cell.transform.localPosition = new Vector2(Random.Range(0, Width), Random.Range(0, Height));
            }
        }
    }



}
