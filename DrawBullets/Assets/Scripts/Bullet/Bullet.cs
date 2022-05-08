using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnEnable()
    {
        InputManager.OnBulletFire += FireBullet;
    }
    private void OnDisable()
    {
        InputManager.OnBulletFire -= FireBullet;
    }

    private void Update()
    {
        InputManager.Instance.FireBullet();
    }

    private void FireBullet()
    {
        var pos = gameObject.transform.position;
        SpawnManager.Instance.SpawnBullet("Bullet",
            new Vector3(pos.x, pos.y + 1, pos.z + 1),
            Quaternion.identity);

            Debug.Log("Action working...");
    }
}
