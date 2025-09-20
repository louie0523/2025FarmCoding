using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Crop
{
    None,
    Corn,
    Carrot,
    Cflow,
    Bro,
    GoldCarrot,
}

public class Tile : MonoBehaviour
{
    public Crop crop;
    [Range(0, 100)]
    public float Wateily;
    public int Grow;
    public List<Grid> GridScript = new List<Grid>();


    private void Start()
    {
        Setting();
    }

    void Setting()
    {
        GameObject grids = transform.GetChild(0).gameObject;

        foreach(Transform ob in grids.transform)
        {
            Grid grid = ob.GetComponent<Grid>();
            GridScript.Add(grid);
        }
    }
}
