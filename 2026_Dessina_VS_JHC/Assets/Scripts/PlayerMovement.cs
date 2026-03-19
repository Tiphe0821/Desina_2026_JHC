using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    public float minX = -14.0f;
    public float maxX = 14.0f;
    public float minZ = -14.0f;
    public float maxZ = 14f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(x, 0.0f, z).normalized;                                   // 벡터를 단위벡터로 만든다

        Vector3 nextPosition = transform.position + moveDir * moveSpeed * Time.deltaTime;       // 다음 움직일 좌표

        nextPosition.x = Mathf.Clamp(nextPosition.x, minX, maxX);                               // 계산 결과로 나오는 x의 포지션이 지정된 좌표 범위 안인지 확인하고 만약 너무 크거나 작다면 최대값, 또는 최소값으로 값을 변경해준다.
        nextPosition.z = Mathf.Clamp(nextPosition.z, minZ, maxZ);

        if(moveDir != Vector3.zero)
        {
            transform.forward = moveDir; // 캐릭터의 보는 방향을 바꾸는 코드
        }
        
        
        transform.position = nextPosition;
    }
}
