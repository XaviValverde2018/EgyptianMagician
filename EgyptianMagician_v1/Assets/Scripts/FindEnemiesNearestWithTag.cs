/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEnemiesNearestWithTag : MonoBehaviour
{
    public List<GameObject> enemies;
    public float maxdistance = 99999.0f;
    public float currentdistance = 999.0f;
   
    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
        foreach(var enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
            var enemyScript = enemy.AddComponent<EnemyScript>();
            enemyScript.enemyManager = this;
            enemies.Add(enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CalcularEnemicMesAprop() {
        for(int i = 0; i < enemies.Count; i++) {
            if (Input.GetKeyDown(KeyCode.A)) {
                maxdistance = Vector3.Distance(transform.position, enemies[i].transform.position);
                if(maxdistance < currentdistance) {
                    currentdistance = maxdistance;
                }
                if(currentdistance == Vector3.Distance(transform.position, enemies[i].transform.position)) {
                    
                }
            }
        }
    }
}
*/