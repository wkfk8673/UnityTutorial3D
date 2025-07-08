using System.Collections;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bombPrefab;

    public int rangeX = 5;
    public int rangeY = 5;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            RespawnBomb();
        }
    }

    private void RespawnBomb()
    {
        float ranX = Random.Range(-rangeX, rangeX + 1);
        float ranY = Random.Range(-rangeY, rangeY + 1);

        Vector3 ranPos = new Vector3(ranX, 10f, ranY);

        Instantiate(bombPrefab, ranPos, Quaternion.identity);
    }
}
