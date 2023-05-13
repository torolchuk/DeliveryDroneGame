using System.Collections;
using System.Collections.Generic;
using DeliveryDroneGame.Utils;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class LoadingScreneController : MonoBehaviour
    {
        private void Start()
        {
            Loader.LoaderCallback();
        }
    }
}
