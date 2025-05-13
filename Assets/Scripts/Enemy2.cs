using System.Collections;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;
    private GameObject player;
    [SerializeField] private float torque;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Destroying());
    }
    IEnumerator Destroying()
    {
        yield return new WaitForSeconds(30f);
        Deleteing();
    }

    void Update()
    {
        Vector3 dir = player.transform.position - transform.position;
        dir = dir.normalized;
        rb.AddForce(dir*speed);
    }
    void Deleteing()
    {
        Destroy(gameObject);
    }
    void FixedUpdate()
    {
        rb.AddTorque(torque, 0, 0);
    }
}
