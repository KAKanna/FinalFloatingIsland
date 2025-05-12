using System.Collections;
using UnityEngine;

public class Enemy4 : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        StartCoroutine(Destroying());
    }
    IEnumerator Destroying()
    {
        yield return new WaitForSeconds(2f);
        speed = 15;
        yield return new WaitForSeconds(2f);
        speed = 20;
        yield return new WaitForSeconds(2f);
        speed = 25;
        yield return new WaitForSeconds(2f);
        speed = 30;
        yield return new WaitForSeconds(20f);
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
