using UnityEngine;

public class UIFakeParticlesSpawner : MonoBehaviour
{
    public GameObject particlePrefab;
    public RectTransform spawnArea;
    public float spawnInterval = 0.1f;

    private void Start()
    {
        StartCoroutine(SpawnParticlesRoutine());
    }

    private System.Collections.IEnumerator SpawnParticlesRoutine()
    {
        while (true)
        {
            SpawnParticle();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnParticle()
    {
        if (spawnArea == null)
        {
            Debug.LogWarning("spawnArea no asignado en UIFakeParticlesSpawner");
            return;
        }

        Vector2 randomPos = new Vector2(
            Random.Range(spawnArea.rect.xMin, spawnArea.rect.xMax),
            Random.Range(spawnArea.rect.yMin, spawnArea.rect.yMax)
        );

        GameObject particle = Instantiate(particlePrefab, spawnArea);
        RectTransform rt = particle.GetComponent<RectTransform>();
        rt.anchoredPosition = randomPos;

        float randomScale = Random.Range(0.5f, 1.5f);
        rt.localScale = new Vector3(randomScale, randomScale, 1f);

        Destroy(particle, 1.5f);
    }
}
