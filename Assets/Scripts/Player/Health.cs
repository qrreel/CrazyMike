using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] Transform livesPrefab;

    public float livesNum = 3f;
    float firstLivePositionX = 0.11f;
    float spaceBetweenLives = 0.11f;

    private void Awake()
    {
        UpdateLives();
    }

    public void UpdateLives()
    {
        foreach (Transform childTransform in transform) Destroy(childTransform.gameObject);

        for (int i = 0; i < livesNum; i++)
        {
            Vector3 live = livesPrefab.transform.position;
            live.x = firstLivePositionX - (spaceBetweenLives * i);
            livesPrefab.transform.position = live;

            Instantiate(livesPrefab, transform);
        }
    }

}
