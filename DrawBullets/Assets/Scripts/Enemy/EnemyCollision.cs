using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCollision : MonoBehaviour
{
    //Bullet bullet => FindObjectOfType<Bullet>();
    [SerializeField] NavMeshAgent nMesh;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            nMesh.speed = 0;
        }

        if(other.gameObject.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
            // bullet.availableBullet ++;
            // StopCoroutine(bullet.a);
            gameObject.SetActive(false);
        }
    }
}
