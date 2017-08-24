using UnityEngine;
using System.Collections;

public class GizmoVisualizer : MonoBehaviour
{
   public enum GizmoType
    {
        Cube,
        Sphere,
    }

    public GizmoType gizmoType;
    [Range(0,1f)]
    public float alpha = 1;
    public float debugSize = 0.03f;
    public Color DebugColor = Color.blue;

  

  void OnDrawGizmos()
    {
        Gizmos.color = DebugColor;
        Gizmos.matrix = transform.localToWorldMatrix;
      
        switch (gizmoType)
        {
            case GizmoType.Cube:
                Gizmos.DrawWireCube(Vector3.zero, new Vector3(debugSize, debugSize, debugSize));
                Gizmos.color = new Color(DebugColor.r, DebugColor.g, DebugColor.b, alpha);
                Gizmos.DrawCube(Vector3.zero, new Vector3(debugSize,debugSize,debugSize));
                break;
            case GizmoType.Sphere:
               
                Gizmos.DrawWireSphere(Vector3.zero, debugSize);
                Gizmos.color = new Color(DebugColor.r, DebugColor.g, DebugColor.b, alpha);
                Gizmos.DrawSphere(Vector3.zero, debugSize);
                break;
            default:
                break;
        }
       
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,1,0,1);
        Gizmos.matrix = transform.localToWorldMatrix;

        switch (gizmoType)
        {
            case GizmoType.Cube:
               // Gizmos.matrix = matrix;
                Gizmos.DrawWireCube(Vector3.zero, new Vector3(debugSize, debugSize, debugSize));       
                break;
            case GizmoType.Sphere:
               // Gizmos.matrix = transform.worldToLocalMatrix;
                Gizmos.DrawWireSphere(Vector3.zero, debugSize);       
                break;
        }
    }
}