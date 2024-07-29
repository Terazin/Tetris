using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private Transform emptySprite;
    [SerializeField]
    private int height = 30, width = 10, header = 8;


    private void Start()
    {
        CreateBoard();
    }

    void CreateBoard()
    {
        if (emptySprite)
        {
            for (int y = 0; y < height - header; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Transform clone = Instantiate(emptySprite,
                        new Vector3(x, y, 0), Quaternion.identity);

                    clone.transform.parent = transform;
                }
            }
        }
    }

    public bool CheckPosition(Block block)
    {
        foreach (Transform item in block.transform)
        {
            Vector2 pos = new Vector2(Mathf.Round(item.position.x),
                Mathf.Round(item.position.y));

            if(!BoardOutCheck((int)pos.x,(int)pos.y))
            {
                return false;
            }
        }
        return true;
    }

    bool BoardOutCheck(int x, int y)
    {
        return (x >= 0 && x < width && y >= 0);
    }
}
