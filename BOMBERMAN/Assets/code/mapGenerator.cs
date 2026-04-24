using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour
{
    public GameObject UndestructibleTile;
    public GameObject DestructibleTile;
    int maxX = 13, maxZ = 21;
    float tileSize = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxZ; i++)
        {
            for (int j = 0; j < maxX; j++)
            {
                if(i == 0 || i == maxZ - 1 || j == 0 || j == maxX - 1){// if borders
                    GameObject spawnCube = Instantiate(UndestructibleTile,  new Vector3(i * tileSize, 2.5f, j * tileSize), Quaternion.identity);
                }else{
                    if(i%2 == 0 && j%2 == 0 ){
                        GameObject spawnCube = Instantiate(UndestructibleTile,  new Vector3(i * tileSize, 2.5f, j * tileSize), Quaternion.identity);
                    }else{
                        if(i > 3 || j > 3){
                            GameObject spawnCube = Instantiate(DestructibleTile,  new Vector3(i * tileSize, 2.5f, j * tileSize), Quaternion.identity);
                        }
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
