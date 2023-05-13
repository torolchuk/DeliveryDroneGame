using System.Collections;
using System.Collections.Generic;
using DeliveryDroneGame.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace DeliveryDroneGame
{
    public class MainMenuScreenController : MonoBehaviour
    {
        [SerializeField]
        private Button playButton;
        [SerializeField]
        private Button exitButton;

        private void Awake()
        {
            playButton.onClick.AddListener(HandlePlayButtonClick);
            exitButton.onClick.AddListener(HandleExitButtonClick);
        }

        private void HandlePlayButtonClick()
        {
            Loader.Load(Loader.Scene.GameScene);
        }

        private void HandleExitButtonClick()
        {
            Application.Quit();
        }

        private void OnDestroy()
        {
            playButton.onClick.RemoveAllListeners();
            exitButton.onClick.RemoveAllListeners();
        }
    }
}
