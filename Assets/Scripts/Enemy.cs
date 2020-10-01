
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private GameObject _bulletContainer;
    private bool _stopSpawn;
    [SerializeField]
    private GameObject _enemyBullet;
    private int _control;
    private int _numeroPowerUp;

    [SerializeField]
    private GameObject _PowerUpVida;
    [SerializeField]
    private GameObject _PowerUpBullet;
    [SerializeField]
    private GameObject _PowerUpSpeed;

    private Player _player;
    private Animator _aDeath;
    private GameManager _gm;

    private int _vida;
    private int _conteo;
  
    private AudioManager _am;

    void Start()
    {
         _player = GameObject.Find(StaticStrings.GOplayer).GetComponent<Player>();
        _speed = 2;
        StartCoroutine(SpawnRoutine());
        _control = 1;
        _numeroPowerUp = Random.Range(1,50);
        _aDeath = GetComponent<Animator>();
        _gm = GameObject.Find(StaticStrings.gameManager).GetComponent<GameManager>();
        _conteo = 1;
        _vida = 0;
        AumentarVida();
        _am = GameObject.Find("EnemyAudio").GetComponent<AudioManager>();
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == StaticStrings.laser)
        {
            Destroy(other.gameObject);
            Damage();
            if (this.tag == StaticStrings.enemy)
            {
                
                if (_player != null)
                {
                    _player.AddScore(10);
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

               

            }
               
            this.tag = StaticStrings.destruido;

            
        }
    }

    public void Damage()
    {
        _vida--;
        if (_vida < 1)
        {
           // _aDeath.SetTrigger(StaticStrings.enemyDeath);
            if (_conteo == 1)
            {

            _gm.IncreseEnemyDeath();
                _conteo = 2;
            }
            _am.playAudio();
            Destroy(this.gameObject);
           
        }
    }

    public void AumentarVida()
    {
        _vida += _gm._cada10Round;
    }

    IEnumerator SpawnRoutine()
    {

        while (_stopSpawn == false)
        {
            if(_control == 1)
            {
                Vector3 position = new Vector3(transform.position.x, transform.position.y);
                GameObject newEnemy = Instantiate(_enemyBullet, position, Quaternion.identity);
                newEnemy.transform.parent = _bulletContainer.transform;
               
            }
            yield return new WaitForSeconds(Random.Range(1f, 10f));

        }
    }
}



//---------------------------------------------------------------------------------------------------------------------------//

/*   EnemyLimitAndRespawn();*/
/* EnemyMovement(); */



/*public void EnemyMovement()
    {
        if (_enemies.transform.position.x > 0f)
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
            
            
        }   

        else if (_enemies.transform.position.x < -1.19f)
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
            
        }
        }*/

/* public void EnemyLimitAndRespawn()
 {
     if(transform.position.y < -5.14)
     {
         transform.position = new Vector3(Random.Range(-10f , 10f),5.3f,0);
     }
 }*/



// if (other.tag == StaticStrings.player)
//{
//cuando quiera un metodo de un objeto x en collisione , se busca el componente y su tipo como en el siguiente ejemplo
/*Player player = other.GetComponent<Player>();

if(player != null)
{
    player.Damage();
}
Destroy(this.gameObject);*/

//cuando no tenga vida que reincie el lvl
//SceneManager.LoadScene(StaticStrings.level1);
// }
