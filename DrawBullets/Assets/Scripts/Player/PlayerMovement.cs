using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private bool isStart = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isStart = true;
        }
        PlayerMovementHandler();
    }

    private void PlayerMovementHandler()
    {
        if(isStart == true)
        {
            player.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }
}
