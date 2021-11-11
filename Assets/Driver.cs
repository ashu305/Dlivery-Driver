using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 250f;
    [SerializeField] float moveSpeed  = 28f; 
    [SerializeField] float slowSpeedBy = 2;
    [SerializeField] float bostSpeedBy = 5;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Bost"){
            moveSpeed += bostSpeedBy;

            Destroy(other.gameObject, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        moveSpeed -= slowSpeedBy;
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal")* steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
