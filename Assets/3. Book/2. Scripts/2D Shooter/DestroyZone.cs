using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet"))
        {
            other.gameObject.SetActive(false);
            //PlayerFire.Instance.bulletObjectPool.Add(other.gameObject);
            PlayerFire.Instance.bulletObjectPool.Enqueue(other.gameObject);
        }
        else
        {
            other.gameObject.SetActive(false);
            EnemyManager.Instance.enemyObjectPool.Enqueue(other.gameObject);
        }
    }
}
