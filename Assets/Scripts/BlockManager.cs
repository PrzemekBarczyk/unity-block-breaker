using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    List<Block> _blocks = new List<Block>();

    void Start()
    {
        foreach (Block block in FindObjectsOfType<Block>())
            _blocks.Add(block);
    }

    public void RemoveBlock(Block blockToRemove)
	{
        _blocks.Remove(blockToRemove);
	}

    public int BlocksLeft()
	{
        return _blocks.Count;
	}
}
