using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DiceGenerator : MonoBehaviour
{
    public int numberOfFaces = 6; // Default to a cube
    public Shader diceShader;
    public Color diceColor = Color.white; // Default color is white
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private Material diceMaterial;

    private void Start()
    {
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();

        // Create and apply the material
        diceMaterial = new Material(diceShader);
        diceMaterial.color = diceColor;
        meshRenderer.material = diceMaterial;

        switch (numberOfFaces)
        {
            case 4:
                meshFilter.mesh = CreateTetrahedron();
                AddFaceNumbers(CreateTetrahedronFaceCenters());
                break;
            case 6:
                meshFilter.mesh = CreateCube();
                AddFaceNumbers(CreateCubeFaceCenters());
                break;
            case 8:
                meshFilter.mesh = CreateOctahedron();
                AddFaceNumbers(CreateOctahedronFaceCenters());
                break;
            case 10:
                meshFilter.mesh = CreateTrapezohedron();
                //AddFaceNumbers(CreateDodecahedronFaceCenters());
                break;
            case 20:
                meshFilter.mesh = CreateIcosahedron();
                AddFaceNumbers(CreateIcosahedronFaceCenters());
                break;
            default:
                Debug.LogError("Number of faces not supported. Supported values are 4, 6, 8, 12, and 20.");
                break;
        }

        // Add black edges
        AddEdges(numberOfFaces == 6);
    }

    private void AddEdges(bool removeDiagonalEdges)
    {
        Mesh mesh = meshFilter.mesh;
        Vector3[] vertices = mesh.vertices;
        int[] triangles = mesh.triangles;
        List<int> edges = new List<int>();

        // Collect edges from triangles
        for (int i = 0; i < triangles.Length; i += 3)
        {
            // Triangle edges
            edges.Add(triangles[i]);
            edges.Add(triangles[i + 1]);

            edges.Add(triangles[i + 1]);
            edges.Add(triangles[i + 2]);

            edges.Add(triangles[i + 2]);
            edges.Add(triangles[i]);

            // Additional edges for each face (e.g., to close the loop)
            edges.Add(triangles[i]);
            edges.Add(triangles[i + 2]);
        }

        // Remove duplicate edges
        List<int> uniqueEdges = new List<int>();
        for (int i = 0; i < edges.Count; i += 2)
        {
            int start = edges[i];
            int end = edges[i + 1];
            bool found = false;

            for (int j = i + 2; j < edges.Count; j += 2)
            {
                if ((edges[j] == start && edges[j + 1] == end) || (edges[j] == end && edges[j + 1] == start))
                {
                    found = true;
                    break;
                }
            }

            if (!found && (!removeDiagonalEdges || !IsDiagonalEdge(vertices[start], vertices[end])))
            {
                uniqueEdges.Add(start);
                uniqueEdges.Add(end);
            }
        }

        // Create edge vertices
        Vector3[] edgeVertices = new Vector3[uniqueEdges.Count];
        for (int i = 0; i < uniqueEdges.Count; i++)
        {
            edgeVertices[i] = vertices[uniqueEdges[i]];
        }

        // Create edge mesh
        GameObject edgeObject = new GameObject("Edges");
        edgeObject.transform.SetParent(transform);
        Mesh edgeMesh = new Mesh();
        edgeMesh.vertices = edgeVertices;
        edgeMesh.SetIndices(Enumerable.Range(0, uniqueEdges.Count).ToArray(), MeshTopology.Lines, 0);
        edgeObject.AddComponent<MeshFilter>().mesh = edgeMesh;
        edgeObject.AddComponent<MeshRenderer>().material.color = Color.black;
    }

    private bool IsDiagonalEdge(Vector3 vertex1, Vector3 vertex2)
    {
        // Diagonal edges occur when x and y, y and z, or x and z coordinates are different
        return (Mathf.Abs(vertex1.x - vertex2.x) > 0 && Mathf.Abs(vertex1.y - vertex2.y) > 0) ||
               (Mathf.Abs(vertex1.y - vertex2.y) > 0 && Mathf.Abs(vertex1.z - vertex2.z) > 0) ||
               (Mathf.Abs(vertex1.x - vertex2.x) > 0 && Mathf.Abs(vertex1.z - vertex2.z) > 0);
    }


    private void AddFaceNumbers(List<Vector3> faceCenters)
    {
        for (int i = 0; i < faceCenters.Count; i++)
        {
            GameObject textObj = new GameObject("FaceNumber_" + (i + 1));
            textObj.transform.SetParent(transform);
            TextMesh textMesh = textObj.AddComponent<TextMesh>();
            textMesh.text = (i + 1).ToString();
            textMesh.fontSize = 24;
            textMesh.alignment = TextAlignment.Center;
            textMesh.anchor = TextAnchor.MiddleCenter;
            textMesh.characterSize = 0.25f;
            textMesh.color = Color.black; // Text color

            textObj.transform.position = faceCenters[i];
            textObj.transform.LookAt(transform.position);
            textObj.transform.Rotate(0, 180, 0);
        }
    }

    private List<Vector3> CreateTetrahedronFaceCenters()
    {
        return new List<Vector3>
        {
            (new Vector3(1, 1, 1) + new Vector3(-1, -1, 1) + new Vector3(-1, 1, -1)) / 3,
            (new Vector3(1, 1, 1) + new Vector3(1, -1, -1) + new Vector3(-1, -1, 1)) / 3,
            (new Vector3(1, 1, 1) + new Vector3(-1, 1, -1) + new Vector3(1, -1, -1)) / 3,
            (new Vector3(-1, -1, 1) + new Vector3(-1, 1, -1) + new Vector3(1, -1, -1)) / 3
        };
    }

    private List<Vector3> CreateCubeFaceCenters()
    {
        return new List<Vector3>
        {
            new Vector3(0, 0, -1),
            new Vector3(0, 0, 1),
            new Vector3(-1, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(0, -1, 0),
            new Vector3(0, 1, 0)
        };
    }

    private List<Vector3> CreateOctahedronFaceCenters()
    {
        return new List<Vector3>
        {
            (new Vector3(1, 0, 0) + new Vector3(0, 1, 0) + new Vector3(0, 0, 1)) / 3,
            (new Vector3(1, 0, 0) + new Vector3(0, -1, 0) + new Vector3(0, 0, 1)) / 3,
            (new Vector3(1, 0, 0) + new Vector3(0, -1, 0) + new Vector3(0, 0, -1)) / 3,
            (new Vector3(1, 0, 0) + new Vector3(0, 1, 0) + new Vector3(0, 0, -1)) / 3,
            (new Vector3(-1, 0, 0) + new Vector3(0, 1, 0) + new Vector3(0, 0, 1)) / 3,
            (new Vector3(-1, 0, 0) + new Vector3(0, -1, 0) + new Vector3(0, 0, 1)) / 3,
            (new Vector3(-1, 0, 0) + new Vector3(0, -1, 0) + new Vector3(0, 0, -1)) / 3,
            (new Vector3(-1, 0, 0) + new Vector3(0, 1, 0) + new Vector3(0, 0, -1)) / 3
        };
    }

    private List<Vector3> CreateDodecahedronFaceCenters()
    {
        List<Vector3> faceCenters = new List<Vector3>();

        float t1 = (1.0f + Mathf.Sqrt(5.0f)) / 2.0f;
        float t2 = 1.0f / t1;

        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-1, -1, -1),
            new Vector3(-1, -1, 1),
            new Vector3(-1, 1, -1),
            new Vector3(-1, 1, 1),
            new Vector3(1, -1, -1),
            new Vector3(1, -1, 1),
            new Vector3(1, 1, -1),
            new Vector3(1, 1, 1),
            new Vector3(0, -t1, -t2),
            new Vector3(0, -t1, t2),
            new Vector3(0, t1, -t2),
            new Vector3(0, t1, t2),
            new Vector3(-t1, -t2, 0),
            new Vector3(-t1, t2, 0),
            new Vector3(t1, -t2, 0),
            new Vector3(t1, t2, 0),
            new Vector3(-t2, 0, -t1),
            new Vector3(t2, 0, -t1),
            new Vector3(-t2, 0, t1),
            new Vector3(t2, 0, t1)
        };

        int[][] faces = new int[][]
        {
            new int[] {0, 16, 2, 10, 12},
            new int[] {1, 9, 17, 4, 8},
            new int[] {2, 16, 6, 18, 13},
            new int[] {3, 11, 7, 15, 5},
            new int[] {4, 17, 14, 6, 0},
            new int[] {5, 15, 19, 8, 1},
            new int[] {6, 14, 18, 10, 2},
            new int[] {7, 11, 19, 15, 3},
            new int[] {8, 4, 14, 17, 1},
            new int[] {9, 8, 19, 15, 5},
            new int[] {10, 12, 18, 16, 0},
            new int[] {11, 19, 17, 15, 7}
        };

        foreach (int[] face in faces)
        {
            Vector3 faceCenter = Vector3.zero;
            foreach (int vertexIndex in face)
            {
                faceCenter += vertices[vertexIndex];
            }
            faceCenter /= face.Length;
            faceCenters.Add(faceCenter);
        }

        return faceCenters;
    }

    private List<Vector3> CreateIcosahedronFaceCenters()
    {
        List<Vector3> faceCenters = new List<Vector3>();

        float t = (1.0f + Mathf.Sqrt(5.0f)) / 2.0f;

        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-1,  t,  0),
            new Vector3( 1,  t,  0),
            new Vector3(-1, -t,  0),
            new Vector3( 1, -t,   0),
            new Vector3( 0, -1,   t),
            new Vector3( 0,  1,   t),
            new Vector3( 0, -1,  -t),
            new Vector3( 0,  1,  -t),
            new Vector3( t,  0,  -1),
            new Vector3( t,  0,   1),
            new Vector3(-t,  0,  -1),
            new Vector3(-t,  0,   1)
        };

        int[][] faces = new int[][]
        {
            new int[] {0, 11, 5},
            new int[] {0, 5, 1},
            new int[] {0, 1, 7},
            new int[] {0, 7, 10},
            new int[] {0, 10, 11},
            new int[] {1, 5, 9},
            new int[] {5, 11, 4},
            new int[] {11, 10, 2},
            new int[] {10, 7, 6},
            new int[] {7, 1, 8},
            new int[] {3, 9, 4},
            new int[] {3, 4, 2},
            new int[] {3, 2, 6},
            new int[] {3, 6, 8},
            new int[] {3, 8, 9},
            new int[] {4, 9, 5},
            new int[] {2, 4, 11},
            new int[] {6, 2, 10},
            new int[] {8, 6, 7},
            new int[] {9, 8, 1}
        };

        foreach (int[] face in faces)
        {
            Vector3 faceCenter = Vector3.zero;
            foreach (int vertexIndex in face)
            {
                faceCenter += vertices[vertexIndex];
            }
            faceCenter /= face.Length;
            faceCenters.Add(faceCenter);
        }

        return faceCenters;
    }

    private Mesh CreateTetrahedron()
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(1, 1, 1),
            new Vector3(-1, -1, 1),
            new Vector3(-1, 1, -1),
            new Vector3(1, -1, -1)
        };

        int[] triangles = new int[]
        {
            0, 1, 2,
            0, 3, 1,
            0, 2, 3,
            1, 3, 2
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }

    private Mesh CreateCube()
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-1, -1, -1),
            new Vector3(1, -1, -1),
            new Vector3(1, 1, -1),
            new Vector3(-1, 1, -1),
            new Vector3(-1, -1, 1),
            new Vector3(1, -1, 1),
            new Vector3(1, 1, 1),
            new Vector3(-1, 1, 1)
        };

        int[] triangles = new int[]
        {
            // Bottom
            0, 1, 2,
            0, 2, 3,
            // Left
            4, 0, 3,
            4, 3, 7,
            // Front
            4, 5, 1,
            4, 1, 0,
            // Back
            7, 6, 2,
            7, 2, 3,
            // Right
            5, 6, 2,
            5, 2, 1,
            // Top
            7, 6, 5,
            7, 5, 4
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }

    private Mesh CreateOctahedron()
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(1, 0, 0),
            new Vector3(-1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(0, -1, 0),
            new Vector3(0, 0, 1),
            new Vector3(0, 0, -1)
        };

        int[] triangles = new int[]
        {
            0, 2, 4,
            0, 4, 3,
            0, 3, 5,
            0, 5, 2,
            1, 4, 2,
            1, 3, 4,
            1, 5, 3,
            1, 2, 5
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }

    private Mesh CreatePentagon()
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[5];
        float radius = 1f; // You can adjust the radius as needed

        for (int i = 0; i < 5; i++)
        {
            float angle = i * (2 * Mathf.PI / 5);
            vertices[i] = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
        }

        int[] triangles = new int[] { 0, 1, 2, 0, 2, 3, 0, 3, 4 };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }

    public Mesh CreateTrapezohedron()
    {
        Mesh mesh = new Mesh();

        // Vertices
        Vector3[] vertices = new Vector3[10];
        float phi = (1f + Mathf.Sqrt(5f)) / 2f; // Golden ratio
        float halfHeight = 0.5f * Mathf.Sqrt(phi + 2f);
        float scaleFactor = 1f / Mathf.Sqrt(1f + phi * phi);

        vertices[0] = new Vector3(0f, halfHeight, 0f); // Top vertex
        vertices[1] = new Vector3(0f, -halfHeight, 0f); // Bottom vertex

        // Vertices around the top
        for (int i = 0; i < 5; i++)
        {
            float theta = 2f * Mathf.PI * i / 5f;
            vertices[i + 2] = new Vector3(scaleFactor * Mathf.Cos(theta), halfHeight, scaleFactor * Mathf.Sin(theta));
        }

        // Vertices around the bottom
        for (int i = 0; i < 5; i++)
        {
            float theta = 2f * Mathf.PI * (i + 0.5f) / 5f;
            vertices[i + 7] = new Vector3(scaleFactor * Mathf.Cos(theta), -halfHeight, scaleFactor * Mathf.Sin(theta));
        }

        // Triangles
        int[] triangles = {
            0, 2, 3,
            0, 3, 4,
            0, 4, 5,
            0, 5, 6,
            0, 6, 2,
            1, 7, 8,
            1, 8, 9,
            1, 9, 10,
            1, 10, 11,
            1, 11, 7,
            2, 7, 3,
            3, 8, 4,
            4, 9, 5,
            5, 10, 6,
            6, 11, 2,
            7, 8, 9,
            7, 9, 10,
            7, 10, 11
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        // Recalculating normals
        mesh.RecalculateNormals();

        return mesh;
    }

    private Mesh CreateIcosahedron()
    {
        Mesh mesh = new Mesh();

        float t = (1.0f + Mathf.Sqrt(5.0f)) / 2.0f;

        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-1,  t,  0),
            new Vector3( 1,  t,  0),
            new Vector3(-1, -t,  0),
            new Vector3( 1, -t,  0),
            new Vector3( 0, -1,  t),
            new Vector3( 0,  1,  t),
            new Vector3( 0, -1, -t),
            new Vector3( 0,  1, -t),
            new Vector3( t,  0, -1),
            new Vector3( t,  0,  1),
            new Vector3(-t,  0, -1),
            new Vector3(-t,  0,  1)
        };

        int[] triangles = new int[]
        {
            0, 11,  5,
            0,  5,  1,
            0,  1,  7,
            0,  7, 10,
            0, 10, 11,
             1,  5,  9,
             5, 11,  4,
            11, 10,  2,
            10,  7,  6,
             7,  1,  8,
             3,  9,  4,
             3,  4,  2,
             3,  2,  6,
             3,  6,  8,
             3,  8,  9,
             4,  9,  5,
             2,  4, 11,
             6,  2, 10,
             8,  6,  7,
             9,  8,  1
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }

    // Public method to change dice color
    public void SetDiceColor(Color newColor)
    {
        if (diceMaterial != null)
        {
            diceMaterial.color = newColor;
        }
    }
}
