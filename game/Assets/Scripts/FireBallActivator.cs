using UnityEngine;
using System.Collections;

public class FireBallActivator : MonoBehaviour
{
    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Boom());
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine (Boom ());
    }

    IEnumerator Boom()
    {
        animator.Play("fire_hit");
        yield return new WaitForSeconds(0.07f);
        Destroy(this.gameObject);
    }
}
