using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGrid : MonoBehaviour
{

    public Block[,] Grid = new Block[5, 18];
    public Vector3 blockDimensions;
    public Block[] Blocks;
    public static int BlockCount = 90;
    private List<Block> _blockCount = new List<Block>();

    // Use this for initialization
    void Start()
    {
        CreateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        if(BlockCount == 0)
        {
            BlockCount = 90;
            CreateGrid();
        }
    }

    void CreateGrid()
    {
        for (int i = 0; i < Grid.GetLength(0); i++)
        {
            for (int j = 0; j < Grid.GetLength(1); j++)
            {
                Block block = Blocks[Random.Range(0, Blocks.Length)];

                Grid[i, j] = Instantiate(block, transform);
                Grid[i, j].name = "Block pos [" + i + "," + j + "]";
                Grid[i, j].transform.localPosition = new Vector3(j-1 * blockDimensions.x, i-1 * blockDimensions.y, 0f);
            }
        }
    }
}
