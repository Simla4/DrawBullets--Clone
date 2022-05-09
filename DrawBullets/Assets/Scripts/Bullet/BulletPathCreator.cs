using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class BulletPathCreator : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<Vector3> points = new List<Vector3>();
    public Action<IEnumerable<Vector3>> OnNewPathCreated = delegate { };

    private void OnEnable()
    {
        InputManager.OnStartDrawingBulletPath += ClearPoints;
        InputManager.OnDrawingBulletPath += DrawingBulletPath;
        InputManager.OnBulletFire += CreateNewPath;
    }
    private void OnDisable()
    {
        InputManager.OnStartDrawingBulletPath -= ClearPoints;
        InputManager.OnDrawingBulletPath -= DrawingBulletPath;
        InputManager.OnBulletFire -= CreateNewPath;
    }

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        InputManager.Instance.FireBullet();
    }
    private void ClearPoints()
    {
        points.Clear();
    }

    private void DrawingBulletPath()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo))
        {
            if(DistaceToLastPoint(hitInfo.point) > 1f)
            {
                points.Add(hitInfo.point);
                lineRenderer.positionCount = points.Count;
                lineRenderer.SetPositions(points.ToArray());
            }
        }
    }

    private void CreateNewPath()
    {
        OnNewPathCreated(points);
    }

    private float DistaceToLastPoint(Vector3 point)
    {
        if(!points.Any())
            return Mathf.Infinity;
        return Vector3.Distance(points.Last(), point);
    }
}
