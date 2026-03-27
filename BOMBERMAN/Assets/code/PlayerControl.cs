using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Transform PlayerTransform;
    public Transform bombStart;
    public GameObject Bomb;

    float speed = 5;
    float VerticalValue = 0, HorizontalValue = 0, DeployBomb = 0;
    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        PlayerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        VerticalValue = Input.GetAxis("Vertical");
        HorizontalValue = Input.GetAxis("Horizontal");
        DeployBomb = Input.GetAxis("Jump");
         // TO-DO no spam bombas y dessactivar colison bombas
        if(DeployBomb != 0){
            GameObject spawnBomb = Instantiate(Bomb, bombStart.position, PlayerTransform.rotation);
        }

        movement = (PlayerTransform.forward * VerticalValue) + (PlayerTransform.right * HorizontalValue);
        movement = movement.normalized;

        PlayerTransform.position += speed * movement * Time.deltaTime;
    }
}
