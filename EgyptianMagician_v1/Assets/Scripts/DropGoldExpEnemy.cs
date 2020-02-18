using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class DropGoldExpEnemy : MonoBehaviour
{
    //This code is in Every Enemy
    [Header("Gold")]
    public GameObject _goldPrefab; // El size del _goldPrefab i el _goldvalue han de ser sempre el mateix
    public int _goldvalue; // Aquest valor i el size del _goldPrefab han de ser sempre el mateix
    public EnemyManager _enemymanager;
    public int randomvalue;
    public Transform _spawnsTransform;

    [Header("Exp")]
    public GameObject _expPrefab;
    public int _expvalue;
    public Transform _spawnsExpTransform;

    // Start is called before the first frame update
    void Start()
    {
       // randomvalue = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        DropDie();

    }
    void DropDie() {
        if (_enemymanager.vidaEnemics <= 0) {// no funciona del tot i abans si funcionava...
            Debug.Log("instantiate?");
            Instantiate(_goldPrefab, _spawnsTransform.transform.position, _goldPrefab.transform.rotation);
            Instantiate(_expPrefab, _spawnsExpTransform.transform.position, _expPrefab.transform.rotation);

        }
    }
   /* void DropDie() {
        if(_enemymanager.vidaEnemics <= 0) {
            Instantiate(_goldPrefab[0], _spawnsTransform[0].transform.position, _goldPrefab[0].transform.rotation);
            Instantiate(_goldPrefab[1], _spawnsTransform[1].transform.position, _goldPrefab[1].transform.rotation);
            Instantiate(_goldPrefab[2], _spawnsTransform[2].transform.position, _goldPrefab[2].transform.rotation);
            Instantiate(_expPrefab[0], _spawnsExpTransform[0].transform.position, _expPrefab[0].transform.rotation);
            Instantiate(_expPrefab[1], _spawnsExpTransform[1].transform.position, _expPrefab[1].transform.rotation);
        }
    }*/
}
