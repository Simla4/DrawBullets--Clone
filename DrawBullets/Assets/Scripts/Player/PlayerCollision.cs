using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] GameObject enemy;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Failed");
            playerMovement.speed = 0;
        }
        else if(other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Win");
            playerMovement.speed = 0;
            enemy.SetActive(false);
        }
    }
}
