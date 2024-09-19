using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class SetNavigationTarget : MonoBehaviour
{
    [SerializeField]
    private Camera topDownCamera;

    [SerializeField]
    private GameObject navTargetObj;

    public GameObject origin;

    private NavMeshPath navMeshPath;
    private LineRenderer lineRenderer;
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        navMeshPath = new NavMeshPath();
        lineRenderer = transform.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(startPosition);
        NavMesh.CalculatePath(transform.position, navTargetObj.transform.position, NavMesh.AllAreas, navMeshPath);
        lineRenderer.positionCount = navMeshPath.corners.Length;
        lineRenderer.SetPositions(navMeshPath.corners);
        lineRenderer.enabled = true;
    }
}
