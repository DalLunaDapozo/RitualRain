using UnityEngine;


[ExecuteInEditMode]
public class OrderInLayerEntity : MonoBehaviour
{

    [SerializeField] private int plusOrder;

    public SpriteRenderer sr;
    private TrailRenderer trail;

    public bool isSpriteRenderer;
    public bool isTrailRenderer;

    private void Start()
    {
        if (isSpriteRenderer)
            sr = GetComponent<SpriteRenderer>();
        if (isTrailRenderer)
            trail = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        if (isSpriteRenderer)
            sr.sortingOrder = -(int)(transform.position.y * 100) + plusOrder;
 
        else if (isTrailRenderer)
            trail.sortingOrder = -(int)(transform.position.y * 100) + plusOrder;     
    }
}
