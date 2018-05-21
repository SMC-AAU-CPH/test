using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


public class CollisionScript : MonoBehaviour {
    public AudioSource collisionSound;
       
	// Use this for initialization
	void Start () {
        collisionSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision target)
    {
		if (target.gameObject.tag.Equals("drumstick") == true && Mathf.Abs(target.contacts[0].normal.y) > 0.3f)
        {
            collisionSound.Play();
            Debug.Log(gameObject.tag + " " + Time.time);
		                                    
        }

    }

    private void OnCollisionExit(Collision target)
    {
        
    }

	private enum HitDirection { None, Top, Bottom, Forward, Back, Left, Right }
	private HitDirection ReturnDirection( GameObject Object, GameObject ObjectHit ){

		HitDirection hitDirection = HitDirection.None;
		RaycastHit MyRayHit;
		Vector3 direction = ( Object.transform.position - ObjectHit.transform.position ).normalized;
		Ray MyRay = new Ray( ObjectHit.transform.position, direction );

		if ( Physics.Raycast( MyRay, out MyRayHit ) ){

			if ( MyRayHit.collider != null ){

				Vector3 MyNormal = MyRayHit.normal;
				MyNormal = MyRayHit.transform.TransformDirection( MyNormal );

				if( MyNormal == MyRayHit.transform.up ){ hitDirection = HitDirection.Top; }
				if( MyNormal == -MyRayHit.transform.up ){ hitDirection = HitDirection.Bottom; }
				if( MyNormal == MyRayHit.transform.forward ){ hitDirection = HitDirection.Forward; }
				if( MyNormal == -MyRayHit.transform.forward ){ hitDirection = HitDirection.Back; }
				if( MyNormal == MyRayHit.transform.right ){ hitDirection = HitDirection.Right; }
				if( MyNormal == -MyRayHit.transform.right ){ hitDirection = HitDirection.Left; }
			}    
		}
		return hitDirection;
	}
}
