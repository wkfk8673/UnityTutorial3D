using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private enum PlantState { Level1, Level2, Level3}
    private PlantState plantState;

    private DateTime startTime, growthTime, harvestTime; // 레벨 변경 시간

    public int plantIndex;
    public bool isHarvest = false;


    private void Awake()
    {
        startTime = DateTime.Now;
        growthTime = startTime.AddSeconds(5);
        harvestTime = startTime.AddSeconds(10);

        // DateTime.Now : 현재 시간 >> 게임 재접속 시에도 반영
        // Time.time : 게임 실행 시간 >> 게임 재접속 시에 미반영, 접속중에만 성장
    }

    private void OnEnable()
    {
        WeatherSystem.weatherAction += SetGrowth;
    }

    private void OnDisable()
    {
        WeatherSystem.weatherAction -= SetGrowth;
        
    }

    IEnumerator Start()
    {
        SetState(PlantState.Level1);
        while (plantState != PlantState.Level3)
        {
            if(DateTime.Now >= harvestTime)
            {
                SetState(PlantState.Level3);
                isHarvest = true;
            }
            else if(DateTime.Now >= growthTime)
            {
                SetState(PlantState.Level2);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    private void SetState(PlantState newState)
    {
        if(plantState != newState || plantState == PlantState.Level1)
        {
            plantState = newState;

            for (int i = 0; i < 3; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false); // 흙 빼고 끄기
            }

            transform.GetChild((int)plantState).gameObject.SetActive(true);
        }
    }

    private void SetGrowth(WeatherType weatherType)
    {
        switch (weatherType)
        {
            case WeatherType.Sun:
                break;
            case WeatherType.Rain:
                break;
            case WeatherType.Snow:
                break;
            default:
                break;
        }
    }
}
