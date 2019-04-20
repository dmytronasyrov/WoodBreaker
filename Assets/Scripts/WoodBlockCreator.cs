using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBlockCreator : MonoBehaviour
{
    public GameObject[] blocks;
    public int rows;

    void Start()
    {
        CreateBlocksGroup();
    }

    void CreateBlocksGroup()
    {
        float screenWidth, screenHeight, scaleMultiplier;
        int columns;
        float blockWidth = blocks[0].GetComponent<SpriteRenderer>().bounds.size.x;
        float blockHeight = blocks[0].GetComponent<SpriteRenderer>().bounds.size.y;
        GetBlocksInformation(blockWidth, out screenWidth, out screenHeight, out columns, out scaleMultiplier);

        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
                int randomIdx = Random.Range(0, blocks.Length);
                GameObject randomGo = blocks[randomIdx];
                GameObject initGo = Instantiate(randomGo);
                initGo.transform.position = new Vector3(-screenWidth / 2 + blockWidth * scaleMultiplier * y, screenHeight / 2 - blockHeight * x, 0);
                initGo.transform.localScale = new Vector3(initGo.transform.localScale.x * scaleMultiplier, initGo.transform.localScale.y, 1);
            }
        }
    }

    void GetBlocksInformation(float blockWidth, out float screenWidth, out float screenHeight, out int columns, out float scaleMultiplier)
    {
        Camera cam = Camera.main;
        screenWidth = (cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)) - cam.ScreenToWorldPoint(new Vector3(0, 0, 0))).x;
        screenHeight = (cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)) - cam.ScreenToWorldPoint(new Vector3(0, 0, 0))).y;
        columns = (int) Mathf.Floor(screenWidth / blockWidth);
        scaleMultiplier = screenWidth / (blockWidth * columns);


    }
}
