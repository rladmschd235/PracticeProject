using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject rocketPrefab;
    [SerializeField] float playerSpeed = 5f;
    private Rigidbody2D rigid = null;
    Collider c;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(x, y, 0);

        rigid.velocity = dir * playerSpeed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.5f, 3.5f), Mathf.Clamp(transform.position.y, -6.5f, 6.5f));

        shot();
    }

    void shot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject rocket = RocketSpawnManager.Instance.Pop(rocketPrefab);
            rocket.transform.position = this.transform.position;
        }
    }
}
