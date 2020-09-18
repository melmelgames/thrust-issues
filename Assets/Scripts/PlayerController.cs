using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject leftThruster;
    private Thruster thruster;
    public ParticleSystem leftJet;
    public ParticleSystem forceFieldPowerUp;
    private Rigidbody2D rb2D;
    private Transform shipBody;
    [SerializeField] private float fullPower;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float xBoundary;
    [SerializeField] private float yPosLock;
    public GameObject pickupParticles;
    public AudioClip pickupSound;
    public AudioClip powerupSound;
    public AudioClip healthSound;
    public GameObject startingExplosion;

    void Start()
    {
        thruster = leftThruster.GetComponent<Thruster>();
        rb2D = GetComponentInChildren<Rigidbody2D>();
        shipBody = rb2D.GetComponent<Transform>(); 
    }

    void Update()
    {
        ManageInput();
        MoveLeftRight();
        LockYPos();
        BoundMovementX();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Collectable")
        {
            Instantiate(pickupParticles, collision.transform.position, Quaternion.identity);
            AudioManager.PlaySound(pickupSound);
            Score.AddScore(collision.GetComponent<Collectable>().GetValue());
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Obstacle" && !forceFieldPowerUp.gameObject.activeSelf)
        {
            Health.SubtractHealth(collision.GetComponent<Obstacle>().GetDamage());
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "HealthItem")
        {
            Instantiate(pickupParticles, collision.transform.position, Quaternion.identity);
            AudioManager.PlaySound(healthSound);
            Health.AddHealth(collision.GetComponent<HealthItem>().GetValue());
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "PowerUp")
        {
            Instantiate(pickupParticles, collision.transform.position, Quaternion.identity);
            AudioManager.PlaySound(powerupSound);
            forceFieldPowerUp.gameObject.SetActive(true);
        }
    }
    public void StartFirstExplosion()
    {
        Instantiate(startingExplosion, gameObject.transform.position, Quaternion.identity);
    }
    private void ManageInput()
    {
        // activate left thruster
        if (Input.GetKeyUp(KeyCode.Space))
        {
            thruster.ApplyThrust(fullPower);
            leftJet.Play();
        }
    }

    private void MoveLeftRight()
    {
        // move left if angle is between 15 and 90
        if(shipBody.rotation.eulerAngles.z <= 110.0f && shipBody.rotation.eulerAngles.z > 20.0f)
        {
            shipBody.Translate(Vector3.left * turnSpeed * Time.deltaTime);
        }
        // move right if angle is between -15 and -90
        if (shipBody.rotation.eulerAngles.z >= 250.0f && shipBody.rotation.eulerAngles.z < 340.0f)
        {
            shipBody.Translate(Vector3.right * turnSpeed * Time.deltaTime);
        }
    }

    private void LockYPos()
    {
        transform.position = new Vector3(transform.position.x, yPosLock, 0.0f);
    }

    private void BoundMovementX()
    {
        if(transform.position.x > xBoundary)
        {
            transform.position = new Vector3(xBoundary, transform.position.y, 0.0f);
        }
        if(transform.position.x < -xBoundary)
        {
            transform.position = new Vector3(-xBoundary, transform.position.y, 0.0f);
        }
    }
}
