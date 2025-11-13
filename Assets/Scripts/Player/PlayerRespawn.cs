using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerRespawn : MonoBehaviour
{
    [Header("초기 리스폰 포인트 (없으면 Start에서 자기 위치 사용)")]
    public Transform defaultRespawnPoint;

    private Transform currentRespawnPoint;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if (defaultRespawnPoint != null)
        {
            currentRespawnPoint = defaultRespawnPoint;
        }
        else
        {
            GameObject temp = new GameObject("AutoRespawnPoint");
            temp.transform.position = transform.position;
            currentRespawnPoint = temp.transform;
        }
    }

    public void SetRespawnPoint(Transform newPoint)
    {
        currentRespawnPoint = newPoint;
        Debug.Log($"[Respawn] New respawn point set at {newPoint.position}");
    }

    public void Respawn()
    {
        if (currentRespawnPoint == null)
        {
            Debug.LogWarning("[Respawn] No respawn point set!");
            return;
        }

        transform.position = currentRespawnPoint.position;
        transform.rotation = currentRespawnPoint.rotation;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        Debug.Log($"[Respawn] Player respawned at {currentRespawnPoint.position}");
    }
}
