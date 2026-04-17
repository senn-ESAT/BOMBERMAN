using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Transform PlayerTransform;
    public Transform bombStart;
    public GameObject Bomb;

    bool pause = false, fired = false;
    public bool bombAmount = false;
    float speed = 5;
    float VerticalValue = 0, HorizontalValue = 0, DeployBomb = 0;
    Vector3 movement;

    void Start()
    {
        PlayerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        VerticalValue = Input.GetAxis("Vertical");
        HorizontalValue = Input.GetAxis("Horizontal");
        DeployBomb = Input.GetAxis("Jump");


         // TO-DO no spam bombas y dessactivar colison bombas
        if(DeployBomb != 0 && fired == false){
            GameObject spawnBomb = Instantiate(Bomb, bombStart.position, PlayerTransform.rotation);
            fired = true;
        }

        if(DeployBomb == 0 && !bombAmount) { 
            fired = false;
        }
        

        movement = (PlayerTransform.forward * VerticalValue) + (PlayerTransform.right * HorizontalValue);
        movement = movement.normalized;

        PlayerTransform.position += speed * movement * Time.deltaTime;
    }
}
