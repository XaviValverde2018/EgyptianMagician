using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class lifeEnemyController : MonoBehaviour
{
    public EnemyManager _em;
    public Text t1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t1.text = _em.vidaEnemics.ToString();
    }
}
