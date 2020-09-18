using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int damage;
    public ParticleSystem explosion;

    public int GetDamage()
    {
        return damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "ForceField_PowerUp")
        {
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        }
    }
}
