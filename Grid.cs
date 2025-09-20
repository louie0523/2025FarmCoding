using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Tile tile;
    public bool isComplete;
    public bool isDestory;

    private void Start()
    {
        tile = transform.parent.transform.parent.GetComponent<Tile>();
    }
}
