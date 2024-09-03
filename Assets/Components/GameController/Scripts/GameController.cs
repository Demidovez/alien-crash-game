using UnityEngine;

namespace GameControllerSpace
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance;

        private void Awake()
        {
            Instance = this;
        }
    }
}
