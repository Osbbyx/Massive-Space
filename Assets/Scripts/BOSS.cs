using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS : MonoBehaviour
{
    private float _speed;
    private bool _switch;
    private int _vida;

    [SerializeField]
    private GameObject _PowerUpbomba;
    private int _numeroPowerUp;

    private GameManager _gm;
    private Player _player;

    [SerializeField]
    private GameObject _pos1;
    [SerializeField]
    private GameObject _pos2;
    [SerializeField]
    private GameObject _pos3;
    [SerializeField]
    private GameObject _pos4;
    [SerializeField]
    private GameObject _pos5;
    [SerializeField]
    private GameObject _pos6;
    [SerializeField]
    private GameObject _bossBullet;

    private bool _stopSpawn;
    private int _patron;

    void Start()
    {
        _speed = 3f;
        
        _gm = GameObject.Find(StaticStrings.gameManager).GetComponent<GameManager>();
        AumentarVida();
        transform.position = new Vector3(transform.position.x, transform.position.y, -0.1f);
        _vida = 1;
        _player = GameObject.Find(StaticStrings.player).GetComponent<Player>();
        AumentarVida();
        StartCoroutine(SpawnRoutine());
        _patron = 1;
    }

    
    void Update()
    {
        BossMovement();
        
        Damage();


    }

    public void BossMovement()//1.27f
    {
        if (transform.position.x < 1.27f && _switch == false)
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
            if (transform.position.x > 1.27f && _switch == false)
            {
                _switch = true;
            }
        }

        if (transform.position.x > -1.27f && _switch == true)
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
            if (transform.position.x < -1.27f && _switch == true)
            {
                _switch = false;
            }
        }
    }

    public void AumentarVida()
    {
        _vida += _gm._cada10Round;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == StaticStrings.laser)
        {
            
            _numeroPowerUp = Random.Range(1, 80);
            Destroy(other.gameObject);
           if(_numeroPowerUp == 64)
            {
                Instantiate(_PowerUpbomba);
            }

        }
    }

    public void Damage()
    {
        if(_player.bossActivate == true)
        {
            _vida--;
            _player.bossActivate = false;
        }
       
        if(_vida < 1)
        {
            _player.AddScore(300);
            _gm.ResetyPotente();
            _player.bossActivate = false;
            Destroy(this.gameObject);

        }
    }


    IEnumerator SpawnRoutine()
    {

        while (true)
        {
            
            {
                switch (_patron)
                {
                    case 1:
                        Instantiate(_bossBullet, _pos1.transform.position, Quaternion.identity);
                        _patron = 4;
                        break;
                    case 2:
                        Instantiate(_bossBullet, _pos2.transform.position, Quaternion.identity);
                        _patron = 5;
                        break;
                    case 3:
                        Instantiate(_bossBullet, _pos3.transform.position, Quaternion.identity);
                        _patron = 3;
                        break;
                    case 4:
                        Instantiate(_bossBullet, _pos4.transform.position, Quaternion.identity);
                        _patron = 2;
                        break;
                    case 5:
                        Instantiate(_bossBullet, _pos5.transform.position, Quaternion.identity);
                        _patron = 6;
                        break;
                    case 6:
                        Instantiate(_bossBullet, _pos6.transform.position, Quaternion.identity);
                        _patron = 1;
                        break;
                }
               
                
                yield return new WaitForSeconds(0.5f);
            }
            

        }
    }
}
