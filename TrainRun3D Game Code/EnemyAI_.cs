using System.Collections.Generic;
using UnityEngine;
//[ExecuteInEditMode]

public class EnemyAI_ : MonoBehaviour
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
    public GameObject blue2;
    private GameObject visual;
    public GameObject FinalWP;
    private GameObject[] blue;
    private GameObject[] ExitEnter;
    private GameObject[] WayPoints;
    private GameObject[] blueRoute0;
    private GameObject[] blueRoute1;
    private GameObject[] blueRoute2;
    private GameObject[] blueRoute3;
    private GameObject[] blueRoute4;
    private GameObject[] blueRoute5;
    private readonly GameObject[] BlueRoute6;
    public int Level;
    private int Block = 0;
    private int RailItems = 0;
    private int WantEnter = 0;
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
    private bool OnRail;
    public float EL_x;
    public float EL_y;
    public float EL_z; 
    public float speed;
    public float distance;
    public float TurningSpeed;
    public float rotSpeed = 10;
    public float groundistance = 0.4f;
    public float GravityMultiplier = 1;
    private readonly List<GameObject> rails = new List<GameObject>();
    private readonly List<GameObject> waypoints = new List<GameObject>();
    private readonly List<GameObject> exitEnter = new List<GameObject>();
    private readonly List<GameObject> BlueRoute0 = new List<GameObject>();
    private readonly List<GameObject> BlueRoute1 = new List<GameObject>();
    private readonly List<GameObject> BlueRoute2 = new List<GameObject>();
    private readonly List<GameObject> BlueRoute3 = new List<GameObject>();
    private readonly List<GameObject> BlueRoute4 = new List<GameObject>();
    private readonly List<GameObject> BlueRoute5 = new List<GameObject>();
    public List<GameObject> BlueBlock = new List<GameObject>();
    public List<GameObject> BFR = new List<GameObject>();

    private void Awake()
    {
        Level = GameManager.Instance.LevelSelected;
    }
    private void Start()
    {
        blue = GameObject.FindGameObjectsWithTag("Blue");
        ExitEnter = GameObject.FindGameObjectsWithTag("blueExit");
        for (int i = 0; i < ExitEnter.Length; i++)
        {
            exitEnter.Add(GameObject.Find("BlueExit" + i.ToString()));
        }
        blueRoute0 = GameObject.FindGameObjectsWithTag("BlueRoute");
        for (int i = 0; i < blueRoute0.Length; i++)
        {
            BlueRoute0.Add(GameObject.Find("0BlueRoute" + i.ToString()));
        }
        blueRoute1 = GameObject.FindGameObjectsWithTag("BlueRoute2");
        for (int i = 0; i < blueRoute1.Length; i++)
        {
            BlueRoute1.Add(GameObject.Find("1BlueRoute" + i.ToString()));
        }
        blueRoute2 = GameObject.FindGameObjectsWithTag("BlueRoute3");
        for (int i = 0; i < blueRoute2.Length; i++)
        {
            BlueRoute2.Add(GameObject.Find("2BlueRoute" + i.ToString()));
        }
        blueRoute3 = GameObject.FindGameObjectsWithTag("BlueRoute4");
        for (int i = 0; i < blueRoute3.Length; i++)
        {
            BlueRoute3.Add(GameObject.Find("3BlueRoute" + i.ToString()));
        }
        blueRoute4 = GameObject.FindGameObjectsWithTag("BlueRoute5");
        for (int i = 0; i < blueRoute4.Length; i++)
        {
            BlueRoute4.Add(GameObject.Find("4BlueRoute" + i.ToString()));
        }
        blueRoute5 = GameObject.FindGameObjectsWithTag("BlueRoute6");
        for (int i = 0; i < blueRoute5.Length; i++)
        {
            BlueRoute5.Add(GameObject.Find("5BlueRoute" + i.ToString()));
        }
        WayPoints = GameObject.FindGameObjectsWithTag("WayPoint");
        for (int i = 0; i < WayPoints.Length; i++)
        {
            waypoints.Add(GameObject.Find("WayPoint" + i.ToString()));
        }
        for (int i = 1; i < 13; i++)
        {
            BFR.Add(GameObject.Find("BFR" + i.ToString()));
        }
        FinalWP = GameObject.Find("BlueFinalWayPoint");
        buggy = GameObject.FindWithTag("BlueBuggy").transform;
        Enemy = GameObject.FindWithTag("Enemy").transform;
        rb = GetComponent<Rigidbody>();
        RandomCollectables = 33;
    }

    private void Update()
    {
        if (Block == 0)
        {
            EL_x = 14.57f;
            EL_y = 3.517563f;
            EL_z = -12.097f;
        }
        else
        {
            switch (Level)
            {
                case 1:
                    EL_x = Block == 1 ? 14.468f : Block == 2 ? 12.749f : 0;
                    EL_y = Block == 1 ? 3.517563f : Block == 2 ? 3.517563f : 0;
                    EL_z = Block == 1 ? -24.115f : Block == 2 ? -33.579f : 0;
                    break;
                case 2:
                    EL_x = Block == 1 ? 12.65f : Block == 2 ? 14.47f : 0;
                    EL_y = Block == 1 ? 3.500635f : Block == 2 ? 2.036803f : 0;
                    EL_z = Block == 1 ? -24.243f : Block == 2 ? -42.258f : 0;
                    break;
                case 3:
                    EL_x = Block == 1 ? 14.468f : Block == 2 ? 12.948f : 0;
                    EL_y = Block == 1 ? 3.519861f : Block == 2 ? 3.541f : 0;
                    EL_z = Block == 1 ? -24.203f : Block == 2 ? -33.69f : 0;
                    break;
                case 4:
                    EL_x = Block == 1 ? 14.468f : Block == 2 ? 12.948f : 0;
                    EL_y = Block == 1 ? 3.519861f : Block == 2 ? 3.541f : 0;
                    EL_z = Block == 1 ? -24.203f : Block == 2 ? -33.69f : 0;
                    break;
                case 5:
                    EL_x = Block == 1 ? 13.059f : Block == 2 ? 14.469f : 0;
                    EL_y = Block == 1 ? 3.521f : Block == 2 ? 6.36f : 0;
                    EL_z = Block == 1 ? -24.298f : Block == 2 ? -42.084f : 0;
                    break;
                case 6:
                    EL_x = Block == 1 ? 12.827f : Block == 2 ? 14.477f : Block == 3 ? 12.685f : 0;
                    EL_y = Block == 1 ? 3.524f : Block == 2 ? 1.987f : Block == 3 ? 2.006f : 0;
                    EL_z = Block == 1 ? -24.25f : Block == 2 ? -42.079f : Block == 3 ? -51.551f : 0;
                    break;
                case 7:
                    EL_x = Block == 1 ? 12.891f : Block == 2 ? 14.468f : Block == 3 ? 12.706f : 0;
                    EL_y = Block == 1 ? 3.557f : Block == 2 ? 6.369f : Block == 3 ? 8.051f : 0;
                    EL_z = Block == 1 ? -24.284f : Block == 2 ? -41.92f : Block == 3 ? -53.392f : 0;
                    break;
                case 8:
                    EL_x = Block == 1 ? 14.579f : Block == 2 ? 12.673f : Block == 3 ? 14.473f : Block == 4 ? 12.729f : 0;
                    EL_y = Block == 1 ? 3.615f : Block == 2 ? 6.493f : Block == 3 ? 3.673f : Block == 4 ? 5.358f : 0;
                    EL_z = Block == 1 ? -24.278f : Block == 2 ? -35.69f : Block == 3 ? -53.363f : Block == 4 ? -64.874f : 0;
                    break;
                case 9:
                    EL_x = Block == 1 ? 14.57f : Block == 2 ? 14.568f : Block == 3 ? 12.823f : Block == 4 ? 12.394f : 0;
                    EL_y = Block == 1 ? 3.552f : Block == 2 ? 3.519f : Block == 3 ? 5.005f : Block == 4 ? 7.884f : 0;
                    EL_z = Block == 1 ? -24.114f : Block == 2 ? -33.31f : Block == 3 ? -44.676f : Block == 4 ? -62.292f : 0;
                    break;
                case 10:
                    EL_x = Block == 1 ? 14.273f : Block == 2 ? 14.663f : Block == 3 ? 12.922f : Block == 4 ? 14.183f : Block == 5 ? 12.443f : 0;
                    EL_y = Block == 1 ? 3.518635f : Block == 2 ? 3.591f : Block == 3 ? 5.943f : Block == 4 ? 8.821f : Block == 5 ? 10.569f : 0;
                    EL_z = Block == 1 ? -24.158f : Block == 2 ? -38.71f : Block == 3 ? -50.319f : Block == 4 ? -67.749f : Block == 5 ? -79.228f : 0;
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
        if (collecteditems == RandomCollectables && RailItems < TotalRailItems && WantEnter == 0)
        {
            WantEnter = 1;
        }
        if (collecteditems < RandomCollectables && RailItems < TotalRailItems) { GoToWayPoints(); }
        if (((Level == 1 || Level == 2) && Block == 2) || ((Level == 4 || Level == 5) && Block == 3))
        {
            if (collecteditems < RandomCollectables && ObjectInBuggy > 0 && RailItems == TotalRailItems)
            {
                Quaternion lookatWP = Quaternion.LookRotation(FinalWP.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookatWP, rotSpeed * Time.deltaTime);
                transform.Translate(0, 0, speed * Time.deltaTime);
            }
        }
        if (WantEnter == 1) { GoTORail(); }
        else if (WantEnter == 2 && collecteditems >= RandomCollectables && RailItems < RailItemStoper
            && RailItemStoper <= TotalRailItems) { WantToBuildRail(); }
        if (OnRail && ObjectInBuggy == 0 && RailItems < TotalRailItems)
        { 
            Enemy.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    } // Update Function

    private void GoToWayPoints()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWP].transform.position) < 1.5 && Block == 0)
        {
            currentWP = Random.Range(0, 3);
        }
        else if (Block == 1)
        {
            if (waypointsSeter == 1)
            {
                currentWP = 5;
                waypointsSeter = 2;
            }
            if (Vector3.Distance(transform.position, waypoints[currentWP].transform.position) < 2)
            {
                currentWP = Random.Range(4, 7);
            }
        }
        else if (Block == 2)
        {
            if (waypointsSeter == 2)
            {
                currentWP = 9;
                waypointsSeter = 3;
            }
            if (Vector3.Distance(transform.position, waypoints[currentWP].transform.position) < 2)
            {
                currentWP = Random.Range(8, 11);
            }
        }
        else if (Block == 3)
        {
            if (waypointsSeter == 3)
            {
                currentWP = 13;
                waypointsSeter = 4;
            }
            if (Vector3.Distance(transform.position, waypoints[currentWP].transform.position) < 2)
            {
                currentWP = Random.Range(12, 15);
            }
        }
        else if (Block == 4)
        {
            if (waypointsSeter == 4)
            {
                currentWP = 17;
                waypointsSeter = 5;
            }
            if (Vector3.Distance(transform.position, waypoints[currentWP].transform.position) < 2)
            {
                currentWP = Random.Range(16, 19);
            }
        }
        else if (Block == 5)
        {
            if (waypointsSeter == 5)
            {
                currentWP = 21;
                waypointsSeter = 6;
            }
            if (Vector3.Distance(transform.position, waypoints[currentWP].transform.position) < 2)
            {
                currentWP = Random.Range(20, 23);
            }
        }
        Quaternion lookatWP = Quaternion.LookRotation(waypoints[currentWP].transform.position -
            transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookatWP, rotSpeed * Time.deltaTime);
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void GoTORail()
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
        lookPos = Block == 0 ? BlueRoute0[RailItems].transform.position - transform.position :
                Block == 1 ? BlueRoute1[RailItems].transform.position - transform.position :
                Block == 2 ? BlueRoute2[RailItems].transform.position - transform.position :
                Block == 3 ? BlueRoute3[RailItems].transform.position - transform.position :
                Block == 4 ? BlueRoute4[RailItems].transform.position - transform.position :
                Block == 5 ? BlueRoute5[RailItems].transform.position - transform.position :
                BlueRoute6[RailItems].transform.position - transform.position;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("blueExit") && collecteditems > 0 && RailItems
            < TotalRailItems && ObjectInBuggy > 0)
        {
            Enemy.transform.SetPositionAndRotation(new Vector3(EL_x, EL_y, EL_z),
                Quaternion.Euler(0.0f, 180.0f, 0.0f));
            WantEnter = 2;
        }
        if (other.gameObject.CompareTag("BlueRail") && CalledOnceForOnRail2 == 1)
        {
            OnRail = true;
            CalledOnceForOnRail = 1;
            CalledOnceForOnRail2 = 0;
        }
        if (other.gameObject.CompareTag("Blue"))
        {
            other.gameObject.SetActive(false);
            collecteditems++;
            BlueBlock[collecteditems - 1].SetActive(true);
            collecteditems2++;
            ObjectInBuggy++;
            rails.Add(visual);
            if (collecteditems2 == 5)
            {
                foreach (GameObject r in blue)
                {
                    r.SetActive(true);
                }
                collecteditems2 = 0;
            }
        }
        if ((other.gameObject.CompareTag("BlueRoute") || other.gameObject.CompareTag("BlueRoute2")
            || other.gameObject.CompareTag("BlueRoute3") || other.gameObject.CompareTag("BlueRoute4")
            || other.gameObject.CompareTag("BlueRoute5") || other.gameObject.CompareTag("BlueRoute6"))
            || (other.gameObject.Equals(BFR) && collecteditems >= RandomCollectables))
        {
            Destroy(other.gameObject);
            RailItems++;
            RailItemStoper++;
            visual = Instantiate(blue2, other.gameObject.transform.position, other.gameObject.transform.rotation);
            BlueBlock[ObjectInBuggy - 1].SetActive(false);
            rails.RemoveAt(rails.Count - 1);
            ObjectInBuggy--;
        }
    } // OnTriggerEnter Function

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("BlueLift")/* && other.transform.position.y < 8.741f*/)
        {
            other.transform.position += 0.6f * Time.deltaTime * other.transform.up;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("BlueRail") && CalledOnceForOnRail == 1)
        {
            collecteditems = 0;
            OnRail = false;
            CalledOnceForOnRail = 0;
            CalledOnceForOnRail2 = 1;
        }
        if (other.gameObject.CompareTag("BlueRail"))
        {
            RandomCollectables = TotalRailItems - ObjectInBuggy - RailItems + 3;
        }
    }
} // EnemyAI Class