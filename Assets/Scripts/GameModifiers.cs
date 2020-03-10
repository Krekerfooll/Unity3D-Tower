using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModifiers : MonoBehaviour
{
    public static GameModifiers gameModifiers;

    public List<float> mainTimeParameters;
    private float mainTimeParametersSum;

    private void Awake()
    {
        if (gameModifiers == null)
        {
            gameModifiers = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public float ModifyByMainTimeParameters(float value)
    {
        return value * mainTimeParametersSum;
    }

    public void UpdateMainTimeParametersSum()
    {
        mainTimeParametersSum = 0;
        foreach (float item in mainTimeParameters)
        {
            mainTimeParametersSum += item;

        }
    }

    public void AddMainTimeParameter(float value)
    {
        mainTimeParameters.Add(value);
        UpdateMainTimeParametersSum();
    }

    public void RemoveMainTimeParameter(float value)
    {
        mainTimeParameters.Remove(value);
        UpdateMainTimeParametersSum();
    }
}
