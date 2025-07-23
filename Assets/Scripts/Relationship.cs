using UnityEngine;

public class Relationship : MonoBehaviour
{
    [SerializeField] private GameObject Panda;
    [SerializeField] private GameObject Bear;
    [SerializeField] private Material MaterialLove;
    [SerializeField] private Material MaterialPanda;
    [SerializeField] private Material MaterialBear;
    [SerializeField] private ParticleSystem pandaSystem;
    [SerializeField] private ParticleSystem bearSystem;

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(Panda.transform.position, Bear.transform.position) < 0.15f)
        {
            var renderer = pandaSystem.GetComponent<ParticleSystemRenderer>();
            renderer.material = MaterialLove;
            var renderer2 = bearSystem.GetComponent<ParticleSystemRenderer>();
            renderer2.material = MaterialLove;
        }
        else
        {
            var renderer = pandaSystem.GetComponent<ParticleSystemRenderer>();
            renderer.material = MaterialPanda;
            var renderer2 = bearSystem.GetComponent<ParticleSystemRenderer>();
            renderer2.material = MaterialBear;
        }
    }
}
