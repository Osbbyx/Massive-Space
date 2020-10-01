using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    
    void Start()
    {
    }

    void Update()
    {
        EnemyBulletMovement();
        EnemyBulletLimit();
    }

    public void EnemyBulletMovement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == StaticStrings.player)
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }
    }

    public void EnemyBulletLimit()
    {
        if (transform.position.y < -14f)
        {
            Destroy(this.gameObject);
        }
    }
}
