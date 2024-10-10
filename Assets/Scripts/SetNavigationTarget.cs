using System;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class SetNavigationTarget : MonoBehaviour
{
    [SerializeField]private Camera topDownCamera;
    [SerializeField]private GameObject navTargetObj;
    [SerializeField]private GameObject arSession;
    [SerializeField] private GameObject xrOrigin;
    [SerializeField] private GameObject user;
    [SerializeField] private GameObject indicator;


    public GameObject origin;
    public NFC nfc;
    public DataBase db;
    
    private NavMeshPath navMeshPath;
    private LineRenderer lineRenderer;

    void Start()
    {
        //Input.gyro.enabled = true;
        Input.location.Start();
        Input.compass.enabled = true;
        navMeshPath = new NavMeshPath();
        lineRenderer = transform.GetComponent<LineRenderer>();
        //SetFirstPosition(1);
    }

    public void SetFirstPosition(int id)
    {
        
        //arSession.transform.position = db.table[id].location;
        //xrOrigin.transform.position = db.table[id].location;
        user.transform.position = db.table[id].location;
        NavMesh.CalculatePath(db.table[id].location, navTargetObj.transform.position, NavMesh.AllAreas, navMeshPath);
        lineRenderer.positionCount = navMeshPath.corners.Length;
        lineRenderer.SetPositions(navMeshPath.corners);
        lineRenderer.enabled = true;
        //user.transform.rotation = Quaternion.Euler(0, Input.compass.trueHeading, 0);
        nfc.tagFound = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (nfc.tagFound == true)
        { 
            NavMesh.CalculatePath(transform.position, navTargetObj.transform.position, NavMesh.AllAreas, navMeshPath);
            lineRenderer.positionCount = navMeshPath.corners.Length;
            lineRenderer.SetPositions(navMeshPath.corners);
            lineRenderer.enabled = true;
        }
    }
}
