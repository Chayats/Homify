using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;                  // The damage inflicted by each bullet.
    public float timeBetweenBullets = 2000f;        // The time between each shot.
    public float range = 10f;                      // The distance the gun can fire.
    public GameObject debugger;
    public float timer;                                    // A timer to determine when to fire.
    Ray shootRay;                                   // A ray from the gun end forwards.
    RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
    int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.
  //  ParticleSystem gunParticles;                    // Reference to the particle system.
    LineRenderer gunLine;                           // Reference to the line renderer.
    AudioSource gunAudio;                           // Reference to the audio source.
    Light gunLight;                                 // Reference to the light component.
    float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.

    void Awake()
    {
        // Create a layer mask for the Shootable layer.
        shootableMask = LayerMask.GetMask("Shootable");

        // Set up the references.
   //     gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }

    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the Fire1 button is being press and it's time to fire...
        if (timer >= timeBetweenBullets)
        {
            // ... shoot the gun.
            Shoot();
        }

        // If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            // ... disable the effects.
            DisableEffects();
        }
    }

    public void DisableEffects()
    {
        // Disable the line renderer and the light.
       gunLine.enabled = false;
        gunLight.enabled = false;
    }

    void Shoot()
    {
        // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        if (Physics.Raycast(shootRay, out shootHit, range))
        {
            Debug.Log(shootHit.collider.gameObject.name);
            // Try and find an EnemyHealth script on the gameobject hit.
            PlayerController enemyHealth = shootHit.collider.GetComponent<PlayerController>();

            if(debugger)
            debugger.transform.position = shootHit.point;
            
            
            // If the EnemyHealth component exist...
            if (enemyHealth != null)
            {
                // ... the enemy should take damage.
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            }
            else
            {
                return;
            }

            // Set the second position of the line renderer to the point the raycast hit.
            gunLine.SetPosition(1, shootHit.point);
        }   // If the raycast didn't hit anything on the shootable layer...
        else
        {
            // ... set the second position of the line renderer to the fullest extent of the gun's range.
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }


        // Reset the timer.
        timer = 0f;

        // Play the gun shot audioclip.
        gunAudio.Play();

        // Enable the light.
        gunLight.enabled = true;

        // Stop the particles from playing if they were, then start the particles.
     //  gunParticles.Stop();
    //   gunParticles.Play();
//
        // Enable the line renderer and set it's first position to be the end of the gun.
        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

     

        // Perform the raycast against gameobjects on the shootable layer and if it hits something...
     
     
    }
}
