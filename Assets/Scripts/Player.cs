using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bullet bulletPrefab;

    public float thrustSpeed = 2.5f;

    public float turnSpeed= 0.3f;

    private Rigidbody2D _rigidbody;

    private bool _thrusting;

    private float _turnDirection;

    private void Awake(){
        _rigidbody = GetComponent<Rigidbody2D>();

    }


    private void Update(){

        //movimiento de la nave
        _thrusting=Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            _turnDirection = 1.0f;

        } 
        
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            _turnDirection = -1.0f;

        } 
        
        else {
            _turnDirection = 0.0f;

        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            Shoot();
        }

    }

    private void FixedUpdate (){
        if (_thrusting){
            _rigidbody.AddForce(this.transform.up * this.thrustSpeed);
        }

        if (_turnDirection != 0.0f){
            _rigidbody.AddTorque(_turnDirection * this.turnSpeed);

        }

    }

    private void Shoot() {

        //disparo
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
    }
    private void OnCollisionEnter2D(Collision2D collision){
        
        if(collision.gameObject.tag == "Asteroid") {

            //mueres si chocas con asteroides
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = 0.0f;

            this.gameObject.SetActive(false);

            FindObjectOfType<GameManager>().PlayerDied();
        }
    }

}
