using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TerrainGenerator : MonoBehaviour {

    public GameObject InitialBlock;
    public GameObject[] TerrainBlocks;
    private int BlockIndex = 0;

    private List<GameObject> CurrentBlocksOnLevel = new List<GameObject>();

	// Use this for initialization
	void Start () {
		for (int i=0; i <5; i++)
        {
            GenerateBlock();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void GenerateBlock()
    {
        var index = Random.Range(0, TerrainBlocks.Length);

        var prefab = TerrainBlocks[index];

        if (BlockIndex < 2)
        {
            prefab = InitialBlock;
        }

        var block = Instantiate(prefab);
        // add instance of block into list of blocks on level (will be used to get rid of old blocks)
        CurrentBlocksOnLevel.Add(block);

        // move the block (size of one block is 8f)
        block.transform.position = Vector2.right * BlockIndex * 8f;

        // box collider in a place minus 2 before last element
        GetComponent<BoxCollider2D>().transform.position = Vector2.right * (BlockIndex - 2) * 8f;
        // increment index of block
        BlockIndex++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // on collision generates one new block, and destroys first block in list of blocks
        GenerateBlock();

        var firstBlock = CurrentBlocksOnLevel.First();
        // destroy from game
        Destroy(firstBlock);
        // remove from array
        CurrentBlocksOnLevel.RemoveAt(0);
    }
}
