using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Traveler))]
public class SimpleProjectileController : MonoBehaviour
{
    public SimpleProjectileModel ProjectileModel;
    private Traveler _traveler;

	// Use this for initialization
	void Start () {
        _traveler = GetComponent<Traveler>();
        _traveler.Set(ProjectileModel.TravelSpeed, ProjectileModel.TravelDistance);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
