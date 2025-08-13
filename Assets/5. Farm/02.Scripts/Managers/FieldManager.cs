using System.Collections;
using UnityEngine;




public class FieldManager : MonoBehaviour
{
    public enum FieldState { None, Seed, Harvest }
    public FieldState fieldState = FieldState.None;

    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Vector2 fieldSize = new Vector2(8, 8);
    [SerializeField] private float tileSize = 2f;

    //[SerializeField] private GameObject currentPlant;
    [SerializeField] private int currentPlantIndex;

    [SerializeField] private GameObject[] plants;
    [SerializeField] private GameObject[] crops;


    private GameObject[,] tileArray;
    private Camera mainCamera;
    [SerializeField] private LayerMask fieldLayerMask;

    void Awake()
    {
        mainCamera = Camera.main;
        tileArray = new GameObject[(int)fieldSize.x, (int)fieldSize.y];

        CreateField();
        
    }

    private void Update()
    {
        if (fieldState != FieldState.None)
        {
            switch (fieldState)
            {
                case FieldState.Seed:
                    OnSeed();
                    break;
                case FieldState.Harvest:
                    OnHarvest();
                    break;
            }
        }
    }

    private void CreateField()
    {
        float offsetX = (fieldSize.x - 1) * tileSize / 2;
        float offsetY = (fieldSize.y - 1) * tileSize / 2;

        for (int i = 0; i < fieldSize.x; i++)
        {
            for (int j = 0; j < fieldSize.y; j++)
            {
                float posX = transform.position.x + i * tileSize - offsetX;
                float posZ = transform.position.z + j * tileSize - offsetY;

                GameObject tileObj = Instantiate(tilePrefab, transform.GetChild(0));

                tileObj.name = $"Tile_{i}_{j}";
                tileObj.transform.position = new Vector3(posX, 0, posZ);
                //tileArray[i, j] = tileObj;
                tileObj.GetComponent<Tile>().arrayPos = new Vector2Int(i, j); // tile 클래스의 정확한 위치 받아옴
            }
        }
    }

    private void OnSeed()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100f, fieldLayerMask))
            {
                Debug.Log(hit.collider.name);
                Tile tile = hit.collider.GetComponent<Tile>();
                int tileX = tile.arrayPos.x;
                int tileY = tile.arrayPos.y;

                if (tileArray[tileX,tileY] == null)
                {
                    GameObject plant = Instantiate(plants[currentPlantIndex], transform.GetChild(1));
                    plant.transform.position = hit.transform.position;

                    plant.GetComponent<Plant>().plantIndex = currentPlantIndex;

                    tileArray[tileX, tileY] = plant; // 대상에 타일 대신 식물 추가
                }
            }
        }
    }

    private void OnHarvest()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, fieldLayerMask))
            {
                Debug.Log(hit.collider.name);
                Tile tile = hit.collider.GetComponent<Tile>();
                int tileX = tile.arrayPos.x;
                int tileY = tile.arrayPos.y;

                if (tileArray[tileX, tileY] != null)
                {
                    Plant plant = tileArray[tileX, tileY].GetComponent<Plant>();

                    if (plant.isHarvest)
                    {
                        plant.gameObject.SetActive(false);
                        tileArray[tileX, tileY] = null;

                        // 타일 위치에서 생성
                        StartCoroutine(HarvestRoutine(plant.plantIndex, hit.transform.position));
                    }
                }
            }
        }
    }

    IEnumerator HarvestRoutine(int index, Vector3 pos)
    {
        int ranAmount = Random.Range(1, 4);
        for (int i = 0; i < ranAmount; i++)
        {
            GameObject crop = Instantiate(crops[index], transform.GetChild(2));
            crop.transform.position = pos + Vector3.up * 0.5f;
            Rigidbody cropRb = crop.GetComponent<Rigidbody>();

            float ranX = Random.Range(-2f, 2f);
            float ranZ = Random.Range(-2f, 2f);
            var forceDir = new Vector3(ranX, 5f, ranZ);

            cropRb.AddForce(forceDir, ForceMode.Impulse);

            yield return new WaitForSeconds(0.15f);
        }

        yield return null;
    }

    public void SetPlant(int index)
    {
        currentPlantIndex = index;
    }

    public void SetState(FieldState newState)
    {
        if(fieldState != newState)
        {
            fieldState = newState;
        }
    }
}
