using UnityEngine;
using TMPro;

public class WavyText : MonoBehaviour
{
    public float amplitude = 5f;    // Altura de la onda
    public float frequency = 5f;    // Frecuencia de la onda
    public float speed = 2f;        // Velocidad de la onda

    private TMP_Text textMesh;
    private TMP_TextInfo textInfo;

    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
        textMesh.ForceMeshUpdate();
        textInfo = textMesh.textInfo;
    }

    void Update()
    {
        textMesh.ForceMeshUpdate();
        textInfo = textMesh.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            var charInfo = textInfo.characterInfo[i];

            if (!charInfo.isVisible)
                continue;

            int vertexIndex = charInfo.vertexIndex;
            int materialIndex = charInfo.materialReferenceIndex;

            Vector3[] vertices = textInfo.meshInfo[materialIndex].vertices;

            float offsetY = Mathf.Sin(Time.time * speed + i * frequency) * amplitude;

            for (int j = 0; j < 4; j++)
            {
                vertices[vertexIndex + j].y += offsetY;
            }
        }

        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
            textMesh.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
        }
    }
}
