using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float movingSpeed = 10;
    public float rotateSpeed = 5;

    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;

    private float vInput;
    private float hInput;
    public float bulletSpeed = 100f;
    public GameObject bulletPrefab;

    private Rigidbody _rb;
    private float JumpVelocity = 5f;

    private CapsuleCollider _col;
    private GameBehavior _gameBehavior;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        _gameBehavior = GameObject.Find("MainGameManager").GetComponent<GameBehavior>();

    }
    void Update()
    {

        vInput = Input.GetAxis("Vertical") * movingSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        //transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        //transform.Rotate(Vector3.up * hInput * Time.deltaTime);

    }
    private void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRotation = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rb.MovePosition(transform.position + transform.forward * vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRotation);

        if (IsGrounded() && Input.GetKey(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
        }

        if (Input.GetMouseButton(0))
        {
            GameObject newBullet = Instantiate(bulletPrefab, transform.position + new Vector3(0f,0.1f,0.1f),transform.rotation) as GameObject;
            Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();
            bulletRb.velocity = Vector3.forward * bulletSpeed;
        }
    }
    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x,
        _col.bounds.min.y, _col.bounds.center.z);

        bool grounded = Physics.CheckCapsule(_col.bounds.
        center, capsuleBottom, distanceToGround, groundLayer,
        QueryTriggerInteraction.Ignore);

        return grounded;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            Debug.Log("You lost -1 HP");
            _gameBehavior.HealthBar -= 1;
        }
    }
}
