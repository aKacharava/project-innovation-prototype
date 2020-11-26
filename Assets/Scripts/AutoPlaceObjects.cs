using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AutoPlaceObjects : MonoBehaviour
{
    ///ARRaycastManager raycastManager;
    [SerializeField]
    ARPlaneManager arPlaneManager;

    [SerializeField]
    GameObject spawnedObject;

    GameObject placedPrefab;

    //static List<ARRaycastHit> sHits = new List<ARRaycastHit>();

    private void Awake()
    {
        ///raycastManager = GetComponent<ARRaycastManager>();
        arPlaneManager = GetComponent<ARPlaneManager>();
        arPlaneManager.planesChanged += PlaneUpdate;
    }

    private void PlaneUpdate(ARPlanesChangedEventArgs args)
    {
        if (args.added != null && placedPrefab == null)
        {
            ARPlane arPlane = args.added[0];
            placedPrefab = Instantiate(spawnedObject, arPlane.transform.position, Quaternion.identity);
        }
    }
}
