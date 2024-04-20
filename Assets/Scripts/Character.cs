using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float upForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float radius; 


    private Rigidbody characterRb;
    //parametros de animaciones 
    private Animator characterAnimator;   
    void Start()
    {
        characterRb = GetComponent<Rigidbody>();
        characterAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(groundCheck.position, radius, ground);
        bool isGrounded = colliders.Length > 0; // Verifica si hay algún collider en el arreglo
        characterAnimator.SetBool("IsGrounded", isGrounded);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded) //saltar solo cuando este en el suelo 
            {
                characterRb.AddForce(Vector3.up * upForce);
            }
        }
    }

     //para visualizar el circulo del metodo de manera grafica 
    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.ShowGameOverScreen();
            characterAnimator.SetTrigger("Die");
            Time.timeScale = 0f;
        }
    }
}
