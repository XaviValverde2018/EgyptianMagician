using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HitTarget : MonoBehaviour
{
    public PlayerTargeting playertarget;
    public RoomNearest _roomNearest;
    public float health = 50f;
    public TextMesh textmeshlifeEnemy;
    public void TakeDamage(float amount) {
            playertarget.hitAudio.Play();
            playertarget.gota.SetActive(true);
            Debug.Log("holaaaaaaaa");
            health -= amount * Time.deltaTime; // cambiar per vida de veritat
            textmeshlifeEnemy.text = health.ToString("f0");
            if (health <= 0f) {
                Die();
            }
        } 
        
    
    void Die() {
        gameObject.SetActive(false);
        Destroy(gameObject);

    }
        
   
}
