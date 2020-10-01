using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    private float _speed;
    private bool _switch;
    void Start()
    {
      _speed = 2f;
        _switch = false;
    }

    void Update()
    {
        EnemyMovement();
    }

    public void EnemyMovement()
    {
        if (transform.position.x < 0f && _switch == false)
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
            if (transform.position.x > 0f && _switch == false)
            {
                _switch = true;
            }
        }

        if (transform.position.x > -1.19f && _switch == true)
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
            if (transform.position.x < -1.19f && _switch == true)
            {
                _switch = false;
            }
        }
    }
}




//----------------------------------------------------------------------------------------------------------------------------------//
/* if(transform.position.x > 0)
       {
           transform.Translate(Vector3.left * _speed * Time.deltaTime);
       }*/
/* transform.Translate(Vector3.left * _speed * Time.deltaTime);*/