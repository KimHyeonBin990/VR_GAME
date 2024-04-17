using UnityEngine;
using System.Collections; // 이 라인을 추가하세요

public class FlickerLight : MonoBehaviour
{
    Light myLight;
    public float minWaitTime = 0.1f;
    public float maxWaitTime = 0.5f;

    void Start()
    {
        myLight = GetComponent<Light>();
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            myLight.enabled = !myLight.enabled;
        }
    }
}