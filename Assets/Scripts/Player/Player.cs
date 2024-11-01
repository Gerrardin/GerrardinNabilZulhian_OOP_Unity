using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator animator;

    private void Start()
    {
        // Mengambil informasi dari script PlayerMovement dan menyimpannya di playerMovement
        playerMovement = GetComponent<PlayerMovement>();

        // Mengambil informasi dari Animator dari EngineEffect dan menyimpannya di animator
        animator = transform.Find("Engine/EngineEffect").GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // Memanggil method Move dari PlayerMovement
        playerMovement.Move();
    }

    private void LateUpdate()
    {
        // Mengatur nilai Bool dari parameter IsMoving milik Animator
        animator.SetBool("IsMoving", playerMovement.IsMoving());
    }
}
