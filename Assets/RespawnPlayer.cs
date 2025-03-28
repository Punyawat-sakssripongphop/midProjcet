using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public float threshold = -10f; // ถ้าตกต่ำกว่านี้จะ Respawn
    [SerializeField] private Transform respawnPoint; // จุด Respawn
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // ดึง Rigidbody ของ Player
    }

    void Update()
    {
        if (transform.position.y < threshold)
        {
            Debug.Log("Falling detected! Respawning..."); // เช็คว่ามีการตรวจจับการตก
            Respawn();
        }
    }

    private void Respawn()
    {
        if (respawnPoint != null)
        {
            Debug.Log("Respawning to: " + respawnPoint.position);

            // ปิดการตรวจสอบการชนชั่วคราว (แก้ปัญหาติด Collider)
            rb.isKinematic = true;

            // ใช้ MovePosition เพื่อป้องกันการติด Collider
            rb.MovePosition(respawnPoint.position);

            // รีเซ็ตความเร็ว
            rb.velocity = Vector3.zero;

            // เปิดการตรวจสอบการชนกลับมา
            rb.isKinematic = false;
        }
        else
        {
            Debug.LogWarning("Respawn Point ไม่ได้ถูกกำหนด!");
        }
    }
}