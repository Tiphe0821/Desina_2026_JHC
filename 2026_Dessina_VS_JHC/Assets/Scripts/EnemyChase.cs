using UnityEngine;
using UnityEngine.Assertions.Must;

public class EnemyChase : MonoBehaviour
{
    public float moveSpeed = 2.0f;

    private Transform target;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if(player != null)
        {
            target = player.transform;
        }
    }


    void Update()
    {
        if (target == null) return;

        Vector3 direction = target.position - transform.position;
        direction.y = 0;

        Vector3 moveDir = direction.normalized;

        transform.position += moveDir * moveSpeed * Time.deltaTime;

        if(moveDir != Vector3.zero)
        {
            transform.forward = moveDir;
        }
    }
}
