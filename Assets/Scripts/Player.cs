
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _speed;
    private Vector3 _offset;
    [SerializeField]
    private Vector3 _offset2;
    [SerializeField]
    private GameObject _shootPosition;
    private float _ihorizontal;
    [SerializeField]
    private int _lives;
    private SpawnManager _spawnManager;
    public int _laserCount;
    public GameObject[] lasers;
    private float _ShootTimeSpeed;
    [SerializeField]
    private int _score;
    private UiManager _uiManager;
    private BOSS _boss;
    public  bool bossActivate;
    [SerializeField]
    private AudioClip _laserSound;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioManager _am;
    [SerializeField]
    private AudioManager _amDead;

    private Animator _aDeath;

  

    private void Start()
    {
        _speed = 11;
        _offset = new Vector3(0,0.75f,0);
        _lives = 3;
        StartCoroutine(shoot());
        _offset2 = new Vector3(-1.68f,10.65f,-8.4f);
        _ShootTimeSpeed = 0.5f;
        _uiManager = GameObject.Find(StaticStrings.GOuiManager).GetComponent<UiManager>();
        bossActivate = false;
        _aDeath = GetComponent<Animator>();

        if (_uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL.");
        }
    }

    void Update()
    {
        PlayerMovement();
        PlayerLimit();
    }

    public void PlayerMovement()
    {
        _ihorizontal  = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(_ihorizontal , 0,0) * _speed * Time.deltaTime);
    }

    public void PlayerShoot()
    {
        if(_laserCount == 0)
                Instantiate(lasers[_laserCount], transform.position + _offset, Quaternion.identity);
        if(_laserCount > 0 )
            Instantiate(lasers[_laserCount], transform.position + _offset2, Quaternion.identity);

        _audioSource.Play();
    }

  

    public void PlayerLimit()
    {
        if(transform.position.x > 3.14f)
        {
            transform.position = new Vector3( -3.14f,transform.position.y,0);
        }
        if (transform.position.x < -3.14f)
        {
            transform.position = new Vector3(3.14f, transform.position.y, 0);
        }
    }

    public void Damage()
    {
        _lives--;
        _uiManager.UpdateLives(_lives);

        if(_lives < 1)
        {
            _amDead.playAudio();
            _aDeath.SetTrigger("Dead");
            Destroy(this.gameObject, 1.12f) ;
            _uiManager.GameOver(_score);
        }
    }

    IEnumerator shoot()
    {
        while (true)
        {
            PlayerShoot();
            yield return new WaitForSeconds(_ShootTimeSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == StaticStrings.vida)
        {
            _am.playAudio();
            Destroy(other.gameObject);
            if(_lives < 3)
            _lives++;
            _uiManager.UpdateLives(_lives);
        }
        if(other.tag == StaticStrings.bullet)
        {
            _am.playAudio();
            Destroy(other.gameObject);
            if(_laserCount <= 4)
            _laserCount++;
        }
        if(other.tag == StaticStrings.speed)
        {
            _am.playAudio();
            Destroy(other.gameObject);
            if (_ShootTimeSpeed <= 0.5 && _ShootTimeSpeed > 0.2)
                _ShootTimeSpeed = _ShootTimeSpeed - 0.1f;
        }
        if(other.tag == StaticStrings.boom)
        {
            _am.playAudio();
            Destroy(other.gameObject);
            bossActivate = true;
        }
    }

    public void AddScore(int point)
    {
        _score += point;
        _uiManager.UpdateScore(_score);
    }
}




//---------------------------------------------------------------------------------------------------------------------------//

//comunicandome con el Spawnmanager 
// _spawnManager.OnPlayerDeath();

/*  if (transform.position.y < -3.92f)
      {
          transform.position = new Vector3(transform.position.x, -3.92f, 0);
      }
      if (transform.position.y > 6.00f)
      {
          transform.position = new Vector3(transform.position.x, 6.00f, 0);
      }*/

// if (Input.GetKeyDown(KeyCode.Space) && Time.time > _ShootNewCoolD)
// {
//coolDown
//  _ShootNewCoolD = Time.time + _ShootCoolD;
//}

/* _iVertical = Input.GetAxis("Vertical");*/

//       PlayerShoot();

/*  _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
  if(_spawnManager == null)
  {
      Debug.LogError("The Spawn Manager is NULL");
  }*/

// _ShootCoolD = 0.15f;

/*  private float _iVertical;*/

// private float _ShootCoolD;
//private float _ShootNewCoolD;