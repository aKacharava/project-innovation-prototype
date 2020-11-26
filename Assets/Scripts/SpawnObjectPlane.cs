using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARPlaneManager))]
public class SpawnObjectPlane : MonoBehaviour
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

    /// <summary>
    /// Method that returns a position that the user taps on the screen
    /// </summary>
    /// <param name="tapPosition"> The vector for the touch input device </param>
    /// <returns></returns>
    bool GetTapPosition(out Vector2 tapPosition)
    {
        if (Input.touchCount > 0)
        {
            tapPosition = Input.GetTouch(0).position;
            return true;
        }

        tapPosition = default;
        return false;
    }

    private void Update()
    {
        ///// Checks if the user is not touching the screen. if not, then return nothing.
        //if (!GetTapPosition(out Vector2 tapPosition))
        //{
        //    return;
        //}

        ///// Checks if the user is touching on screen, then check if the surface, where the raycast is being hit on, trackable.
        //if (raycastManager.Raycast(tapPosition, sHits, TrackableType.PlaneWithinPolygon))
        //{
        //    var hitPose = sHits[0].pose;

        //    if (spawnedObject == null)
        //    {
        //        spawnedObject = Instantiate(placeablePrefab, hitPose.position, hitPose.rotation);
        //    }
        //    else
        //    {
        //        spawnedObject.transform.position = hitPose.position;
        //        spawnedObject.transform.rotation = hitPose.rotation;
        //    }
        //}


    }
}
