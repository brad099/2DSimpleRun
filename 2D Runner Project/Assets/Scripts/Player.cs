using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float _Speed;
    [SerializeField] float JumpSpeed;
    [SerializeField] GameObject restart;
    [SerializeField] Text ingredients;
    private int ing = 0;
    private Rigidbody2D _Rb;
    public Parallax bg;
    private bool _IsGrounded;
    private void Start()
    {
            _Rb = GetComponent<Rigidbody2D>();
    }

        private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _IsGrounded == true)
        {
            _Rb.AddForce(Vector3.up * JumpSpeed, ForceMode2D.Impulse);
            _IsGrounded = false;
        }

        /// Moving
        transform.position += new Vector3(_Speed, 0, 0) * Time.deltaTime;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
            //Colliding Enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            restart.SetActive(true);
            bg._speed = 0f;
        }
            //Colliding Objects
        if (other.gameObject.CompareTag("Collect"))
        {
            ing ++;
            ingredients.text = ("" + ing);
            Destroy(other.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Checking Ground
        if (collision.gameObject.CompareTag("Ground"))
          {
              _IsGrounded = true;
         }
    }
    //Restart Level
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
