using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float dropDestroyDelay; // 1
    private Collider myCollider; // 2
    private Rigidbody myRigidbody; // 3
    
    public float runSpeed; // 1
    public float gotHayDestroyDelay; // 2
    private bool hitByHay; // 3
    
    private SheepSpawner sheepSpawner;
    
    public float heartOffset; // 1
    public GameObject heartPrefab;
    
    //public float jumpForce;
    
    private bool canJump = true; // Track whether the object can jump
    
    private bool canfall = false;
    
    public float jumpCooldownDuration; // Duration of the cooldown period after jumping
    
    public float falling;
    //public float jumpActivationYPosition; // Y position threshold to reactivate kinematic mode
    
    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
        if (Random.value <= 0.05f) // 5% chance
        {
            Jump();
        }
        fall();
    }
    
    
    
    private void HitByHay()
    {
        sheepSpawner.RemoveSheepFromList(gameObject);
        hitByHay = true; // 1
        runSpeed = 0; // 2

        Destroy(gameObject, gotHayDestroyDelay); // 3
        
        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity);
        
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>();; // 1
        tweenScale.targetScale = 0; // 2
        tweenScale.timeToReachTarget = gotHayDestroyDelay; // 3
        
        SoundManager.Instance.PlaySheepHitClip();
        
        GameStateManager.Instance.SavedSheep();
    }

    private void OnTriggerEnter(Collider other) // 1
    {   
        if (other.CompareTag("Hay") && !hitByHay) // 2
        {
            Destroy(other.gameObject); // 3
            HitByHay(); // 4
        }
        else if (other.CompareTag("DropSheep"))
        {
        Drop();
        }
    }

    
    
    private void Drop()
    {
        GameStateManager.Instance.DroppedSheep();
        sheepSpawner.RemoveSheepFromList(gameObject);
        myRigidbody.isKinematic = false; // 1
        myCollider.isTrigger = false; // 2
        Destroy(gameObject, dropDestroyDelay); // 3
        SoundManager.Instance.PlaySheepDroppedClip();
    }
    
    
   

void Jump()
{
    if (!canJump) return; // If jumping is on cooldown, exit
    
    // Disable jumping during cooldown
    canJump = false;
    //falling = true
    
    // Disable kinematic mode to allow jumping
    //myRigidbody.isKinematic = false;
    
    // Add force to make the sheep jump
  //myRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    transform.Translate(0,5f,0);
    
    // Start cooldown coroutine
    StartCoroutine(JumpCooldown());
    StartCoroutine(fallingCooldown());
}

IEnumerator JumpCooldown()
{
    // Wait for the specified cooldown duration
    yield return new WaitForSeconds(jumpCooldownDuration);
    
    // Re-enable jumping after cooldown
    canJump = true;
}

void fall()
{
    if (!canfall) return; // If jumping is on cooldown, exit
    
    // Disable jumping during cooldown
    canfall = false;
    
    // Disable kinematic mode to allow jumping
    //myRigidbody.isKinematic = false;
    
    // Add force to make the sheep jump
  //myRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    transform.Translate(0,-5f,0);
    
}


IEnumerator fallingCooldown()
{
    // Wait for the specified cooldown duration
    yield return new WaitForSeconds(falling);
    
    // Re-enable jumping after cooldown
    canfall = true;
}

}
