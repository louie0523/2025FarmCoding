using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapGenerater : MonoBehaviour
{
    public GameObject prefab;
    public int X;
    public int Z;
    public Vector3 offset;

    private void Start()
    {
        for(int i = 0; i < X; i++)
        {
            for(int j = 0; j < Z; j++)
            {
                Vector3 pos = new Vector3(i * offset.x, 0, j * offset.z);
                Instantiate(prefab, pos, Quaternion.identity, transform);
            }
        }
    }
}
