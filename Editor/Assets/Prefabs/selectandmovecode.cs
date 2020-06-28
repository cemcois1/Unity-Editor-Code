using UnityEngine;
using UnityEngine.EventSystems;

public class selectandmovecode : MonoBehaviour
{
    private Vector2 selectedPosition;
    private GameObject saklananObjem;
    public Color colorone;

    void Update()
    {
        selectedPosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 ray = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.transform.position, selectedPosition);
        


        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject() && hit.collider.CompareTag("Prefab")  )
        {

            try
            {

                hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;

                hit.collider.gameObject.transform.position = selectedPosition;
                hit.collider.gameObject.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, -1);
                saklananObjem = hit.collider.gameObject;

            }
            catch (System.NullReferenceException hata)
            {

                throw new System.NullReferenceException("Farkındayım", hata);

            }

        }
        else if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject() && hit.collider.CompareTag("Prefab"))
        {

            hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
            hit.collider.gameObject.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, 0);

        }

    }
    public void sizeUp()
    {
        saklananObjem.transform.localScale = saklananObjem.transform.localScale * (1.5f);

    }
    public void sizeDown()
    {
        saklananObjem.transform.localScale = saklananObjem.transform.localScale * (.5f);

    }
    public void turnLeft()
    {
        saklananObjem.transform.Rotate(new Vector3(0, 0, 30));
    }
    public void turnRight()
    {
        saklananObjem.transform.Rotate(new Vector3(0, 0, -30));

    }
    public void lenghtUp()
    {
        saklananObjem.transform.localScale = new Vector3(saklananObjem.transform.localScale.x+1, saklananObjem.transform.localScale.y, saklananObjem.transform.localScale.z);
    }
}
