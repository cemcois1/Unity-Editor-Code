using UnityEngine;
using UnityEditor.Advertisements;
using System.Collections;

public class selectandmovecode : MonoBehaviour
{
    [SerializeField] GameObject nokta;
    [SerializeField] GameObject kaydetbutton;
    Renderer sideobjrend;
    [SerializeField] GameObject Myscene;
    [SerializeField] GameObject[] prefabs;
    public GameObject gameScene;
    public GameObject[] buttons;
    public GameObject text;
    public GameObject parent;
    bool Karaktersahnesimi = false;
    int i = 0;


    ArrayList arrayList = new ArrayList();

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
        if (Input.GetMouseButtonDown(0) && Karaktersahnesimi)
        {
            print(hit.collider.name);
            // if (hit.collider.name)
            {

            }
            //noktalar adında bir  prefabım olsun  -------
            // prefabım  rayin hit ettiği noktada oluştursun--------
            Instantiate(nokta, new Vector3(hit.point.x, hit.point.y, -1), Quaternion.identity, parent.transform);
            //noktaları 3 lü olacak şekilde bir diziye kaydetsin ve çizsin 
            arrayList.Add(hit.point.x);
            arrayList.Add(hit.point.y);


            //sonra da başka 3 lü noktalar seçilir bitti butonuna basılana kadar


        }


    }
    private void moveControl(RaycastHit2D hit)
    {
        if (Input.GetMouseButton(0) && !Karaktersahnesimi)
        {
            if (hit.transform.gameObject.CompareTag("Prefab"))
            {
                hit.collider.GetComponent<BoxCollider2D>().size = new Vector2(5, 5);
                sideobjrend = hit.collider.GetComponent<Renderer>();

                hit.collider.gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -1);
                sideobjrend.material.SetColor("_Color", Color.blue);


            }

        }
        else if (Input.GetMouseButtonUp(0) && !Karaktersahnesimi && hit.transform.gameObject.CompareTag("Prefab"))
        {
            hit.collider.GetComponent<BoxCollider2D>().size = new Vector2(0.75f, 0.75f);

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
    public void kaydet()
    {
        print("girdi");
        bool basarilimi = false;
        //eğer kaydet butonuna basılırsa  karakter prefab olarak kaydet  noktaları
        string localpath = @"Assets\\Prefabs\\Karakter\\" + i++ +".prefab";
        UnityEditor.PrefabUtility.SaveAsPrefabAsset(parent, assetPath: localpath, out basarilimi);
        if (basarilimi == false)
        {
            print("basarisiz");

        }
        if (basarilimi == true)
        {
            print("basarili");

        }


    }
    public void craftCharacter()
    {
        Karaktersahnesimi = true;
        //ekrandaki  herşeyi kapat 
        gameScene.SetActive(false);

        //butonları da kapat
        foreach (GameObject butonlar in buttons)
        {
            butonlar.SetActive(false);
        }
        text.SetActive(true);
        //kaydet buttonunu aç
        kaydetbutton.SetActive(true);

    }
    public void backToGamedesign()
    {
        Karaktersahnesimi = false;
        gameScene.SetActive(true);
        foreach (GameObject butonlar in buttons)
        {
            butonlar.SetActive(true);
        }
        text.SetActive(false);
        kaydetbutton.SetActive(false);
    }
}
