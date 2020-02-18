using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropParentNull : MonoBehaviour
{
    public GameObject gold;
    public GameObject exp;
    public EnemyManager _em;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_em.vidaEnemics <= 0) {
            gold.SetActive(true);
            exp.SetActive(true);
            gold.transform.parent = null;
            exp.transform.parent = null;
        }
    }
}
