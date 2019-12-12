using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTarget : MonoBehaviour
{
    public PlayerTargeting playertarget;
    public float health = 50f;
    public void TakeDamage(float amount) {
        playertarget.hitAudio.Play();
        playertarget.gota.SetActive(true);
       
            health -= amount * Time.deltaTime; // cambiar per vida de veritat
            if (health <= 0f) {
                Die();
            }
        
    }
    void Die() {
        gameObject.SetActive(false);
        Destroy(gameObject);

    }
        
    
}
