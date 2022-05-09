using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Bullet : MonoBehaviour
{
    public int availableBullet = 5;

    private LineRenderer lineRenderer;
    private List<Vector3> points = new List<Vector3>();
    public Action<IEnumerable<Vector3>> OnNewPathCreated = delegate { };

    private void OnEnable()
    {
        InputManager.OnBulletFire += FireBullet;
    }
    private void OnDisable()
    {
        InputManager.OnBulletFire -= FireBullet;
    }

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        InputManager.Instance.FireBullet();
    }

    private void FireBullet()
    {
        StartCoroutine(FireRoutine(availableBullet));        
    }
    
    

    private IEnumerator FireRoutine(int count)
    {
        var pos = gameObject.transform.position;
        
        for(int i = 0; i < count; i++)
        {
            var bullet = ObjectPooler.Instance.SpawnFromPool("Bullet",
                new Vector3(pos.x, pos.y + 1, pos.z + 1),
                Quaternion.identity);
            availableBullet --;
            Debug.Log("Action working...");

            StartCoroutine(BulletSetActiveFalse(bullet));

            yield return new WaitForSeconds(0.2f);
        }
        yield break;
    }

    public IEnumerator BulletSetActiveFalse(GameObject bullet)
    {
        
        yield return new WaitForSeconds(1.5f);
        bullet.SetActive(false);
        availableBullet ++;
        
        yield break;
    }
}
