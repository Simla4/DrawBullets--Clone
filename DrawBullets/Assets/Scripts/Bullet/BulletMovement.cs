using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        BulletMovementHandler();
    }

    private void BulletMovementHandler()
    {
        gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
