using UnityEngine;

namespace tott
{

    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField, Header("移動速度"), Range(0, 500)]
        private float moveSpeed = 3.5f;
        [SerializeField, Header("要偵測地板的圖層")]
        private LayerMask layerCheckGround;
        [SerializeField, Header("跳躍力道"), Range(0, 3000)]
        private float jumpPower = 1000;

        Rigidbody rb;

        [SerializeField, Header("檢查地板尺寸")]
        private Vector3 v3CheckGroundSize = Vector3.one;
        [SerializeField, Header("檢查地板位移")]
        private Vector3 v3CheckGroundOffset = Vector3.zero;
        private bool 地板Collision=false;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            MoveAndFlip();
            //CheckGround();
            Jump();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0, 0.3f, 0.5f);
            Gizmos.DrawCube(transform.position + v3CheckGroundOffset, v3CheckGroundSize);
        }

        private void Jump()
        {
            if (地板Collision && Input.GetKeyDown(KeyCode.Space))
            {
                print("jjjjjjj");
                地板Collision = false;
                rb.AddForce(new Vector3(0, jumpPower,0));
            }
        }
        private void MoveAndFlip()
        {
            float hor = Input.GetAxisRaw("Horizontal");
            float ver = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector3(hor * moveSpeed, rb.velocity.y, ver * moveSpeed);
        }
        //private bool CheckGround()
        //{
        //    //Collider2D hit = Physics2D.OverlapBox(transform.position + v3CheckGroundOffset, v3CheckGroundSize, 0, layerCheckGround);
        //   // Collider hit = Physics.OverlapBox(transform.position + v3CheckGroundOffset, v3CheckGroundSize, 0, layerCheckGround);
        //    //print($"<color=#69f>碰到的物件&#xff1a;{hit.name}</color>");
        //    return hit;
        //}
        private void OnCollisionStay(Collision other)
        {
            print(other.gameObject.tag);
            if (other.gameObject.tag == "Ground")
            {
                地板Collision = true;
            }
        }

    }
}

