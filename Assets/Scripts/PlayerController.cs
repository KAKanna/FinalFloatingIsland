using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject focalPoint;

    private Rigidbody rb;

    private InputAction moveAction;
    private InputAction smashAction;
    private InputAction breakAction;

    private bool hasPowerUp;
    private Coroutine runningSmashRoutine = null;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
        smashAction = InputSystem.actions.FindAction("Smash");
        breakAction = InputSystem.actions.FindAction("Break");
        
    }
    void Update()
    {
        focalPoint = GameObject.Find("FocalPoint");
        float verticalInput = moveAction.ReadValue<Vector2>().y;
        rb.AddForce(verticalInput * speed * focalPoint.transform.forward);

        if(breakAction.IsPressed())
        {
            rb.linearVelocity = Vector3.zero;
        }

        if(smashAction.triggered)
        {
            if(hasPowerUp == true)
            {
                runningSmashRoutine =  StartCoroutine(SmashRoutine());
            }
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            hasPowerUp = true;
            StartCoroutine(PowerUpCooldownRutine(10));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if(hasPowerUp)
            {
                Vector3 dir = collision.transform.position - transform.position;
                dir = dir.normalized;

                Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
                enemyRb.AddForce(dir * 10f, ForceMode.Impulse);
            }
        }
    }

    IEnumerator PowerUpCooldownRutine(float coolDownTime)
    {
        yield return new WaitForSeconds(coolDownTime);
        hasPowerUp = false;
        if(runningSmashRoutine != null)
        {
            StopCoroutine(runningSmashRoutine);
        }
    }

    IEnumerator SmashRoutine()
    {
        float chargeTime = 0;
        while (smashAction.IsPressed())
        {
            chargeTime += Time.deltaTime;
            yield return null;
            if(chargeTime >=2f)
            {
                break;
            }
        }

        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        for (int i = 0; i < enemies.Length; i++)
        {
            Rigidbody enemiesRb = enemies[i].gameObject.GetComponent<Rigidbody>();
            enemiesRb.AddExplosionForce(10f, transform.position, 100f, 0 , ForceMode.Impulse);
        }

        yield return null;
    }
}
