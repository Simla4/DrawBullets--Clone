using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] NavMeshAgent nMesh;
    public float speed;
    void Update()
    {
        InputManager.Instance.TaptoPlay();
        PlayerMovementHandler();
    }

    private void PlayerMovementHandler()
    {
        if(InputManager.Instance.isGameStart == true)
        {
            //gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed);
            nMesh.destination = player.position;
        }
    }
}
