using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    //This code is in every Enemy

    [Header("Values EnemyFollow")]
    public float speed=3.0f;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
