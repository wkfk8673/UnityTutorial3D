using UnityEngine;

namespace Pattern
{
    public class Game : MonoBehaviour
    {
        private void Start()
        {
            Player player = new Player();

            player.AddScore(100);
            player.AddScore(200);
            player.AddScore(1000);

        }

    }
}
