using System.Collections;
using UnityEngine;

public class PowerDelete : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Destroying());
    }
    IEnumerator Destroying()
    {
        yield return new WaitForSeconds(5f);
        Deleteing();
    }
    void Deleteing()
    {
        Destroy(gameObject);
    }
}
