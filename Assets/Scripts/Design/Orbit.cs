using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Orbit : MonoBehaviour
{
    public Transform centerOfGravity;
    public float orbitSpeed = 1.0f;

    private ParticleSystem particleSys;
    private ParticleSystem.Particle[] particles;

    void Start()
    {
        particleSys = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[particleSys.main.maxParticles];
    }

    void LateUpdate()
    {
        int numParticlesAlive = particleSys.GetParticles(particles);
        for (int i = 0; i < numParticlesAlive; i++)
        {
            Vector3 centerPosition = centerOfGravity.position;
            Vector3 particlePosition = particles[i].position;
            Vector3 direction = (particlePosition - centerPosition).normalized;
            Vector3 tangentDirection = Vector3.Cross(direction, Vector3.up).normalized;
            particles[i].velocity = tangentDirection * orbitSpeed;
        }
        particleSys.SetParticles(particles, numParticlesAlive);
    }
}
