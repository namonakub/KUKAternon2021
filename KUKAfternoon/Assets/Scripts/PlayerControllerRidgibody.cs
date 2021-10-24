using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerRidgibody : MonoBehaviour
{
    public float speed = 2f;
    public float rotSpeed = 10f;
    float newRatY=0;
    public GameObject prefabBullet;
    public Transform gunPosition;
    public float gunPower = 15f;
    public float gunCooldown = 2f;
    public float gunCooldownCount = 0;
    public bool hasGun = false;
    public int bulletCount = 0;
    public int coinCount = 0;
    PlaygroundScenesManager manager;
    public AudioSource audioCoin;
    public AudioSource audioFire;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        manager = FindObjectOfType<PlaygroundScenesManager>();
        if (manager == null)
        {
            print("Manager not found!");
        }
        if(PlayerPrefs.HasKey("CoinCount"))
        { coinCount = PlayerPrefs.GetInt("CoinCount");}
        manager.SetTextCoin(coinCount);
    
            

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        float horizontal = Input.GetAxis("Horizontal")*speed;
        float vertical = Input.GetAxis("Vertical")*speed;
        if(horizontal > 0)
        {
            newRatY = 90;
        }
        else if(horizontal < 0)
        {
            newRatY = -90;
        }
        if (vertical > 0)
        {
            newRatY = 0;
        }
        else if(vertical < 0)
        {
            newRatY = 180;
        }

        rb.AddForce(horizontal, 0, vertical, ForceMode.VelocityChange);
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, newRatY, 0), transform.rotation, rotSpeed);

        
       
    }
    private void Update()
    {
        
        gunCooldownCount = gunCooldownCount + Time.deltaTime;
        if(Input.GetButtonDown("Fire1") && (bulletCount > 0) && gunCooldownCount >= gunCooldown)
        {
           gunCooldownCount=0;
           GameObject bullet = Instantiate(prefabBullet,gunPosition.position,gunPosition.rotation);
           bullet.GetComponent<Rigidbody>().AddForce(transform.forward * gunPower, ForceMode.Impulse);
           Destroy(bullet, 2f);
            audioFire.Play();
            bulletCount--;
            manager.SetTextBullet(bulletCount);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "collectable")
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "collectable")
        {
            Destroy(other.gameObject);
            coinCount++;
            manager.SetTextCoin(coinCount);
            audioCoin.Play();
            PlayerPrefs.SetInt("CoinCount", coinCount);
        }

        if(other.gameObject.name == "Gun")
        {
            Destroy(other.gameObject);
            hasGun = true;
            bulletCount += 10;
            manager.SetTextBullet(bulletCount);
        }
    }
    

}
