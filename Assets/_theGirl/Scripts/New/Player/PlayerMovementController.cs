using UnityEngine;

namespace tott
{

    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField, Header("���ʳt��"), Range(0, 500)]
        private float moveSpeed = 3.5f;
        [SerializeField, Header("�n�����a�O���ϼh")]
        private LayerMask layerCheckGround;
        [SerializeField, Header("���D�O�D"), Range(0, 3000)]
        private float jumpPower = 1000;

        Rigidbody rb;

        [SerializeField, Header("�ˬd�a�O�ؤo")]
        private Vector3 v3CheckGroundSize = Vector3.one;
        [SerializeField, Header("�ˬd�a�O�첾")]
        private Vector3 v3CheckGroundOffset = Vector3.zero;
        private bool �a�OCollision=false;

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
            if (�a�OCollision && Input.GetKeyDown(KeyCode.Space))
            {
                print("jjjjjjj");
                �a�OCollision = false;
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
        //    //print($"<color=#69f>�I�쪺����&#xff1a;{hit.name}</color>");
        //    return hit;
        //}
        private void OnCollisionStay(Collision other)
        {
            print(other.gameObject.tag);
            if (other.gameObject.tag == "Ground")
            {
                �a�OCollision = true;
            }
        }

    }
}

