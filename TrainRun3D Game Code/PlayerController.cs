using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[ExecuteInEditMode]

public class PlayerController : MonoBehaviour
{
    public GameData StoreData;
    public GameObject[] LevelSelectedPC;
    public static PlayerController Instance;
    public FloatingJoystick floatJoy;
    public LayerMask groundMask;
    public GameObject obj, cube, child, red2, RailBoxCollider2, Lift;
    private readonly List<GameObject> rails = new List<GameObject>();
    public List<GameObject> RedBlock = new List<GameObject>();
    public float rotationSpeed, speed = 20, groundistance = 0.4f, GravityMultiplier = 20, PL_x = 14.57f,
        PL_y = 3.500635f, PL_z = -11.21199f; // PL => Player Location
    private GameObject[] red;
    private Vector3 motion;
    private Rigidbody rb;
    public Transform player, buggy, groundcheck;
    public int collecteditems = 0, collecteditems2 = 0, route = 32, c = 0, count = 1, Block = 0, EndOfRail = 1;
    public int Level;
    private GameObject blocker, visual, EOR;
    public bool zero_, OnRail, isGround;

    private void Awake()
    {
        Level = GameManager.Instance.LevelSelected;
    }
    private void Start()
    {
        //for (int i = 0; i < 100; i++)
        //{
        //    RedBlock.Add(GameObject.Find("RedBlock (" + i.ToString() + ")"));
        //}
        if (Level > 1 && Level < 11)
        {
            LevelSelectedPC[0].SetActive(false);
            LevelSelectedPC[Level - 1].SetActive(true);
            LevelSelectedPC[Level - 2].SetActive(false);
        }
        if (Instance == null) { Instance = this; }
        red = GameObject.FindGameObjectsWithTag("Red");
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Block == 0)
        {
            PL_x = 12.904f;
            PL_y = 3.500635f;
            PL_z = -12f;
        }
        else if (Level == 1)
        {
            PL_x = Block == 1 ? 12.796f : Block == 2 ? 11.093f : 0;
            PL_y = Block == 1 ? 3.503384f : Block == 2 ? 3.499563f : 0;
            PL_z = Block == 1 ? -24.144f : Block == 2 ? -33.658f : 0;
        }
        else if (Level == 2)
        {
            PL_x = Block == 1 ? 10.985f : Block == 2 ? 12.788f : 0;
            PL_y = Block == 1 ? 3.538f : Block == 2 ? 2.014303f : 0;
            PL_z = Block == 1 ? -24.138f : Block == 2 ? -42.172f : 0;
        }
        else if (Level == 3)
        {
            PL_x = Block == 1 ? 12.793f : Block == 2 ? 14.686f : 0;
            PL_y = Block == 1 ? 3.500635f : Block == 2 ? 3.500635f : 0;
            PL_z = Block == 1 ? -24.065f : Block == 2 ? -33.587f : 0;
        }
        else if (Level == 4)
        {
            PL_x = Block == 1 ? 12.793f : Block == 2 ? 14.686f : 0;
            PL_y = Block == 1 ? 3.500635f : Block == 2 ? 3.500635f : 0;
            PL_z = Block == 1 ? -24.065f : Block == 2 ? -33.587f : 0;
        }
        else if (Level == 5)
        {
            PL_x = Block == 1 ? 14.72f : Block == 2 ? 12.793f : 0;
            PL_y = Block == 1 ? 3.497496f : Block == 2 ? 6.342f : 0;
            PL_z = Block == 1 ? -24.284f : Block == 2 ? -41.997f : 0;
        }
        else if (Level == 6)
        {
            PL_x = Block == 1 ? 11.162f : Block == 2 ? 12.796f : Block == 3 ? 14.417f : 0;
            PL_y = Block == 1 ? 3.497496f : Block == 2 ? 1.968f : Block == 3 ? 1.983f : 0;
            PL_z = Block == 1 ? -24.284f : Block == 2 ? -42.016f : Block == 3 ? -51.529f : 0;
        }
        else if (Level == 7)
        {
            PL_x = Block == 1 ? 14.632f : Block == 2 ? 12.788f : Block == 3 ? 14.446f : 0;
            PL_y = Block == 1 ? 3.497496f : Block == 2 ? 6.354f : Block == 3 ? 8.032f : 0;
            PL_z = Block == 1 ? -24.169f : Block == 2 ? -41.857f : Block == 3 ? -53.293f : 0;
        }
        else if (Level == 8)
        {
            PL_x = Block == 1 ? 12.92F : Block == 2 ? 11.011F : Block == 3 ? 12.792F : Block == 4 ? 14.462F : 0;
            PL_y = Block == 1 ? 3.61f : Block == 2 ? 6.458F : Block == 3 ? 3.657F : Block == 4 ? 5.343F : 0;
            PL_z = Block == 1 ? -24.14F : Block == 2 ? -35.669F : Block == 3 ? -53.316F : Block == 4 ? -64.79F : 0;
        }
        else if (Level == 9)
        {
            PL_x = Block == 1 ? 12.879f : Block == 2 ? 12.893f : Block == 3 ? 14.554f : Block == 4 ? 10.733f : 0;
            PL_y = Block == 1 ? 3.501f : Block == 2 ? 3.501f : Block == 3 ? 4.979f : Block == 4 ? 7.856f : 0;
            PL_z = Block == 1 ? -24.05f : Block == 2 ? -33.233f : Block == 3 ? -44.489f : Block == 4 ? -62.072F : 0;
        }
        else if (Level == 10)
        {
            PL_x = Block == 1 ? 12.589f : Block == 2 ? 12.987f : Block == 3 ? 14.664f : Block == 4 ? 12.506f : Block == 5 ? 10.782f : 0;
            PL_y = Block == 1 ? 3.503f : Block == 2 ? 3.59f : Block == 3 ? 5.931f : Block == 4 ? 8.8f : Block == 5 ? 10.545f : 0;
            PL_z = Block == 1 ? -24.139f : Block == 2 ? -38.704f : Block == 3 ? -50.251f : Block == 4 ? -67.771f : Block == 5 ? -79.202f : 0;
        }
        if (route == 0)
        {
            EndOfRail = 0;
        }
        if (route == 0 && !OnRail)
        {
            RouteValueSetter();
        }
        switch (Level)
        {
            case 1 when collecteditems > 0 && Block == 2 && OnRail:
                rb.AddForce(Vector3.down * GravityMultiplier, ForceMode.Acceleration);
                break;
            case 2 when collecteditems > 0 && Block == 1 && OnRail:
                rb.AddForce(0.5f * GravityMultiplier * Vector3.down, ForceMode.Acceleration);
                break;
            case 6 when collecteditems > 0 && Block == 1 && OnRail:
                rb.AddForce(Vector3.down * GravityMultiplier, ForceMode.Acceleration);
                break;
            case 7:
                if (OnRail && collecteditems == 0 && (Block == 1 || Block == 3))
                {
                    rb.AddForce(Vector3.down * GravityMultiplier, ForceMode.Acceleration);
                }
                break;
            case 8:
                if (collecteditems > 0 && Block == 2 && OnRail)
                {
                    rb.AddForce(1.1f * GravityMultiplier * Vector3.down, ForceMode.Acceleration);
                }
                else if (OnRail && collecteditems == 0 && (Block == 1 || Block == 4))
                {
                    rb.AddForce(2 * GravityMultiplier * Vector3.down, ForceMode.Acceleration);
                }
                break;
            case 9:
                if (collecteditems > 0 && Block == 4 && OnRail)
                {
                    rb.AddForce(Vector3.down * GravityMultiplier, ForceMode.Acceleration);
                }
                else if (OnRail && collecteditems == 0 && Block == 3)
                {
                    rb.AddForce(Vector3.down * GravityMultiplier, ForceMode.Acceleration);
                }
                break;
            case 10:
                if (collecteditems > 0 && Block == 5 && OnRail)
                {
                    rb.AddForce(1.5f * GravityMultiplier * Vector3.down, ForceMode.Acceleration);
                }
                else if (OnRail && collecteditems == 0 && (Block == 2 || Block == 3))
                {
                    rb.AddForce(Vector3.down * GravityMultiplier, ForceMode.Acceleration);
                }
                break;
            default:
                break;
        }
        if (!OnRail)
        {
            rb.AddForce(1f * GravityMultiplier * Vector3.down, ForceMode.Acceleration);
            speed = 5;
        }
        else
        {
            speed = 4;
        }
        isGround = !OnRail;
        if (OnRail && collecteditems > 0) { player.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f); }
        motion = new Vector3(OnRail == false ? -floatJoy.Horizontal : 0, 0f, -floatJoy.Vertical);
        if (OnRail && c == 0)
        {
            player.transform.SetPositionAndRotation(new Vector3(PL_x, PL_y, PL_z),
                Quaternion.Euler(0.0f, 180.0f, 0.0f)); c = 1;
        }
        if (motion != Vector3.zero && !OnRail)
        {
            Quaternion toRotation = Quaternion.LookRotation(motion, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        rb.velocity = motion * speed;
    }

    private void RouteValueSetter()
    {
        if (Level == 1 || Level == 3 || Level == 4)
        {
            route = Block == 0 ? 19 : Block == 1 ? 60 : 0;
            Block = Block == 0 ? 1 : Block == 1 ? 2 : 3;
        }
        else if (Level == 2 || Level == 5)
        {
            route = Block == 0 ? 60 : Block == 1 ? 19 : 0;
            Block = Block == 0 ? 1 : Block == 1 ? 2 : 3;
        }
        else if (Level == 6 || Level == 7)
        {
            route = Block == 0 ? 60 : Block == 1 ? 19 : Block == 2 ? 60 : 0;
            Block = Block == 0 ? 1 : Block == 1 ? 2 : Block == 2 ? 3 : 4;
        }
        else if (Level == 8)
        {
            route = Block == 0 ? 32 : Block == 1 ? 60 : Block == 2 ? 19 : Block == 3 ? 60 : 0;
            Block = Block == 0 ? 1 : Block == 1 ? 2 : Block == 2 ? 3 : Block == 3 ? 4 : 5;
        }
        else if (Level == 9)
        {
            route = Block == 0 ? 19 : Block == 1 ? 19 : Block == 2 ? 60 : Block == 3 ? 60 : 0;
            Block = Block == 0 ? 1 : Block == 1 ? 2 : Block == 2 ? 3 : Block == 3 ? 4 : 5;
        }
        else if (Level == 10)
        {
            route = Block == 0 ? 43 : Block == 1 ? 32 : Block == 2 ? 60 : Block == 3 ? 19 : Block == 4 ? 60 : 0;
            Block = Block == 0 ? 1 : Block == 1 ? 2 : Block == 2 ? 3 : Block == 3 ? 4 : Block == 4 ? 5 : 6;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Red") && collecteditems < 100)
        {
            other.gameObject.SetActive(false);
            collecteditems++; collecteditems2++;
            if (collecteditems > 0)
            {
                RedBlock[collecteditems - 1].SetActive(true);
                //Vector3 OrignalPos = child.transform.position;
                //visual = Instantiate(cube, buggy.position, buggy.rotation);
                //visual.transform.parent = child.transform;
                //visual.transform.position = OrignalPos;
                rails.Add(visual);
            }
        }
        if (collecteditems2 == 15) 
        { 
            foreach (GameObject r in red)
            {
                r.SetActive(true); collecteditems2 = 0;
            } 
        }
        if (collecteditems > 0 && zero_ && other.CompareTag("Rail"))
        {
            blocker.transform.GetChild(0).gameObject.SetActive(false);
        }
        if (collecteditems > 0 && other.CompareTag("Rail"))
        {
            OnRail = true;
            other.transform.GetChild(0).gameObject.SetActive(false);
        }
        if (collecteditems > 0 && other.CompareTag("Route") && count == 1)
        {
            Destroy(other.gameObject);
            route--;
            visual = Instantiate(red2, other.gameObject.transform.position, other.gameObject.transform.rotation);
            count = 0;
            //Destroy(rails[collecteditems - 1]);
            RedBlock[collecteditems - 1].SetActive(false);
            rails.RemoveAt(rails.Count - 1);
            collecteditems--;
            if (collecteditems == 0 && route > 0)
            {
                visual.transform.GetChild(0).gameObject.SetActive(true);
                blocker = visual;
                zero_ = true;
            }
        }
        if (other.CompareTag("Rail") && route > 0)
        {
            EndOfRail = 1;
        }
        count = 1;
        if (other.CompareTag("L1Block"))
        {
            UIManager.Instance.LevelFailedActivate();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Level == 7 && other.gameObject.CompareTag("RedLift") && other.transform.position.y < 8.741f)
        {
            other.transform.position += 0.6f * Time.deltaTime * other.transform.up;
        }
        else if (Level == 8 && other.gameObject.CompareTag("RedLift") && other.transform.position.y < 6.019f)
        {
            other.transform.position += 0.6f * Time.deltaTime * other.transform.up;
        }
        else if (Level == 9 && other.gameObject.CompareTag("RedLift") && other.transform.position.y < 5.656f)
        {
            other.transform.position += 0.6f * Time.deltaTime * other.transform.up;
        }
        else if (Level == 10 && other.gameObject.CompareTag("RedLift") && other.transform.position.y < 11.232f)
        {
            other.transform.position += 0.6f * Time.deltaTime * other.transform.up;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Rail"))
        { 
            OnRail = false;
            c = 0;
        }
        if (collecteditems == 0 && other.CompareTag("Rail") && route > 0)
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
        }
        if (other.CompareTag("Rail") && EndOfRail == 0)
        {
            EOR = other.transform.gameObject;
            EndOfRail = 1;
            _ = StartCoroutine(BlockRail);
        }
    }

    private IEnumerator BlockRail
    {
        get
        {
            yield return new WaitForSeconds(1.5f);
            EOR.transform.GetChild(3).gameObject.SetActive(true);
            if (Level == 1 && Block == 3)
            {
                UIManager.Instance.WinnigPanalActivate();
            }
            else if (Level == 2 && Block == 3)
            {
                UIManager.Instance.WinnigPanalActivate();
            }
            else if (Level == 3 && Block == 3)
            {
                UIManager.Instance.WinnigPanalActivate();
            }
            else if (Level == 4 && Block == 3)
            {
                UIManager.Instance.WinnigPanalActivate();
            }
            else if (Level == 5 && Block == 3)
            {
                UIManager.Instance.WinnigPanalActivate();
            }
            else if (Level == 6 && Block == 4)
            {
                UIManager.Instance.WinnigPanalActivate();
            }
            else if (Level == 7 && Block == 4)
            {
                UIManager.Instance.WinnigPanalActivate();
            }
            else if (Level == 8 && Block == 5)
            {
                UIManager.Instance.WinnigPanalActivate();
            }
            else if (Level == 9 && Block == 5)
            {
                UIManager.Instance.WinnigPanalActivate();
            }
            else if (Level == 10 && Block == 6)
            {
                //UIManager.Instance.WinnigPanalActivate();
            }
        }
    }

    private void FixedUpdate()
    {
        isGround = Physics.CheckSphere(groundcheck.position, groundistance, groundMask);
        if (isGround) 
        { 
            rb.velocity = motion * speed;
        }
        else if (!isGround) 
        {
            buggy.SetParent(player);
        }
    }
}