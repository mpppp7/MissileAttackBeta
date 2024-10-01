using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;
    public bool gameWin;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip explodeSound;

    public float maxTop = 14.5f;
    public float minTop = 2;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && (!gameOver || !gameWin))
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }

        if (transform.position.y > maxTop)
        {
            transform.position = new Vector3(transform.position.x, maxTop, transform.position.z);
            playerRb.velocity = Vector3.zero;
        }
        else if (transform.position.y < minTop)
        {
            transform.position = new Vector3(transform.position.x, minTop, transform.position.z);
            playerRb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with column, explode and set gameOver to true
        if (other.gameObject.CompareTag("Column"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Tank"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameWin = true;
            Debug.Log("You Won!");
            Destroy(other.gameObject);
        }
    }

    // Helper method to stop and disable a ParticleSystem
    private void StopAndDisableParticle(ParticleSystem particleSystem)
    {
        if (particleSystem != null)
        {
            particleSystem.Stop();
            var mainModule = particleSystem.main;
            mainModule.loop = false;
            mainModule.simulationSpeed = 0f;
            var emissionModule = particleSystem.emission;
            emissionModule.enabled = false;
        }
    }

}

