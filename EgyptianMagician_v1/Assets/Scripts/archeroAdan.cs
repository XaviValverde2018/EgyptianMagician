using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class archeroAdan : MonoBehaviour {
    public List<GameObject> bosses;
    public List<GameObject> minions;

    public Transform player;

    public void EnemyDied(GameObject deadEnemy) {
        CheckExistance(bosses, deadEnemy);
        CheckExistance(minions, deadEnemy);

        CheckClosestEnemy(player.position);
    }

    private void CheckExistance(List<GameObject> list, GameObject enemy) {
        if (list.Contains(enemy)) {
            list.Remove(enemy);
        }
    }

    public GameObject CheckClosestEnemy(Vector3 playerPosition) {
        GameObject selectedEnemy = null;

        float lastDistance = 500f;

        for (int i = 0; i < minions.Count; i++) {
            RaycastHit result;

            if (Physics.Raycast(playerPosition, (minions[i].transform.position - playerPosition), out result)) {
                if (result.collider.CompareTag("Minion")) {
                    float currentDistance = Vector3.Distance(playerPosition, minions[i].transform.position);

                    if (lastDistance > currentDistance) {
                        lastDistance = currentDistance;
                        selectedEnemy = minions[i];
                    }
                }
            }
        }

        if (selectedEnemy == null) {
            for (int i = 0; i < bosses.Count; i++) {
                RaycastHit result;

                if (Physics.Raycast(playerPosition, (bosses[i].transform.position - playerPosition), out result)) {
                    if (result.collider.CompareTag("Boss")) {
                        float currentDistance = Vector3.Distance(playerPosition, bosses[i].transform.position);

                        if (lastDistance > currentDistance) {
                            lastDistance = currentDistance;
                            selectedEnemy = bosses[i];
                        }
                    }
                }
            }
        }

    }
}

public class Player : MonoBehaviour {

}

public class Enemy : MonoBehaviour {
    public float health = 10;

    private void Attack() {

    }

    private void Hit(float damage) {
        health -= damage;

        if (health < 0) {
            Die();
        }
    }

    void Die() {
        archeroAdan.EnemyDied(this.gameObject);
        gameObject.SetActive(false);
    }

}*/