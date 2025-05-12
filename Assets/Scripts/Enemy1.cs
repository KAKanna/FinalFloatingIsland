using System.Collections;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speed = 7f;
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
        yield return new WaitForSeconds(3f);
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
}
