using UnityEngine;
using UnityEngine.EventSystems;

public class selectandmovecode : MonoBehaviour
{
    private Vector2 selectedPosition;
    private GameObject saklananObjem;
    public Color colorone;

    /// <summary>
    ///
    /// </summary>
    Renderer sideobjrend;

    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(ray.origin, ray.direction * 20);
        Debug.DrawRay(ray.origin, ray.direction * 20,Color.cyan);
        if (Input.GetMouseButtonDown(0))
        {
            if (hit.transform.gameObject.CompareTag("Prefab"))
            {
                hit.collider.transform.position = new Vector3(ray.direction.x, ray.direction.y, -1);
                sideobjrend.material.SetColor("_Color", Color.blue);
                Debug.Log(hit.collider.name);

            }

        }
        else if (Input.GetMouseButtonUp(0))
        {
            sideobjrend.material.SetColor("_Color", Color.white);

        }

        /*
        selectedPosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 ray = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.transform.position, selectedPosition);



        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && hit.collider.CompareTag("Prefab")  )
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

        }*/

    }
    public void sizeUp()
    {
        sideobjrend.transform.localScale = sideobjrend.transform.localScale * (1.5f);
    }
    public void sizeDown()
    {
        sideobjrend.transform.localScale = sideobjrend.transform.localScale * (.5f);

    }
    public void turnLeft()
    {
        sideobjrend.transform.Rotate(new Vector3(0, 0, 30));
    }
    public void turnRight()
    {
        sideobjrend.transform.Rotate(new Vector3(0, 0, -30));

    }
    public void lenghtUp()
    {
        sideobjrend.transform.localScale = new Vector3(sideobjrend.transform.localScale.x + 1, sideobjrend.transform.localScale.y, sideobjrend.transform.localScale.z);
    }
}
