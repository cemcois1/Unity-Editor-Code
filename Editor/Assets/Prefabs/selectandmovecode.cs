using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class selectandmovecode : MonoBehaviour
{
    Vector2 selectedPosition;
    private GameObject saklananObjem;
    public Color colorone;


    void Update()
    {
        selectedPosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 ray = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(Camera.main.transform.position, selectedPosition);



        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject()&& hit.collider.CompareTag("Prefab"))
        {

            try
            {
                //if (hit.collider.CompareTag("Prefab"))
                {
                    //print(hit.collider.name);
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                    hit.collider.gameObject.transform.position = selectedPosition;
                    saklananObjem = hit.collider.gameObject;
                }
            }
            catch (System.NullReferenceException hata)
            {

                throw new System.NullReferenceException("Farkındayım", hata);

            }
        }
        else if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject() && hit.collider.CompareTag("Prefab"))
        {

            hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;

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
    public void turnLeft() {
        saklananObjem.transform.rotation =new Quaternion(saklananObjem.transform.rotation.x, saklananObjem.transform.rotation.y, saklananObjem.transform.rotation.z+45, saklananObjem.transform.rotation.w);
    }
    public void turnRight() { 
        saklananObjem.transform.rotation =new Quaternion(saklananObjem.transform.rotation.x, saklananObjem.transform.rotation.y, saklananObjem.transform.rotation.z-45, saklananObjem.transform.rotation.w);
    }
}
