using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {
    Transform transPlayer;
    float speed;
    public bool isWalking, isGrounded, isJumping;
	// Use this for initialization
	void Start () {
        transPlayer = this.gameObject.GetComponent<Transform>();
        speed = 2;
        isWalking = isJumping = false;
        isGrounded = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W)){
            transPlayer.Translate(new Vector3(0,0,1) * Time.deltaTime * speed, Space.World);
            isWalking = true;
        }
        if (Input.GetKey(KeyCode.A)){
            transPlayer.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
            isWalking = true;
        }
        if (Input.GetKey(KeyCode.S)){
            transPlayer.Translate(new Vector3(0,0,-1) * Time.deltaTime * speed, Space.World);
            isWalking = true;
        }
        if (Input.GetKey(KeyCode.D)){
            transPlayer.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
            isWalking = true;
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * 200);
            isJumping = true;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) && isWalking){
            isWalking = false;
            
        }
		if(isWalking){
			if(this.GetComponent<Animation>().IsPlaying("Idle"))
			   this.GetComponent<Animation>().Stop("Idle");
			this.GetComponent<Animation> ().CrossFade ("Walk");
		}else{
			if(this.GetComponent<Animation>().IsPlaying("Walk"))
				this.GetComponent<Animation>().Stop("Walk");
			this.GetComponent<Animation> ().CrossFade ("Idle");
		}
	}
}
