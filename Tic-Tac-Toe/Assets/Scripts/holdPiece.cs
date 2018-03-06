using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// changed to use Lerp instead of AddForce (line51) for mobile performance
public class holdPiece : MonoBehaviour {
    public GameObject GameLogic;
    public GameObject raycastHolder;
    public GameObject player;
    public GameObject pieceBeingHeld;
	public GameObject gravityAttractor;

    public bool holdingPiece = false;
    public float hoverHeight = 0.3f;

    RaycastHit hit;
	public float gravityFactor = 10.0f;

	//?? used for AddForce not Lerp
    //private Vector3 forceDirection;

    // Use this for initialization
    void Start () {
		
	}
	public void grabPiece(GameObject selectedPiece) {
        if (selectedPiece.GetComponent<PlayerPiece>().hasBeenPlayed == false) {
            pieceBeingHeld = selectedPiece;
            holdingPiece = true;
        }
    }
    // Update is called once per frame
    void Update() { }

    // changed from Update() to FixedUpdate() for mobile performance - physics 
    void FixedUpdate()
    {
        if (GameLogic.GetComponent<GameLogic>().playerTurn == true) {
            if (holdingPiece == true) {
                Vector3 forwardDir = raycastHolder.transform.TransformDirection(Vector3.forward) * 100;
                Debug.DrawRay(raycastHolder.transform.position, forwardDir, Color.green);


                if (Physics.Raycast(raycastHolder.transform.position, (forwardDir), out hit)) {
					gravityAttractor.transform.position = new Vector3(hit.point.x, hit.point.y + hoverHeight, hit.point.z);


					pieceBeingHeld.GetComponent<Rigidbody> ().useGravity = false;
					pieceBeingHeld.GetComponent<BoxCollider> ().enabled = false;

                    // using AddForce for physics
                     pieceBeingHeld.GetComponent<Rigidbody>().AddForce(gravityAttractor.transform.position - pieceBeingHeld.transform.position);

                    // usinge lerp for physics
                    // Debug.Log("about to lerp");
                    //transform.position = Vector3.Lerp(transform.position, gravityAttractor.transform.position, 1.0f);


                    if (hit.collider.gameObject.tag == "Grid Plate") {
                        if (Input.GetMouseButtonDown(0)) {
                            holdingPiece = false;
                            hit.collider.gameObject.SetActive(false);
                            pieceBeingHeld.GetComponent<PlayerPiece>().hasBeenPlayed = true;
							pieceBeingHeld.GetComponent<Rigidbody> ().useGravity = true;
							pieceBeingHeld.GetComponent<BoxCollider> ().enabled = true;
                            GameLogic.GetComponent<GameLogic>().playerMove(hit.collider.gameObject);
                        }

                    }

                }
            }
        }
    }

}








