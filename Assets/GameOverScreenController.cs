using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DeliveryDroneGame.Utils;

namespace DeliveryDroneGame
{
    public class GameOverScreenController : MonoBehaviour
    {
        [SerializeField]
        private Button playAgainButton;
        [SerializeField]
        private Button mainMenuButton;
        [SerializeField]
        private Button exitButton;

        private void Awake()
        {
            playAgainButton.onClick.AddListener(HandlePlayAgainButtonClick);
            mainMenuButton.onClick.AddListener(HandleMainMenuButtonClick);
            playAgainButton.onClick.AddListener(HandleExitButtonClick);
        }

        private void HandlePlayAgainButtonClick()
        {
            Loader.Load(Loader.Scene.GameScene);
        }

        private void HandleMainMenuButtonClick()
        {
            Loader.Load(Loader.Scene.MainMenu);
        }

        private void HandleExitButtonClick()
        {
            Application.Quit();
        }

    }
}
