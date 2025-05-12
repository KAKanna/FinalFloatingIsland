using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody rb;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        StartCoroutine(Destroying());
    }
    IEnumerator Destroying()
    {
        yield return new WaitForSeconds(10f);
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
}
