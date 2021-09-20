using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRemoval : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        
    }
}
