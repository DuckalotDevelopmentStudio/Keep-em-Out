using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public LayerMask LayerMask;
    private float rayDistance = 2;
    private float arrowSpeed = 40;
    public float ArrowDamage = 50;
    TrailRenderer trailRenderer;

	// Use this for initialization
	void Start () {
        trailRenderer = GetComponentInChildren<TrailRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //Raycast forward a little
        //if that hit something damage it and put the arrow below the level again
        //if it didnt then move the arrow towards the raycast end and repeat.
        //Also slowly bring the arrow to face straight down always

        float moveDistance = arrowSpeed * Time.fixedDeltaTime;

        Vector3 endPoint;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, ~LayerMask))
        {
            endPoint = hit.point;
            if (hit.collider.GetComponent<IDamageable>() != null)
            {
                hit.collider.GetComponent<IDamageable>().Damage(ArrowDamage);
                transform.position = Vector3.down * 10000;
                trailRenderer.Clear();
            }
        }
        else
        {
            endPoint = transform.position + transform.forward.normalized * rayDistance;
            transform.Rotate(Vector3.right * (25 * Time.fixedDeltaTime));
            transform.position += transform.forward * moveDistance;
        }

	}
}
