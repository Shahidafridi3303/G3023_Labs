using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayNight : MonoBehaviour
{
    [SerializeField]
    Light2D sun;

    [SerializeField]
    Gradient colorOverTime;

    [SerializeField]
    float dayDurationSeconds = 60f;

    public float time = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

// Update is called once per frame
    void Update()
    {
        time += Time.deltaTime / dayDurationSeconds;
        time %= 1;
        sun.color = colorOverTime.Evaluate(time);
    }
}

