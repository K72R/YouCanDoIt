using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [Header("시각 효과용 옵션")]
    public bool changeColorOnActivate = true;
    public Color activatedColor = Color.yellow;

    private bool isActivated = false;
    private Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActivated) return;

        if (other.CompareTag("Player"))
        {
            PlayerRespawn respawn = other.GetComponent<PlayerRespawn>();
            if (respawn != null)
            {
                respawn.SetRespawnPoint(transform);
                isActivated = true;
                Debug.Log("[Checkpoint] Respawn point updated!");

                if (changeColorOnActivate && rend != null)
                {
                    rend.material.color = activatedColor;
                }
            }
        }
    }
}
