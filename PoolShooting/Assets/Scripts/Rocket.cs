using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float rocketSpeed = 5f;
    private Rigidbody2D rocketRigid = null;

    private void Awake()
    {
        rocketRigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 dir = Vector3.up;

        rocketRigid.velocity = dir * rocketSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TargetBoard"))
        {
            RocketSpawnManager.Instance.Push(this.gameObject);
        }
    }
}
