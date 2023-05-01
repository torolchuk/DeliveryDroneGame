using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DeliveryDroneGame.Utils
{
    public static class Loader
    {
        public enum Scene
        {
            MainMenu,
            Loading,
            GameScene,
            GameOver
        }

        public static Scene targetScene;

        public static void Load(Scene targetScene)
        {
            Loader.targetScene = targetScene;
            SceneManager.LoadScene(Scene.Loading.ToString());
        }

        public static void LoaderCallback()
        {
            SceneManager.LoadScene(targetScene.ToString());
        }
    }

}

