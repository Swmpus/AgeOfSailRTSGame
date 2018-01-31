using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGameObjectController : MonoBehaviour {
    private float MovementSpeed;
    private float TurnSpeed;
    private float WayPointDist;
    private List<Vector3> TargetPos;
    private int TargetPointer;
    [SerializeField]
    private Material DefaultMat;

    public void SetMat(Material InMat) {
        GetComponent<Renderer>().material = InMat;
    }

    public void ResetMat() {
        GetComponent<Renderer>().material = DefaultMat;
    }

    public void ResetTargets()
    {
        TargetPointer = 0;
        TargetPos = new List<Vector3>();
    }

    public void SetTarget(Vector3 InPoint)
    {
        ResetTargets();
        TargetPos.Add(InPoint);
    }

    public void AddTarget(Vector3 InPoint)
    {
        TargetPos.Add(InPoint);
        //Debug.Log("Count: " + TargetPos.Count + ", Pointer: " + TargetPointer);
    }

    private void MoveTowardTarget() {
        transform.Translate(Vector3.Normalize(TargetPos[TargetPointer] - transform.position) * MovementSpeed * Time.deltaTime);
    }

	void Start () {
        WayPointDist = 10f;
        MovementSpeed = 5f;
        TurnSpeed = 5f;
        ResetMat();
        ResetTargets();
	}
	
	void Update () {
        if (TargetPos.Count > 0) {
            MoveTowardTarget();
            if (Vector3.Distance(transform.position, TargetPos[TargetPointer]) < WayPointDist) {
                TargetPointer += 1;
            }
        }
        if (TargetPos.Count > 0 && TargetPointer == TargetPos.Count) {
            //Debug.Log("Travelled Full Path");
            ResetTargets();
        }
	}
}