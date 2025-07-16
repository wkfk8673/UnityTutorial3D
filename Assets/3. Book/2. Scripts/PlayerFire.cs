using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    private GameObject bulletFactory;
    public GameObject firePosition;

    private void Start()
    {
        bulletFactory = Resources.Load<GameObject>("Bullet");
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePosition.transform.position; // ��ġ �ʱ�ȭ
            bullet.transform.SetPositionAndRotation(firePosition.transform.position, firePosition.transform.rotation);
        }


    }
}
