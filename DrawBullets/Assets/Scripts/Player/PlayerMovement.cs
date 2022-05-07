using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float speed;
    //[SerializeField] private bool isGameStart = false;

    // Update is called once per frame
    void Update()
    {
        InputManager.Instance.TaptoPlay();
        PlayerMovementHandler();
    }

    private void PlayerMovementHandler()
    {
        if(InputManager.Instance.isGameStart == true)
        {
            player.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }
}
