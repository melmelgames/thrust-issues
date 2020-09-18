using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    private bool isActive;
    [SerializeField] private float powerupDuration;

    // Update is called once per frame
    void Update()
    {
        isActive = gameObject.activeSelf;
        if (isActive)
        {
            StartCoroutine(CountDownToSetInactive());
        }
    }

    private IEnumerator CountDownToSetInactive()
    {
        yield return new WaitForSeconds(powerupDuration);
        SetInactive();
    }

    private void SetInactive()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Destroy(collision.gameObject);
        }
    }

}
