using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Thruster : MonoBehaviour
{
    private Rigidbody2D rb2b;
    [SerializeField] private float autoPower;
    [SerializeField] private float autoRate;
    [SerializeField] private bool autoOn;
    [SerializeField] private float maxAngularVelocity;

    void Start()
    {
        rb2b = GetComponentInParent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if (autoOn)
        {
            StartCoroutine(AutoThrust(autoPower));
        }
    }

    public void ApplyThrust(float power)
    {
        rb2b.AddTorque(power);
    }

    private IEnumerator AutoThrust(float power)
    {
        yield return new WaitForSeconds(1/autoRate);
        if(rb2b.angularVelocity < maxAngularVelocity && rb2b.angularVelocity > -maxAngularVelocity)
        {
            ApplyThrust(power);
        }
        
    }
}
