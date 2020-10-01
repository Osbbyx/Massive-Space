using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed;
 
    void Update()
    {
        LaserMovement();
        if(transform.position.y > 7.12)
        {
            if(transform.parent != null){
                Destroy(transform.parent.gameObject);
            }
            LaserLimit();
        }
    }

    public void LaserMovement()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }

    public void LaserLimit()
    {
        Destroy(this.gameObject);
    }
}

