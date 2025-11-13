using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpPower = 15f; // 점프 힘 조절

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 vel = rb.velocity;
            vel.y = 0;
            rb.velocity = vel;
            
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
}