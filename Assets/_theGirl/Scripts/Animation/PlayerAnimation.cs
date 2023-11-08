
using UnityEngine;

namespace tott
{
    public class PlayerAnimation : MonoBehaviour
    {
        private Animator anim;
        private PlayerMovement playerMovement;
        private int velXHash, velYHash;

        private void Start()
        {
            anim = GetComponent<Animator>();
            playerMovement = GetComponentInParent<PlayerMovement>();
            velXHash = Animator.StringToHash("VelX");
            velYHash = Animator.StringToHash("VelY");
        }
        private void Update()
        {

        }
        private void OnMove()
        {
            Vector3 localMoveDirection = transform.InverseTransformDirection(playerMovement.moveDirection);
            Vector3 normalVel = Vector3.Normalize(localMoveDirection);
            Vector3 targetVel = Vector3.Lerp(localMoveDirection, normalVel, playerMovement.moveDirection.magnitude); print(localMoveDirection + "\t" + normalVel + "\t" + playerMovement.moveDirection.magnitude);

            anim.SetFloat(velXHash, targetVel.x);
            anim.SetFloat(velYHash, targetVel.z);
        }
    }

}
