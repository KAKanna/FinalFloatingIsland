using System.Collections;
using UnityEngine;

public class Enemy5 : MonoBehaviour
{
    public float speed = 2f;
    [SerializeField]private GameObject baby;
    private Rigidbody rb;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Destroying());
    }
    IEnumerator Destroying()
    {
        yield return new WaitForSeconds(5f);
        Instantiate(baby,Vector3.zero, Quaternion.identity);
        yield return new WaitForSeconds(5f);
        Instantiate(baby,Vector3.zero, Quaternion.identity);
        yield return new WaitForSeconds(15f);
        Instantiate(baby, Vector3.zero, Quaternion.identity);
        Instantiate(baby, Vector3.zero, Quaternion.identity);
        Instantiate(baby, Vector3.zero, Quaternion.identity);
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
