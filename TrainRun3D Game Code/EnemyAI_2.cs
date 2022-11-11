using System.Collections.Generic;
using UnityEngine;
//[ExecuteInEditMode]

public class EnemyAI_2 : MonoBehaviour
{
    public GameData StoreData;
    private Rigidbody rb;
    private Vector3 lookPos;
    private Transform Enemy;
    private Transform buggy;
    public LayerMask groundMask;
    public GameObject obj;
    public GameObject cube;
    public GameObject child;
    public GameObject Yellow2;
    private GameObject visual;
    private GameObject[] Yellow;
    private GameObject[] ExitEnter;
    private GameObject[] WayPoints;
    private GameObject[] yellowRoute0;
    private GameObject[] yellowRoute1;
    private GameObject[] yellowRoute2;
    private GameObject[] yellowRoute3;
    private GameObject[] yellowRoute4;
    private GameObject[] yellowRoute5;
    private readonly GameObject[] YellowRoute6;
    public int Level;
    private int Block = 0;
    public int WantEnter = 0;
    private int RailItems = 0;
    private int currentWP = 0;
    private int collecteditems2;
    private int ObjectInBuggy = 0;
    private int RandomCollectables;
    private int collecteditems = 0;
    private int RailItemStoper = 1;
    private int waypointsSeter = 1;
    private int TotalRailItems = 32;
    private int CalledOnceForOnRail = 1;
    private int CalledOnceForOnRail2 = 1;
    public bool OnRail;
    public float E2L_x;
    public float E2L_y;
    public float E2L_z;
    public float speed;
    public float distance;
    public float TurningSpeed;
    public float rotSpeed = 10;
    public float groundistance = 0.4f;
    public float GravityMultiplier = 1;
    private readonly List<GameObject> rails = new List<GameObject>();
    private readonly List<GameObject> waypoints = new List<GameObject>();
    public List<GameObject> exitEnter = new List<GameObject>();
    private readonly List<GameObject> YellowRoute0 = new List<GameObject>();
    private readonly List<GameObject> YellowRoute1 = new List<GameObject>();
    private readonly List<GameObject> YellowRoute2 = new List<GameObject>();
    private readonly List<GameObject> YellowRoute3 = new List<GameObject>();
    private readonly List<GameObject> YellowRoute4 = new List<GameObject>();
    private readonly List<GameObject> YellowRoute5 = new List<GameObject>();
    public List<GameObject> YellowBlock = new List<GameObject>();

    private void Awake()
    {
        Level = GameManager.Instance.LevelSelected;
    }
    private void Start()
    {
        Yellow = GameObject.FindGameObjectsWithTag("Yellow");
        ExitEnter = GameObject.FindGameObjectsWithTag("YellowExit");
        for (int i = 0; i < ExitEnter.Length; i++)
        {
            exitEnter.Add(GameObject.Find("YellowExit" + i.ToString()));
        }
        yellowRoute0 = GameObject.FindGameObjectsWithTag("YellowRoute");
        for (int i = 0; i < yellowRoute0.Length; i++)
        {
            YellowRoute0.Add(GameObject.Find("0YellowRoute" + i.ToString()));
        }
        yellowRoute1 = GameObject.FindGameObjectsWithTag("YellowRoute2");
        for (int i = 0; i < yellowRoute1.Length; i++)
        {
            YellowRoute1.Add(GameObject.Find("1YellowRoute" + i.ToString()));
        }
        yellowRoute2 = GameObject.FindGameObjectsWithTag("YellowRoute3");
        for (int i = 0; i < yellowRoute2.Length; i++)
        {
            YellowRoute2.Add(GameObject.Find("2YellowRoute" + i.ToString()));
        }
        yellowRoute3 = GameObject.FindGameObjectsWithTag("YellowRoute4");
        for (int i = 0; i < yellowRoute3.Length; i++)
        {
            YellowRoute3.Add(GameObject.Find("3YellowRoute" + i.ToString()));
        }
        yellowRoute4 = GameObject.FindGameObjectsWithTag("YellowRoute5");
        for (int i = 0; i < yellowRoute4.Length; i++)
        {
            YellowRoute4.Add(GameObject.Find("4YellowRoute" + i.ToString()));
        }
        yellowRoute5 = GameObject.FindGameObjectsWithTag("YellowRoute6");
        for (int i = 0; i < yellowRoute5.Length; i++)
        {
            YellowRoute5.Add(GameObject.Find("5YellowRoute" + i.ToString()));
        }
        WayPoints = GameObject.FindGameObjectsWithTag("WayPoint");
        for (int i = 0; i < WayPoints.Length; i++)
        {
            waypoints.Add(GameObject.Find("WayPoint" + i.ToString()));
        }
        //for (int i = 1; i < 66; i++)
        //{
        //    YellowBlock.Add(GameObject.Find("BlueBlock (" + i.ToString() + ")"));
        //}
        //for (int i = 0; i < 65; i++)
        //{
        //    YellowBlock[i].name = "YellowBlock (" + i.ToString() + ")";
        //}
        buggy = GameObject.FindWithTag("YellowBuggy").transform;
        Enemy = GameObject.FindWithTag("Enemy2").transform;
        rb = GetComponent<Rigidbody>();
        RandomCollectables = Random.Range(19, 25);
    }

    private void Update()
    {
        if (Block == 0)
        {
            E2L_x = 11.342f;
            E2L_y = 3.499563f;
            E2L_z = -12.076f;
        }
        else
        {
            switch (Level)
            {
                case 1:
                    E2L_x = Block == 1 ? 11.227f : Block == 2 ? 14.526f : 0;
                    E2L_y = Block == 1 ? 3.499563f : Block == 2 ? 3.499563f : 0;
                    E2L_z = Block == 1 ? -24.115f : Block == 2 ? -33.625f : 0;
                    break;
                case 2:
                    E2L_x = Block == 1 ? 14.421f : Block == 2 ? 11.219f : 0;
                    E2L_y = Block == 1 ? 3.500635f : Block == 2 ? 2.052383f : 0;
                    E2L_z = Block == 1 ? -24.182f : Block == 2 ? -43.179f : 0;
                    break;
                case 3:
                    E2L_x = Block == 1 ? 11.227f : Block == 2 ? 11.227f : 0;
                    E2L_y = Block == 1 ? 3.499035f : Block == 2 ? 3.499035f : 0;
                    E2L_z = Block == 1 ? -24.197f : Block == 2 ? -33.732f : 0;
                    break;
                case 4:
                    E2L_x = Block == 1 ? 11.227f : Block == 2 ? 11.227f : 0;
                    E2L_y = Block == 1 ? 3.499035f : Block == 2 ? 3.499035f : 0;
                    E2L_z = Block == 1 ? -24.197f : Block == 2 ? -33.732f : 0;
                    break;
                case 5:
                    E2L_x = Block == 1 ? 11.341f : Block == 2 ? 11.233f : 0;
                    E2L_y = Block == 1 ? 3.504f : Block == 2 ? 6.335f : 0;
                    E2L_z = Block == 1 ? -24.342f : Block == 2 ? -41.996f : 0;
                    break;
                case 6:
                    E2L_x = Block == 1 ? 14.61f : Block == 2 ? 11.234f : Block == 3 ? 10.962f : 0;
                    E2L_y = Block == 1 ? 3.502f : Block == 2 ? 1.966f : Block == 3 ? 1.98f : 0;
                    E2L_z = Block == 1 ? -24.162f : Block == 2 ? -42.024f : Block == 3 ? -51.623f : 0;
                    break;
                case 7:
                    E2L_x = Block == 1 ? 11.168f : Block == 2 ? 11.168f : Block == 3 ? 10.99f : 0;
                    E2L_y = Block == 1 ? 3.503f : Block == 2 ? 6.348f : Block == 3 ? 8.031f : 0;
                    E2L_z = Block == 1 ? -24.342f : Block == 2 ? -41.844f : Block == 3 ? -53.448f : 0;
                    break;
                case 8:
                    E2L_x = Block == 1 ? 11.345f : Block == 2 ? 14.455f : Block == 3 ? 11.237f : Block == 4 ? 11.01f : 0;
                    E2L_y = Block == 1 ? 3.603f : Block == 2 ? 6.457f : Block == 3 ? 3.65f : Block == 4 ? 5.339f : 0;
                    E2L_z = Block == 1 ? -24.248f : Block == 2 ? -35.729f : Block == 3 ? -53.354f : Block == 4 ? -64.907f : 0;
                    break;
                case 9:
                    E2L_x = Block == 1 ? 11.317f : Block == 2 ? 11.317f : Block == 3 ? 11.095f : Block == 4 ? 14.174f : 0;
                    E2L_y = Block == 1 ? 3.504f : Block == 2 ? 3.504f : Block == 3 ? 4.99f : Block == 4 ? 7.86f : 0;
                    E2L_z = Block == 1 ? -23.975f : Block == 2 ? -33.262f : Block == 3 ? -44.73f : Block == 4 ? -62.155f : 0;
                    break;
                case 10:
                    E2L_x = Block == 1 ? 11.036f : Block == 2 ? 11.424f : Block == 3 ? 11.202f : Block == 4 ? 10.946f : Block == 5 ? 14.218f : 0;
                    E2L_y = Block == 1 ? 3.500635f : Block == 2 ? 3.582f : Block == 3 ? 5.921f : Block == 4 ? 8.801f : Block == 5 ? 10.549f : 0;
                    E2L_z = Block == 1 ? -24.233f : Block == 2 ? -38.696f : Block == 3 ? -50.353f : Block == 4 ? -67.762f : Block == 5 ? -79.239f : 0;
                    break;
                default:
                    break;
            }
        }
        if (RailItems == TotalRailItems)
        {
            RailItems = 0;
            collecteditems = 0;
            RailItemStoper = 1;
            RouteValueSetter();
        }
        switch (Level)
        {
            case 1 when ObjectInBuggy > 0 && Block == 2 && OnRail:
                rb.AddForce(Vector3.down * GravityMultiplier, ForceMode.Acceleration);
                break;
            case 2 when ObjectInBuggy > 0 && Block == 1 && OnRail:
                rb.AddForce(Vector3.down * GravityMultiplier, ForceMode.Acceleration);
                break;
            case 6 when ObjectInBuggy > 0 && Block == 1 && OnRail:
                rb.AddForce(Vector3.down * GravityMultiplier, ForceMode.Acceleration);
                break;
            case 7:
                if (OnRail && ObjectInBuggy == 0 && (Block == 1 || Block == 3))
                {
                    rb.AddForce(Vector3.down * GravityMultiplier, ForceMode.Acceleration);
                }
                break;
            case 8:
                if (ObjectInBuggy > 0 && Block == 2 && OnRail)
                {
                    rb.AddForce(Vector3.down * GravityMultiplier, ForceMode.Acceleration);
                }
                else if (OnRail && ObjectInBuggy == 0 && (Block == 1 || Block == 5))
                {
                    rb.AddForce(Vector3.down * GravityMultiplier, ForceMode.Acceleration);
                }
                break;
            case 9:
                if (ObjectInBuggy > 0 && Block == 4 && OnRail)
                {
                    rb.AddForce(Vector3.down * GravityMultiplier, ForceMode.Acceleration);
                }
                else if (OnRail && ObjectInBuggy == 0 && Block == 3)
                {
                    rb.AddForce(Vector3.down * GravityMultiplier, ForceMode.Acceleration);
                }
                break;
            case 10:
                if (ObjectInBuggy > 0 && Block == 5 && OnRail)
                {
                    rb.AddForce(Vector3.down * GravityMultiplier, ForceMode.Acceleration);
                }
                else if (OnRail && ObjectInBuggy == 0 && (Block == 2 || Block == 3))
                {
                    rb.AddForce(Vector3.down * GravityMultiplier, ForceMode.Acceleration);
                }
                break;
            default:
                break;
        }
        if (RailItems == TotalRailItems || ObjectInBuggy == 0)
        {
            WantEnter = 0;
        }
        if (collecteditems >= RandomCollectables && RailItems < TotalRailItems && WantEnter == 0)
        {
            WantEnter = 1;
        }
        if (collecteditems < RandomCollectables && RailItems < TotalRailItems) { GoToWayPoints(); }
        if (WantEnter == 1) { GOTORail(); }
        else if (collecteditems >= RandomCollectables && RailItems < RailItemStoper 
            && RailItemStoper <= TotalRailItems && WantEnter == 2) { WantToBuildRail(); }
        if (OnRail && ObjectInBuggy == 0 && RailItems < TotalRailItems)
        {
            Enemy.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    } // Update Function

    private void GoToWayPoints()
    {
        if (Block == 0 && Vector3.Distance(transform.position, waypoints[currentWP].transform.position) < 1.5)
        {
            currentWP = Random.Range(0, 3);
        }
        else
        {
            switch (Block)
            {
                case 1:
                    if (waypointsSeter == 1)
                    {
                        currentWP = 4;
                        waypointsSeter = 2;
                    }
                    if (Vector3.Distance(transform.position, waypoints[currentWP].transform.position) < 2)
                    {
                        currentWP = Random.Range(4, 7);
                    }
                    break;
                case 2:
                    if (waypointsSeter == 2)
                    {
                        currentWP = 8;
                        waypointsSeter = 3;
                    }
                    if (Vector3.Distance(transform.position, waypoints[currentWP].transform.position) < 2)
                    {
                        currentWP = Random.Range(8, 11);
                    }
                    break;
                case 3:
                    if (waypointsSeter == 3)
                    {
                        currentWP = 12;
                        waypointsSeter = 4;
                    }
                    if (Vector3.Distance(transform.position, waypoints[currentWP].transform.position) < 2)
                    {
                        currentWP = Random.Range(12, 15);
                    }
                    break;
                case 4:
                    if (waypointsSeter == 4)
                    {
                        currentWP = 16;
                        waypointsSeter = 5;
                    }
                    if (Vector3.Distance(transform.position, waypoints[currentWP].transform.position) < 2)
                    {
                        currentWP = Random.Range(16, 19);
                    }
                    break;
                case 5:
                    if (waypointsSeter == 5)
                    {
                        currentWP = 20;
                        waypointsSeter = 6;
                    }
                    if (Vector3.Distance(transform.position, waypoints[currentWP].transform.position) < 2)
                    {
                        currentWP = Random.Range(20, 23);
                    }
                    break;
                default:
                    break;
            }
        }
        Quaternion lookatWP = Quaternion.LookRotation(waypoints[currentWP].transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookatWP, rotSpeed * Time.deltaTime);
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void GOTORail()
    {
        lookPos = Block == 0 ? exitEnter[0].transform.position - transform.position :
                Block == 1 ? exitEnter[1].transform.position - transform.position :
                Block == 2 ? exitEnter[2].transform.position - transform.position :
                Block == 3 ? exitEnter[3].transform.position - transform.position :
                Block == 4 ? exitEnter[4].transform.position - transform.position :
                Block == 5 ? exitEnter[5].transform.position - transform.position :
                exitEnter[6].transform.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * TurningSpeed);
        rb.velocity = speed * transform.forward;
    }

    private void WantToBuildRail()
    {
        lookPos = Block == 0 ? YellowRoute0[RailItems].transform.position - transform.position :
                Block == 1 ? YellowRoute1[RailItems].transform.position - transform.position :
                Block == 2 ? YellowRoute2[RailItems].transform.position - transform.position :
                Block == 3 ? YellowRoute3[RailItems].transform.position - transform.position :
                Block == 4 ? YellowRoute4[RailItems].transform.position - transform.position :
                Block == 5 ? YellowRoute5[RailItems].transform.position - transform.position :
                YellowRoute6[0].transform.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * TurningSpeed);
        rb.velocity = speed * transform.forward;
    }

    private void RouteValueSetter()
    {
        if (Level == 1 || Level == 3 || Level == 4)
        {
            TotalRailItems = Block == 0 ? 19 : Block == 1 ? 60 : 0;
            Block = Block == 0 ? 1 : Block == 1 ? 2 : 3;
        }
        else if (Level == 2 || Level == 5)
        {
            TotalRailItems = Block == 0 ? 60 : Block == 1 ? 19 : 0;
            Block = Block == 0 ? 1 : Block == 1 ? 2 : 3;
        }
        else if (Level == 6 || Level == 7)
        {
            TotalRailItems = Block == 0 ? 60 : Block == 1 ? 19 : Block == 2 ? 60 : 0;
            Block = Block == 0 ? 1 : Block == 1 ? 2 : Block == 2 ? 3 : 4;
        }
        else if (Level == 8)
        {
            TotalRailItems = Block == 0 ? 32 : Block == 1 ? 60 : Block == 2 ? 19 : Block == 3 ? 60 : 0;
            Block = Block == 0 ? 1 : Block == 1 ? 2 : Block == 2 ? 3 : Block == 3 ? 4 : 5;
        }
        else if (Level == 9)
        {
            TotalRailItems = Block == 0 ? 19 : Block == 1 ? 19 : Block == 2 ? 60 : Block == 3 ? 60 : 0;
            Block = Block == 0 ? 1 : Block == 1 ? 2 : Block == 2 ? 3 : Block == 3 ? 4 : 5;
        }
        else if (Level == 10)
        {
            TotalRailItems = Block == 0 ? 43 : Block == 1 ? 32 : Block == 2 ? 60 : Block == 3 ? 19 : Block == 4 ? 60 : 0;
            Block = Block == 0 ? 1 : Block == 1 ? 2 : Block == 2 ? 3 : Block == 3 ? 4 : Block == 4 ? 5 : 6;
        }
    } // RouterSetter Function

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("YellowExit") && collecteditems > 0 && RailItems
            < TotalRailItems && ObjectInBuggy > 0)
        {
            Enemy.transform.SetPositionAndRotation(new Vector3(E2L_x, E2L_y, E2L_z),
                Quaternion.Euler(0.0f, 180.0f, 0.0f));
            WantEnter = 2;
        }
        if (other.gameObject.CompareTag("YellowRail") && CalledOnceForOnRail2 == 1)
        {
            OnRail = true;
            CalledOnceForOnRail = 1;
            CalledOnceForOnRail2 = 0;
        }
        if (other.gameObject.CompareTag("Yellow"))
        {
            other.gameObject.SetActive(false);
            collecteditems++;
            YellowBlock[collecteditems - 1].SetActive(true);
            collecteditems2++;
            ObjectInBuggy++;
            //Vector3 OrignalPos = child.transform.position;
            //visual = Instantiate(cube, buggy.position, buggy.rotation);
            //visual.transform.parent = child.transform;
            //visual.transform.position = OrignalPos;
            rails.Add(visual);
            if (collecteditems2 == 5)
            {
                foreach (GameObject r in Yellow)
                {
                    r.SetActive(true);
                }
                collecteditems2 = 0;
            }
        }
        if ((other.gameObject.CompareTag("YellowRoute") || other.gameObject.CompareTag("YellowRoute2") 
            || other.gameObject.CompareTag("YellowRoute3") || other.gameObject.CompareTag("YellowRoute4")
            || other.gameObject.CompareTag("YellowRoute5") || other.gameObject.CompareTag("YellowRoute6"))
            && collecteditems >= RandomCollectables)
        {
            Destroy(other.gameObject);
            RailItems++;
            RailItemStoper++;
            visual = Instantiate(Yellow2, other.gameObject.transform.position, other.gameObject.transform.rotation);
            //Destroy(rails[ObjectInBuggy - 1]);
            YellowBlock[ObjectInBuggy - 1].SetActive(false);
            rails.RemoveAt(rails.Count - 1);
            ObjectInBuggy--;
        }
    } // OnTriggerEnter Function

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("YellowLift"))
        {
            other.transform.position += 0.6f * Time.deltaTime * other.transform.up;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("YellowRail") && CalledOnceForOnRail == 1)
        {
            collecteditems = 0;
            OnRail = false;
            CalledOnceForOnRail = 0;
            CalledOnceForOnRail2 = 1;
        }
        if (other.gameObject.CompareTag("YellowRail"))
        {
            RandomCollectables = TotalRailItems - ObjectInBuggy - RailItems + 3;
        }
    }
} // EnemyAI_2 Class