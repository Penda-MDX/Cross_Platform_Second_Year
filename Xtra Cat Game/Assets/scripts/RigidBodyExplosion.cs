using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyExplosion : MonoBehaviour {

    public GameObject PrefabRigidBody;
    public int numberOfBits;
    public float minusX, minusZ, plusX, plusZ, forceStrength, forceRadius,coolDown;
    private float timeToReady;

    public int numberOfShots;
    

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoExplode()
    {
        if (numberOfShots >= 0 && timeToReady<Time.time)
        {
            //loop through number of bits times instantiating RB parts with a random velocity
            for (int _number = 0; _number < numberOfBits; _number++)
            {
                Vector3 rndPosition = transform.position;
                rndPosition.x += Random.Range(-minusX, plusX);
                rndPosition.z += Random.Range(-minusZ, plusZ);
                
                
                Vector3 rndDirection = Vector3.zero;
                rndDirection.x = Random.Range(-1, 1);
                rndDirection.y = Random.Range(-1, 1);
                rndDirection.z = Random.Range(-1, 1);
                
                GameObject _currentPiece = Instantiate(PrefabRigidBody,rndPosition,Quaternion.identity);
                _currentPiece.GetComponent<Rigidbody>().AddExplosionForce(forceStrength,transform.position,forceRadius, Random.Range(-3.0f, 3.0f));
                //_currentPiece.GetComponent<Rigidbody>().AddForce(rndDirection * forceStrength, ForceMode.Impulse);
            }
            numberOfShots--;
            timeToReady = Time.time + coolDown;
        }
    }
}
