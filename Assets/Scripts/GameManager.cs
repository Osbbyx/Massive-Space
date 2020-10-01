using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver;
    [SerializeField]
    private GameObject _panelCredits;
    [SerializeField]
    private GameObject [] _groupEnemy;
    [SerializeField]
    private GameObject _spawnEnemy;
    private int _Round;
    private int _enemyDeath;
    private bool _cambioRonda;
    public int _cada10Round;
    public Ronda roundFinally;
   
    
    private void Start()
    {
        _cambioRonda = true;
        StartCoroutine(spawnManager());
       
    }


    void Update()
    {
       

        
    }

    public void GameOver()
    {
        _isGameOver = true;
    }

    public void ResetScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(StaticStrings.level1);// podemos ver el numero de la escena en el build
    }

    // del gameplay al menu
    public void MenuBack()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(StaticStrings.menu);
    }

    //del credits o spaceship al menu
    public void BackMenuDesactive()
    {
        _panelCredits.SetActive(false);
    }
    public void BackMenuActive()
    {
        _panelCredits.SetActive(true);
    }

    public void IncreseEnemyDeath()
    {
        if (_enemyDeath < 9 )
            _enemyDeath++;
         if (_enemyDeath == 9 )
        {
           
            _enemyDeath = 0;
            _Round++;
            _cambioRonda = true;
            
        }   
        
    }

    public void ResetyPotente()
    {
        _cada10Round += 6;
        _Round = 0;
        _cambioRonda = true;
        roundFinally.activar();


    }

    IEnumerator spawnManager()
    {
        while (true)
        {
            if(_cambioRonda == true)
            {
                Instantiate(_groupEnemy[_Round], _spawnEnemy.transform.position, Quaternion.identity);
                _cambioRonda = false;
            }
            yield return new WaitForSeconds(1f);
        }
        
    }

   

    //Instantiate(lasers[_laserCount], transform.position + _offset2, Quaternion.identity);
}
