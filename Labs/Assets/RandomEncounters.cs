using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomEncounters : MonoBehaviour
{
    [SerializeField] private GameObject encounter;

    Rigidbody2D body;
    public float distanceTravelledSinceLastEncounter = 0;

    [Range(0f, 100000f)]
    [SerializeField]
    public float minEncounterDistance = 2;

    void Start()
    {
        SceneManager.LoadScene("Battle", LoadSceneMode.Additive);
        encounter = GameObject.Find("BattleCanvas");
        SceneManager.sceneLoaded += SceneLoadedListener;
        body = GetComponent<Rigidbody2D>();
    }

    public void SceneLoadedListener(Scene scene, LoadSceneMode mode)
    {
        encounter = GameObject.Find("BattleCanvas");
        encounter.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            EncounterArea encounterZone = collision.GetComponent<EncounterArea>();
            if (encounterZone != null) // encounter area
            {
                if (body.velocity.sqrMagnitude > 0)
                {
                    distanceTravelledSinceLastEncounter += body.velocity.magnitude * Time.fixedDeltaTime;

                    while(distanceTravelledSinceLastEncounter > minEncounterDistance)
                    {
                        distanceTravelledSinceLastEncounter -= minEncounterDistance;

                        if (encounterZone.RollEncounter())
                        {
                            encounter.SetActive(true);
                            //Debug.Log("Encounter! " + encounterZone.areaName);
                        }
                    }
                    
                }
            }
        }
    }
}

