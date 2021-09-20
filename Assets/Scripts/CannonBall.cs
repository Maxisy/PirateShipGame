using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public GameObject WaterParticles;
    public GameObject TerrainParticles;

    void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        var layerID = collision.collider.gameObject.layer;
        var layerName = LayerMask.LayerToName(layerID);

        GameObject particlesObject = null;

        if (layerName == "Water")
            particlesObject = WaterParticles;

        if (layerName == "Terrain")
            particlesObject = TerrainParticles;

        var position = collision.contacts[0].point;

        Instantiate(particlesObject, position, Quaternion.identity);

        Destroy(gameObject);
    }
}
