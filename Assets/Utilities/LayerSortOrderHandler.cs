using UnityEngine;

[
    RequireComponent(typeof(SpriteRenderer)),
]
public class LayerSortOrderHandler : MonoBehaviour {

    private SpriteRenderer _spriteRenderer;
    private int _startSortingOrder;
    private float _halfHeight;

    //
    // Divider of position.y to make the order of layer more precise 
    //
    private readonly int divider = 100;

    void Start () {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _startSortingOrder = Constants.StartSortingOrder + _spriteRenderer.sortingOrder;

        //
        // half height of the image, because the position.y is center of the image
        // we need the bottom of the image, to know when to switch layers
        //
        _halfHeight = _spriteRenderer.bounds.size.y / 2;
    }

    private void Update()
    {
        //
        // Svart magi och julmust händer här
        // We need to do this because Order in Layer only support (16365 * 2), if the order in layer is about to reach this number
        // it needs to be resetted or divided, so the items / players can go endless without any problems with the layer order
        //
        var howManyTimesToDividePosition = ((Mathf.RoundToInt(Mathf.Abs(transform.position.y) * divider)) / Constants.StartSortingOrder) + 1;
        var fakePosY = transform.position.y / howManyTimesToDividePosition;

        var newSortOrder = _startSortingOrder - Mathf.RoundToInt((fakePosY - _halfHeight) * divider);
       
        if (!_spriteRenderer.Equals(newSortOrder))
        {
            _spriteRenderer.sortingOrder = newSortOrder;
        }
    }
}
