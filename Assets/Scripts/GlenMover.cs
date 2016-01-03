using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(GlenBehaviour))]
public class GlenMover : MonoBehaviour
{
    public Animator anim;
    //public Rigidbody rbody;
    private GlenBehaviour glen;
    private float leftRight;
    private float forwardBack;
    private bool die;
    private bool run;
    private Vector3 m_Move;
    private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        //rbody = GetComponent<Rigidbody>();
        glen = GetComponent<GlenBehaviour>();
    }

    private void Update()
    {
        run = Input.GetKey(KeyCode.LeftShift);
        if(!run)
        {
            Input.GetKey(KeyCode.Joystick1Button0);
        }
        if (!m_Jump)
        {
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");
        bool crouch = Input.GetKey(KeyCode.C);
        m_Move = v * Vector3.forward + h * Vector3.right;
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            anim.SetBool("die", die);
            anim.Play("dying", -1, 0f);
        }
        forwardBack = Input.GetAxis("Vertical");
        leftRight = Input.GetAxis("Horizontal");

        

        anim.SetFloat("forwardBack", forwardBack);
        anim.SetFloat("leftRight", leftRight);
        anim.SetBool("run", run);

        m_Move = v * Vector3.forward + h * Vector3.right;
        if (run) m_Move *= 0.5f;
        glen.Move(m_Move, false, false);
        

        float moveX = leftRight * 20f * Time.deltaTime;
        float moveZ = forwardBack * 50f * Time.deltaTime;

        float turnAmount = Mathf.Atan2(m_Move.x, m_Move.z);
        anim.SetFloat("leftRight", turnAmount, 0.1f, Time.deltaTime);
        glen.Move(m_Move, crouch, m_Jump);
        m_Jump = false;
        //rbody.velocity = new Vector3(moveX, 0f, moveZ);
    }
}
