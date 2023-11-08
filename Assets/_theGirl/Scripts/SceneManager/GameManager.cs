using UnityEngine;

namespace tott
{
public class GameManager : MonoBehaviour
{
        SceneManager sceneManager;
        public GameObject displayOpenPaint;
        public GameObject displayClosePaint;
        public GameObject displayOpenGallery;
        public GameObject displayCloseGallery;
        private void Start()
        {
            sceneManager = GetComponentInChildren<SceneManager>();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GamePause();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ResumeGame();
            }
        }
        public void DisplayPaintBTN()
        {
            displayOpenPaint.SetActive(true);
        }
        public void DisplayClosePaintBTN()
        {
            displayClosePaint.SetActive(true);
        }
        public void DisplayOpenGalleryBTN()
        {
            displayOpenGallery.SetActive(true);
        }
        public void DisplayCloseGalleryBTN()
        {
            displayCloseGallery.SetActive(true);
        }
        public void HiddenPaintBTN()
        {
            displayOpenPaint.SetActive(false);
        }
        public void HiddenClosePaintBTN()
        {
            displayClosePaint.SetActive(false);
        }
        public void HiddenOpenGalleryBTN()
        {
            displayOpenGallery.SetActive(false);
        }
        public void HiddenCloseGalleryBTN()
        {
            displayCloseGallery.SetActive(false);
        }
        public void GamePause()
        {
            Time.timeScale = 0f;
            DisplayPaintBTN();
            DisplayClosePaintBTN();
            DisplayOpenGalleryBTN();
            DisplayCloseGalleryBTN();
            //sceneManager.OpenCanvasBTN();
            //sceneManager.CloseCanvasBTN();
            //sceneManager.OpenGalleryBTN();
            //sceneManager.CloseGalleryBTN();
        }
        public void ResumeGame()
        {
            Time.timeScale = 1.0f;
            HiddenPaintBTN();
            HiddenClosePaintBTN();
            HiddenOpenGalleryBTN();
            HiddenCloseGalleryBTN();
        }
    }

}

