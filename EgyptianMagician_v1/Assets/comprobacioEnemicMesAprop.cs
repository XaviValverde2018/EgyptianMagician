using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comprobacioEnemicMesAprop : MonoBehaviour
{
    public List<GameObject> llistaEnemics = new List<GameObject>();
    public float distanciaEntrePlayerIEnemicActual;
    public float distanciaMesAprop;

    //variables per a borrar, son per TEST

    private void OnDrawGizmos() {
        for(int i=0; i< llistaEnemics.Count; i++) {
            RaycastHit hit;
            bool isHit = Physics.Raycast(transform.position, llistaEnemics[i].transform.position - transform.position, out hit);
            if (isHit && hit.transform.CompareTag("Enemy")) {
                Gizmos.color = Color.blue;
            } else {
                Gizmos.color = Color.red;
            }
            Gizmos.DrawRay(transform.position, llistaEnemics[i].transform.position - transform.position);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        distanciaMesAprop = 999.0f;
    }

    // Update is called once per frame
    void Update()
    {
        CalculAprop();

    }
    void CalculAprop() {
        if (llistaEnemics.Count != 0) {

            for (int i = 0; i < llistaEnemics.Count; i++) {// en aquest bucle busquem l'enemic de mes aprop.
                distanciaEntrePlayerIEnemicActual = Vector3.Distance(transform.position, llistaEnemics[i].transform.position);
                if (distanciaEntrePlayerIEnemicActual < distanciaMesAprop) {
                    distanciaMesAprop = distanciaEntrePlayerIEnemicActual;
                }
            }
            for (int i = 0; i < llistaEnemics.Count; i++) {// En aquest bucle tenim el enemic mes aprop. 
                if (distanciaMesAprop == Vector3.Distance(transform.position, llistaEnemics[i].transform.position)) {
                    transform.LookAt(llistaEnemics[i].transform);
                    Debug.Log("l'enemic mes aprop es: " + llistaEnemics[i].name);
                }
            }
            Debug.Log(distanciaMesAprop);
            //aqui fem el remove de la llista. 
        } else {
            Debug.Log("no queden enemics");
        }
    }
}
