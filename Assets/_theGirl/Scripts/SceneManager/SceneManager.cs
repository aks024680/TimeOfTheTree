using Unity.VisualScripting;
using UnityEngine;
namespace tott
{
    public class SceneManager : MonoBehaviour
    {
        Animator animator;
        public GameObject paintBNT;
        public GameObject theGallery;
        public void OpenCanvasBTN()
        {
            paintBNT.SetActive(true);  
        }
        public void CloseCanvasBTN()
        {
            paintBNT.SetActive(false);
        }
        public void OpenGalleryBTN()
        {
            theGallery.SetActive(true);
            //animator.SetTrigger("FlipBookTrigger");
        }
        public void CloseGalleryBTN()
        {
            theGallery.SetActive(false);
        }
    }

}
