using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    float SpawnTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTime = Time.time;
    }

    void Explosion() { 
    // generar explosion en z, x 
    }

    // Update is called once per frame
    void Update()
    {
        // 3 seconds after span it explodes
        if (SpawnTime + 3 < Time.time) {
            Explosion();
            // TO-DO cambiar varible de bomb amount en player
            Destroy(gameObject);
        }
    }
}
