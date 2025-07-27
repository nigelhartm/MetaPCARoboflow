using UnityEngine;

/// <summary>
/// This script checks the distance between a panda and a bear.
/// If they come close enough, it changes their particle system materials to a "love" effect.
/// Otherwise, it shows default materials.
/// </summary>
public class RelationshipManager : MonoBehaviour
{
    // Reference to the panda GameObject
    [SerializeField] public GameObject Panda;

    // Reference to the bear GameObject
    [SerializeField] public GameObject Bear;

    // Material to use when panda and bear are close (e.g., love effect)
    [SerializeField] private Material MaterialLove;

    // Default material for panda particles
    [SerializeField] private Material MaterialPanda;

    // Default material for bear particles
    [SerializeField] private Material MaterialBear;

    // Particle system attached to the panda
    private ParticleSystem pandaSystem;

    // Particle system attached to the bear
    private ParticleSystem bearSystem;

    // Distance below which the love effect is triggered
    [SerializeField] private float distanceThreshold = 0.15f;

    // Cached renderers
    private ParticleSystemRenderer pandaRenderer;
    private ParticleSystemRenderer bearRenderer;

    // Cached ParticleSystemRenderer components for performance
    void Start()
    {
        // Cache the Particle System references
        pandaSystem = Panda.GetComponentInChildren<ParticleSystem>();
        bearSystem = Bear.GetComponentInChildren<ParticleSystem>();

        // Cache the ParticleSystemRenderer references once at startup
        pandaRenderer = pandaSystem.GetComponent<ParticleSystemRenderer>();
        bearRenderer = bearSystem.GetComponent<ParticleSystemRenderer>();
    }

    // Called once per frame
    void Update()
    {
        // Calculate distance between panda and bear
        float distance = Vector3.Distance(Panda.transform.position, Bear.transform.position);

        if (distance < distanceThreshold)
        {
            // If they are close: show love material
            pandaRenderer.material = MaterialLove;
            bearRenderer.material = MaterialLove;
        }
        else
        {
            // If they are apart: show default materials
            pandaRenderer.material = MaterialPanda;
            bearRenderer.material = MaterialBear;
        }
    }
}
