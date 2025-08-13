using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public enum WeatherType { Sun, Rain, Snow }
public class WeatherSystem : MonoBehaviour
{

    public WeatherType weatherType;

    public static event Action<WeatherType> weatherAction;

    [SerializeField] private GameObject[] weatherParticles;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(15f);

            int weatherCount = Enum.GetValues(typeof(WeatherType)).Length;

            int ranIndex = Random.Range(0, weatherCount);

            weatherType = (WeatherType)ranIndex;
            Debug.Log($"현재날씨 : {weatherType}");

            foreach (var particle in weatherParticles)
            {
                particle.SetActive(false);
            }
            weatherParticles[ranIndex].SetActive(true);

            weatherAction?.Invoke(weatherType);
        }
    }
}
