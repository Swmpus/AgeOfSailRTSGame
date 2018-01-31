using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour {
    [SerializeField]
    private Material SelectedMat;
    private List<ShipGameObjectController> Ships;

	void Start ()
    {
        Ships = new List<ShipGameObjectController>();
	}
    
    void Update ()
    {
        if (Input.GetButtonDown("MouseLeft")) {
            Ray Select = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Selected = new RaycastHit();

            if (Physics.Raycast(Select, out Selected)) {
                if (Selected.transform.tag == "BlueShip") {
                    Selected.transform.GetComponent<ShipGameObjectController>().SetMat(SelectedMat);
                    Ships.Add(Selected.transform.GetComponent<ShipGameObjectController>());
                } else {
                    DeselectShips();
                }
            } else {
                DeselectShips();
            }
        } else if (Input.GetButtonDown("MouseRight") && Input.GetButton("LeftShift")) {
            Ray Pointer = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit = new RaycastHit();
            if (Physics.Raycast(Pointer, out Hit)) {
                foreach (ShipGameObjectController Ship in Ships) {
                    //Debug.Log("Add");
                    Ship.AddTarget(Hit.point);
                }
            }
        } else if (Input.GetButtonDown("MouseRight")) {
            Ray Pointer = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit = new RaycastHit();
            if (Physics.Raycast(Pointer, out Hit)) {
                foreach (ShipGameObjectController Ship in Ships) {
                    //Debug.Log("Set");
                    Ship.SetTarget(Hit.point);
                }
            }
        }
	}

    private void DeselectShips()
    {
        foreach (ShipGameObjectController Ship in Ships) {
            Ship.ResetMat();
        }
        Ships = new List<ShipGameObjectController>();
    }
}
