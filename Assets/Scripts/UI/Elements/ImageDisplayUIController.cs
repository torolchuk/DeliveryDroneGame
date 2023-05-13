using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DeliveryDroneGame
{
    public class ImageDisplayUIController : MonoBehaviour
    {
        [SerializeField]
        private Image image;

        public void SetSprite(Sprite sprite)
        {
            image.sprite = sprite;
        }
    }
}
