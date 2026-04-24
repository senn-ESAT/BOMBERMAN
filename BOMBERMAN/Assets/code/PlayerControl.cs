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

    // Vector3 dirMovement;
    // Vector3 dirMovementNorm;
    // Vector3 despVec;

    void Start()
    {
        PlayerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        VerticalValue = Input.GetAxis("Vertical");      // w <-> s
        HorizontalValue = Input.GetAxis("Horizontal");  // a <-> d
        DeployBomb = Input.GetAxis("Jump");             // space


        if(DeployBomb != 0 && fired == false){
            GameObject spawnBomb = Instantiate(Bomb, bombStart.position, PlayerTransform.rotation);
            fired = true;
        }

        if(DeployBomb == 0 && !bombAmount) { 
            fired = false;
        }
        
        // raycast for precalculating distance with other objects can be usefull
        // to make the collision sistem but i have to make shire it ignores the enemies

        /*
            GameObject temp = GameObject.Find("Target"); 
            trObjective = temp.GetComponent<Transform>();

            dirMovement = trObjective.position - PlayerTransform.position;
            if (dirMovement.magnitude >= radiusOffset){
            dirMovementNorm = dirMovement.normalized;

            despVec = dirMovementNorm * deltaMovePerFrame * Time.deltaTime;
            tr.position += despVec;
            }

        concepto muy disfuncional para el movimiento
        
        las tiles son de 5

        la distancia para el centro de la tile
        las tiles son de dimencion 5 entonces el resultado de la 
        cosa es lo que le falta para el centro
        var a = pos%5 - 2.5f 

        si el player deja de moverse ejecutamos el codigo de follow que hice antes
        y llevamos al player al centro de la tile
        lo bueno es que no tendremos problemas con rompernos entrando en los 
        muros porque nunca saldra un resultado adentro de los cosos 
        
        entonces seria 
        if(!enMovimiento){
            transform -> a
        }
        todo echo con el codigo de arriba

        pero ahora que lo pienso me basta hacer que se mueva de 5 en 5
        */



        movement = (PlayerTransform.forward * VerticalValue) + (PlayerTransform.right * HorizontalValue);
        movement = movement.normalized;

        PlayerTransform.position += speed * movement * Time.deltaTime;
    }
}
