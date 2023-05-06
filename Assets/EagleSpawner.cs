using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpawner : MonoBehaviour
{
    [SerializeField] Eagle eagle;
    [SerializeField] Character character;
    [SerializeField] float initialTimer;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = initialTimer;
        eagle.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0 && eagle.gameObject.activeInHierarchy == false)
        {
            eagle.gameObject.SetActive(true);
            eagle.transform.position = character.transform.position + new Vector3(0,0,12);
            character.SetMoveable(false);
        }

        timer -= Time.deltaTime;
    }

    public void ResetTimer()
    {
        timer = initialTimer;
    }
}
