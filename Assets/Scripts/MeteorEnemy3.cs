using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorEnemy3 : MonoBehaviour
{
    private float _speed;
    private Player _player;
    private int _vida;
    [SerializeField]
    private GameObject _enemy2;
    private GameManager _gm;
    private int _Cantidad;
    private int _conteo;
    [SerializeField]
    private GameObject _PowerUpVida;
    [SerializeField]
    private GameObject _PowerUpBullet;
    [SerializeField]
    private GameObject _PowerUpSpeed;
    private int _numeroPowerUp;

    private AudioManager _am;

    void Start()
    {
        _speed = 3f;
        _player = GameObject.Find(StaticStrings.GOplayer).GetComponent<Player>();
        _gm = GameObject.Find(StaticStrings.gameManager).GetComponent<GameManager>();
        /*StartCoroutine(SpawnMeteor());*/
        _Cantidad = 0;
        _vida = 3;
        _conteo = 1;
        _numeroPowerUp = Random.Range(1, 50);
        AumentarVida();
        _am = GameObject.Find("EnemyAudio").GetComponent<AudioManager>();
    }


    void Update()
    {
        MeteorDamage();
        MeteorLimit();
       

    }

    public void MeteorDamage()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

    }

    public void MeteorLimit()
    {
        if (transform.position.y < -13f)
        {
            transform.position = new Vector3(Random.Range(-2.51f, 2.51f), 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == StaticStrings.laser)
        {

            Destroy(other.gameObject);
            Damage();

        }
        if (other.tag == StaticStrings.player)
        {

            _player.Damage();
            Damage2();
            _am.playAudio();
            Destroy(this.gameObject);
            

        }
    }

    public void Damage()
    {
        _vida--;
        if (_vida < 1)
        {
            if(_conteo == 1)
            {
                _player.AddScore(30);
                _gm.IncreseEnemyDeath();
                _conteo = 2;
                switch (_numeroPowerUp)
                {
                    case 23:
                        Instantiate(_PowerUpVida);
                        break;
                    case 46:
                        Instantiate(_PowerUpBullet);
                        break;
                    case 17:
                        Instantiate(_PowerUpSpeed);
                        break;
                }
            }
            _am.playAudio();
            Destroy(this.gameObject);
        }
    }

    public void Damage2()
    {


        if (_conteo == 1)
        {
            _player.AddScore(50);
            _gm.IncreseEnemyDeath();
            _conteo = 2;
            switch (_numeroPowerUp)
            {
                case 23:
                    Instantiate(_PowerUpVida);
                    break;
                case 46:
                    Instantiate(_PowerUpBullet);
                    break;
                case 17:
                    Instantiate(_PowerUpSpeed);
                    break;
            }
        }

        Destroy(this.gameObject);

    }

    public void AumentarVida()
    {
        _vida += _gm._cada10Round;
    }


    /* IEnumerator SpawnMeteor()
     {
         while (_Cantidad < 9)
         {
             _Cantidad++;
             Vector3 position = new Vector3(Random.Range(-2.51f, 2.51f), 0);
             Instantiate(_enemy2, position, Quaternion.identity);


             yield return new WaitForSeconds(5f);
         }
     }*/
}