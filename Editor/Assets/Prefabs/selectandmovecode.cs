using UnityEngine;
using UnityEngine.EventSystems;

public class selectandmovecode : MonoBehaviour
{
    Renderer sideobjrend;
    [SerializeField] GameObject Myscene;
    [SerializeField] GameObject[] prefabs;
    bool Karaktersahnesimi = false;
    public GameObject gameScene;
    public GameObject[] buttons;
    public GameObject text;

    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(ray.origin, ray.direction * 20);
        Debug.DrawRay(ray.origin, ray.direction * 20, Color.cyan);

        moveControl(hit);
        selectPoints(hit);


        
    }   
    private void selectPoints(RaycastHit2D hit)
    {
        if (Input.GetMouseButtonDown(0)&&Karaktersahnesimi)
        {


        }


    }
    private void moveControl(RaycastHit2D hit)
    {
        if (Input.GetMouseButton(0)&&!Karaktersahnesimi)
        {
            if (hit.transform.gameObject.CompareTag("Prefab"))
            {
                sideobjrend = hit.collider.GetComponent<Renderer>();
                hit.collider.gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -1);
                sideobjrend.material.SetColor("_Color", Color.blue);

            }

        }
        else if (Input.GetMouseButtonUp(0)&&!Karaktersahnesimi&& hit.transform.gameObject.CompareTag("Prefab"))
        {
            sideobjrend.material.SetColor("_Color", Color.white);
            sideobjrend.transform.position.Set(sideobjrend.transform.position.x, sideobjrend.transform.position.y, 0);

        }
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
    public void CraftGameobject(string name)
    {
        foreach (GameObject gameObject in prefabs)
        {
            if (gameObject.name == name) sideobjrend = Instantiate(gameObject, Myscene.transform).GetComponent<Renderer>();
        }


    }
    public void craftCharacter()
    {
        Karaktersahnesimi = true;
        //ekrandaki  herşeyi kapat 
        gameScene.SetActive(false);
        //butonları da kapat
        foreach(GameObject butonlar in buttons)
        {
            butonlar.SetActive(false);
        }
        text.SetActive(true);


    }
}
