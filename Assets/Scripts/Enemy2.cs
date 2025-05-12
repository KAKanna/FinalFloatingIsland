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
        player = GameObject.Find("Player");
        StartCoroutine(Destroying());
    }
    IEnumerator Destroying()
    {
        yield return new WaitForSeconds(30f);
        Deleteing();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.transform.position - transform.position;
        //dir.Normalize();
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
