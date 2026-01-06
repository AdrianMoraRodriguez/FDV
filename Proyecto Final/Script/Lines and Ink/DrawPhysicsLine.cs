using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrawPhysicsLine : MonoBehaviour
{
    [Header("Line Settings")]
    public GameObject linePrefab;        // Prefab con LineRenderer vacío
    public float minDistance = 0.05f;    // Distancia mínima entre puntos
    public float lineThickness = 0.05f;  // Grosor visual y físico
    public float simplifyTolerance = 0.02f; // Para reducir puntos
    public Material lineMaterial;
    public float inkCostPerUnit = 1f; // Costo de tinta por unidad de longitud
    private bool canDraw = true;
    private bool isDrawing = false;
    private float gravityScale = 1f;
    private bool touchedZone = false;

    [Header("Draw Zone Settings")]
    public LayerMask drawZoneLayer;
    public float zoneCheckRadius = 0.1f;
    private bool zoneAllowsDrawing = true;

    [Header("Weight Settings")]
    public float maxWeight = 10f;  // Peso máximo que puede tener la línea
    public float weightFactor = 0.02f;  // Factor de aumento de peso por cada porción de tinta gastada
    private float currentWeight = 0f;  // Peso actual de la línea

    private LineRenderer currentLine;
    private List<Vector3> points = new();
    public Camera cam;

    void Start()
    {
        GameMode.OnGameModeChanged += OnModeChanged;
        if (cam == null)
            cam = Camera.main;
    }

    void Update()
    {
        if (!canDraw) return;

        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        UpdateZoneFromMouse(mousePos);
        if (!zoneAllowsDrawing)
        {
            if (isDrawing)
                FinishLine();
            return;
        }
        if (Input.GetMouseButtonDown(0))
            StartLine();
        else if (Input.GetMouseButton(0))
            ContinueLine();
        else if (Input.GetMouseButtonUp(0))
            FinishLine();
    }

    private void OnModeChanged(bool isPlaying)
    {
        canDraw = !isPlaying;

        if (!canDraw && isDrawing)
        {
           FinishLine();
        }
    }

    void StartLine()
    {
        // Si no hay tinta, no se puede iniciar un trazo
        if (InkSystem.Instance.currentInk <= 0f)
            return;
        touchedZone = false;
        isDrawing = true;
        GameEvents.OnDrawStart?.Invoke();
        GameObject lineObj = Instantiate(linePrefab);
        lineObj.layer = LayerMask.NameToLayer("Ground");
        currentLine = lineObj.GetComponent<LineRenderer>();
        currentLine.positionCount = 0;
        if (lineMaterial != null)
        {
            currentLine.material = lineMaterial;
        }
        points.Clear();
    }



    void ContinueLine()
    {
        if (!currentLine) return;

        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        if (points.Count == 0)
        {
            if (!InkSystem.Instance.TryConsume(0)) // asegura inicio
            {
                CancelLine();
                return;
            }

            points.Add(mousePos);
            currentLine.positionCount = 1;
            currentLine.SetPosition(0, mousePos);
            return;
        }

        float dist = Vector3.Distance(mousePos, points[^1]);
        if (dist < minDistance) return;

        float cost = dist * InkSystem.Instance.maxInk * inkCostPerUnit; 

        // Intentar gastar tinta
        if (!InkSystem.Instance.TryConsume(cost))
        {
            //FinishLine(); // finaliza si no hay tinta
            return;
        }

        points.Add(mousePos);
        currentLine.positionCount = points.Count;
        currentLine.SetPosition(points.Count - 1, mousePos);
        float inkPercentage = InkSystem.Instance.currentInk / InkSystem.Instance.maxInk;
        UpdateWeight(dist);
    }

    void UpdateWeight(float dist)
    {
        currentWeight += dist * weightFactor;

        if (currentWeight > maxWeight)
            currentWeight = maxWeight;
        Debug.Log("Current Line Weight: " + currentWeight);
    }

    void CancelLine()
    {
        if (currentLine)
            Destroy(currentLine.gameObject);

        isDrawing = false;
        currentLine = null;
        currentWeight = 0f;
        points.Clear();
    }




    void FinishLine()
    {
        if (!currentLine || points.Count < 2)
        {
            if (currentLine) Destroy(currentLine.gameObject);
            return;
        }
        // Simplificar la línea para que tenga menos puntos
        var simplified = Simplify(points, simplifyTolerance);
        // Convertir en cuerpo físico
        CreatePhysicalObject(simplified);
        isDrawing = false;
        currentLine = null;
        currentWeight = 0f;
        points.Clear();
    }

    // Generar un cuerpo físico
    void CreatePhysicalObject(List<Vector3> pts)
    {
        Rigidbody2D rb = currentLine.gameObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = gravityScale;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.mass = currentWeight;
        rb.linearDamping = 0.5f;
        rb.angularDamping = 0.5f;

        PolygonCollider2D poly = currentLine.gameObject.AddComponent<PolygonCollider2D>();
        List<Vector2> upper = new();
        List<Vector2> lower = new();

        // Generar las dos caras del "tubo"
        for (int i = 0; i < pts.Count; i++)
        {
            Vector2 dir;
            if (i == 0) dir = (pts[1] - pts[0]).normalized;
            else dir = (pts[i] - pts[i - 1]).normalized;

            Vector2 normal = new(-dir.y, dir.x);
            upper.Add((Vector2)pts[i] + normal * lineThickness);
            lower.Insert(0, (Vector2)pts[i] - normal * lineThickness);
        }

        List<Vector2> shape = new();
        shape.AddRange(upper);
        shape.AddRange(lower);
        poly.SetPath(0, shape
        .Select(p => (Vector2)currentLine.transform.InverseTransformPoint(p))
        .ToArray());

        // Alinear LineRenderer al objeto físico
        currentLine.useWorldSpace = false;
        currentLine.positionCount = pts.Count;
        for (int i = 0; i < pts.Count; i++)
            currentLine.SetPosition(i, currentLine.transform.InverseTransformPoint(pts[i]));
    }

    // Simplificador de puntos (Ramer–Douglas–Peucker)
    List<Vector3> Simplify(List<Vector3> points, float tolerance)
    {
        if (points.Count < 3) return points;
        return RDP(points, tolerance);
    }

    List<Vector3> RDP(List<Vector3> pts, float eps)
    {
        if (pts.Count < 3) return new List<Vector3>(pts);
        int index = -1;
        float dmax = 0f;
        for (int i = 1; i < pts.Count - 1; i++)
        {
            float d = PerpendicularDistance(pts[i], pts[0], pts[^1]);
            if (d > dmax)
            {
                index = i;
                dmax = d;
            }
        }
        if (dmax > eps)
        {
            var left = RDP(pts.GetRange(0, index + 1), eps);
            var right = RDP(pts.GetRange(index, pts.Count - index), eps);
            left.RemoveAt(left.Count - 1);
            left.AddRange(right);
            return left;
        }
        else
        {
            return new List<Vector3> { pts[0], pts[^1] };
        }
    }

    float PerpendicularDistance(Vector3 p, Vector3 a, Vector3 b)
    {
        if (a == b) return Vector3.Distance(p, a);
        return Mathf.Abs((b.x - a.x) * (a.y - p.y) - (a.x - p.x) * (b.y - a.y)) /
               Mathf.Sqrt(Mathf.Pow(b.x - a.x, 2) + Mathf.Pow(b.y - a.y, 2));
    }

    void UpdateZoneFromMouse(Vector3 mouseWorld)
    {
        zoneAllowsDrawing = true;
        if (!touchedZone) {
            gravityScale = 1f;
        }

        Collider2D hit = Physics2D.OverlapCircle(mouseWorld, zoneCheckRadius, drawZoneLayer);

        if (hit == null) return;
        if (hit.CompareTag("CantDraw"))
        {
            zoneAllowsDrawing = false;
            return;
        }
        if (hit.CompareTag("FloatDraw"))
        {
            gravityScale = 0f;
            touchedZone = true;
        }
    }

}
