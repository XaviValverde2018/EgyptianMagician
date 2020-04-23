using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour {
    // This code is in elJugador

    [SerializeField]
    public Joystick joystick;
    Vector3 forward, right;

    [Header("Status")]
    public float moveSpeed = 4f;
    public float lifePlayer;
    public float maxlifeplayer;
    public int LifePPGetInt;
    public float currentLifePlayer;
    public int ChangeValueLife;

    [Header("Movement")]
    public Rigidbody rigidbodyHorusVelocity;
    public bool isWalking;
    public Vector3 currentPos = new Vector3();
    public Vector3 oldPos = new Vector3();
    public GameObject playerpos;
    public float playerHeight = 0.98f;


    [Header("Particles")]
    public ParticleSystem rayoSolar;

    // variables del SHOOT
    [Header("Shoot")]
    public GameObject bulletBala;
    public GameObject posicioGenerarBulletBala;
    public float elapsedTime;
    public float FireRate;
    public float SpeedPPGetFloat;
    public comprobacioEnemicMesAprop _comprobacioEnemicMesAprop;

    [Header("Bird Activated")]
    public GameManager _gmActiveBird;
    public bool PC_GM_BirdActivated;
    public float moveBirdSpeed = 20f;
    public float birdHeight = 2.5f;
    public GameObject horusPrefab;
    public GameObject birdPrefab;
    public BoxCollider _boxcolliderBird;

    [Header("Boost Status")]
    public ActiveBoostPrefab _chooseBoost;
    public bool healthBoostActivated;
    public float elapsedTimeHealth;
    public float FireRateHealth = 0.5f;
    public float healthvalue = 20.0f;
    public Text healthText;
    public Animator healthanimation;
    public GameObject healthGO;
    public AudioSource shootHorusAudio;

    [Header("Animations")]
    public Animator walkHorusAnimation;
    public Animator shootHorusAnimation;
    public bool iswalkAnimation;
    public GameObject CetroWalk;
    public GameObject CetroShoot;
    public GameObject RayoWalk;
    public GameObject RayoShoot;
    // variables de find all enemies
    /*public GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
    public int closestIndex = 0;
    public float closestDistance = Mathf.Infinity;
    public float tempDistance;*/

    //public float lifePlayer = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

        //Primer inicialitzem les dues variables currentPos i oldPos i el boleà si esta en moviment
        currentPos = playerpos.transform.position;
        oldPos = currentPos;
        isWalking = false;

       
         

        currentLifePlayer = PlayerPrefs.GetFloat("CurrentLifePlayerPP");
        LifePPGetInt = PlayerPrefs.GetInt("numberbuyLifePP");
        ChangeValueLife = PlayerPrefs.GetInt("ChangeValueLifePP");
        if (ChangeValueLife==1) {
            lifePlayer = currentLifePlayer + (LifePPGetInt * 5);
            maxlifeplayer += (LifePPGetInt * 5);
            PlayerPrefs.SetInt("ChangeValueLifePP",0);
        } 
        else {
            lifePlayer = currentLifePlayer;
        }
   
        /*
        currentLifePlayer = PlayerPrefs.GetFloat("CurrentLifePlayer");
        LifePPGetInt = PlayerPrefs.GetInt("LifeBuyIncrementPP");
        lifePlayer = currentLifePlayer+LifePPGetInt;
        //maxlifeplayer = currentLifePlayer;
        maxlifeplayer += LifePPGetInt;
        //lifePlayer = maxlifeplayer;
        */
        SpeedPPGetFloat = PlayerPrefs.GetFloat("SpeedBuyIncrementPP");
        
        FireRate -= SpeedPPGetFloat;
    }

    // Update is called once per frame
    void Update()
    {
        
        /* arreglar 
        LifePPGetInt = PlayerPrefs.GetInt("LifePPBuy");
        maxlifeplayer += LifePPGetInt;
        */
        healthBoostActivated = _chooseBoost.Time_boost.healthBool;
        // logica per activar el modo BIRD
        PC_GM_BirdActivated = _gmActiveBird.GM_BirdActivated;
        if (PC_GM_BirdActivated) {
            Debug.Log("PC_GM_BirdActivated :"+PC_GM_BirdActivated);
            BirdPrefabActive();
            BirdMovement();
            _comprobacioEnemicMesAprop.distanciaMesAprop = 999.0f;
            _boxcolliderBird.enabled = false;
        } else {// logica normal, sense el modo BIRD
            ShootBullet();
            HorusPrefabActive();
            this.transform.position = new Vector3(transform.position.x, playerHeight, transform.position.z);
            _boxcolliderBird.enabled = true;

            //ClosestEnemyBullet(); DESCLICAR
            if (Input.anyKey) {
                MovePlayer();
            }
            IsPlayerInMovement();
 
        }
        DieHorus();
        PlayerPrefs.SetFloat("CurrentLifePlayerPP", lifePlayer);
        // PlayerPrefs.SetFloat("CurrentLifePlayer", lifePlayer);



    }

    void MovePlayer() {
        Vector3 direction = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        //Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * joystick.Horizontal; // right or left direction. 
        Vector3 upMovemenrt = forward * moveSpeed * Time.deltaTime * joystick.Vertical; // forward or back direction.

        Vector3 heading = Vector3.Normalize(rightMovement + upMovemenrt); // total direction direction

        transform.forward = heading; // de Z axis in worldspace. Green square.
        transform.position += rightMovement; // actualposition + new position
        transform.position += upMovemenrt; // actualposition + new position
        this.transform.position = new Vector3(transform.position.x, playerHeight, transform.position.z);
        //transform.LookAt(_comprobacioEnemicMesAprop.targetposition);
        _comprobacioEnemicMesAprop.distanciaMesAprop = 999.0f;
        walkHorusAnimation.SetBool("isWalk", true);
        RayoWalk.SetActive(true);
        CetroWalk.SetActive(true);
        RayoShoot.SetActive(false);
        CetroShoot.SetActive(false);


    }

    void IsPlayerInMovement() {//funcio per saber si el player s'esta movent. Si NO esta en moviment activarem el boolea. 
        currentPos = playerpos.transform.position;

        if(currentPos == oldPos) {//estem aturats
            isWalking = false;
            Debug.Log("estem quiets...");
        } else { //estem en moviment
            oldPos = currentPos;
            isWalking = true;
            Debug.Log("estem en moviment...");
        }
    }

    void ShootBullet() {
        elapsedTime += Time.deltaTime;

        
        if ((isWalking==false)&&(elapsedTime > FireRate)) {// disparar quan estigui quiet
            if (_comprobacioEnemicMesAprop.NoEnemicsOnRoom == false) {
                Instantiate(bulletBala, posicioGenerarBulletBala.transform.position, posicioGenerarBulletBala.transform.rotation);

                if (!shootHorusAudio.isPlaying) {
                    shootHorusAudio.Play();
                }
                elapsedTime = 0f;
            }
        } else {
            Debug.Log("no instantiate"); // no disparar quan estigui moventse. 
        }
        walkHorusAnimation.SetBool("isWalk", false);
        RayoWalk.SetActive(false);
        CetroWalk.SetActive(false);
        RayoShoot.SetActive(true);
        CetroShoot.SetActive(true);
    }
    void BirdMovement() {// función ocn la lógica de hacer daño al player
        Vector3 direction = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        //Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Vector3 rightMovement = right * moveBirdSpeed * Time.deltaTime * joystick.Horizontal; // right or left direction. 
        Vector3 upMovemenrt = forward * moveBirdSpeed * Time.deltaTime * joystick.Vertical; // forward or back direction.

        Vector3 heading = Vector3.Normalize(rightMovement + upMovemenrt); // total direction direction

        transform.forward = heading; // de Z axis in worldspace. Green square.
        transform.position += rightMovement; // actualposition + new position
        transform.position += upMovemenrt; // actualposition + new position
        this.transform.position = new Vector3(transform.position.x, birdHeight, transform.position.z);
    }
    void HorusPrefabActive() {
        birdPrefab.SetActive(false);
        horusPrefab.SetActive(true);
    }
    void BirdPrefabActive() {
        horusPrefab.SetActive(false);
        birdPrefab.SetActive(true);

    }
    void AddLifePlayer() {
        if (lifePlayer < maxlifeplayer) {
            if (elapsedTimeHealth > FireRateHealth) {
                healthGO.SetActive(true);
                healthanimation.SetBool("isDamage", true);
                healthText.text = "+" + healthvalue;
                lifePlayer += healthvalue;
                StartCoroutine(HealthCountDown());
                elapsedTimeHealth = 0f;
            }
        }
    }
    void DieHorus() {
      if(lifePlayer <= 0) {
            Debug.Log("Die");
            walkHorusAnimation.SetBool("isDie", true);
            RayoWalk.SetActive(false);
            CetroWalk.SetActive(false);
            RayoShoot.SetActive(false);
            CetroShoot.SetActive(false);
            joystick.enabled = false;
            StartCoroutine(CountDown());

        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("meteoritoAnubis")) {
            lifePlayer -= 1.0f;
        }
    }
    private void OnTriggerStay(Collider other) {
        elapsedTimeHealth += Time.deltaTime;
        if (other.CompareTag("health")) {
            AddLifePlayer();
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("health"))
        elapsedTimeHealth = 0f;
    }
    IEnumerator CountDown() {  
        yield return new WaitForSeconds(2);
        //Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("menu_principal_GOOD");
    }
    IEnumerator HealthCountDown() {
        yield return new WaitForSeconds(0.8f);
        healthanimation.SetBool("isDamage", false);
        healthGO.SetActive(false);
    }



}
