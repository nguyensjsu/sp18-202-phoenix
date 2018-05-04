using UnityEngine;
using System.Collections;

public class BombActivator : MonoBehaviour
{

    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("bomb_trigger");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Boom()
    {
        animator.Play("bomb");
        yield return new WaitForSeconds(0.7f);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("enemy") || 
            coll.gameObject.CompareTag("boss") || coll.gameObject.CompareTag("enemy_goomba") || coll.gameObject.CompareTag("enemy_rt"))
        {
            StartCoroutine(Boom());
        }
    }

}
