using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private int _speed;
    void Start()
    {
        _speed = 3;
    }

    void Update()
    {
        PowerUpsMovement();
        PowerUpsLimit();
    }

    public  void PowerUpsMovement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    public void PowerUpsLimit()
    {
        if(transform.position.y < -14f)
        {
            Destroy(this.gameObject);
        }
    }

    
}
