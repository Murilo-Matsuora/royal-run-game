using System.Collections;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Animator animator;

    [Header("Collision Settings")]
    [SerializeField] float cooldownDuration = 1f;
    [SerializeField] float adjustChangeMoveSpeedAmount = -2f;
    const string hitString = "Hit";
    float cooldownTimer = 0f;
    LevelGenerator levelGenerator;

    void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (cooldownTimer < cooldownDuration) return;

        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
        animator.SetTrigger(hitString);
        cooldownTimer = 0f;
    }

}
