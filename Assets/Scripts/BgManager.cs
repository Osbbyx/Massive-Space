using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgManager : MonoBehaviour
{
    private float _speed;
    void Start()
    {
        _speed = 6;
    }

    void Update()
    {
        EnemyLimitAndRespawn();
        bgMovement();
    }

    public void bgMovement()
    {
        transform.Translate(Vector3.down *_speed  *Time.deltaTime );
    }

    public void EnemyLimitAndRespawn()
    {
        if (transform.position.y <= -39.78)
        {
            transform.position = new Vector3(0, 39.6f, 8);
        }
    }
}
