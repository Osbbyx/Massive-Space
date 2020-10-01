using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private GameObject _enemyContainer;
    private bool _stopSpawn;
    private int _cantidad;
   
    public float _dominio;
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    void Update()
    {
        
    }


    IEnumerator SpawnRoutine()
    {

        while (_cantidad < 9)
        {
            _cantidad++;
            Vector3 position = new Vector3(Random.Range(-2.51f, 2.51f), _dominio);
            GameObject newEnemy = Instantiate(_enemy,position,Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(1f);
        }
        
    }

    public void OnPlayerDeath() =>
        _stopSpawn = true;
    
}
