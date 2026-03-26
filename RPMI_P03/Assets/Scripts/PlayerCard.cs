using UnityEngine;

public class PlayerCard : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z= 0;
        transform.position = newPosition;
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sortingLayerName = "Selected Cards";
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sortingLayerName = "Default";
    }

}

