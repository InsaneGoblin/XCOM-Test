using UnityEngine;

public class Unit : MonoBehaviour
{
    public Vector3 targetPosition;

    [SerializeField] private Animator unitAnimator;
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float rotateSpeed = 4f;
    [SerializeField] private float stoppingDistance = .1f;

    public float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }

    public float StoppingDistance
    {
        get => stoppingDistance;
        set => stoppingDistance = value;
    }

    private void Awake()
    {
        targetPosition = transform.position;
    }

    private void Start()
    {
        GridPosition gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.SetUnitAtGridPosition(gridPosition, this);
    }
    private void Update()
    {

        if (Vector3.Distance(transform.position, targetPosition) > StoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += MoveSpeed * Time.deltaTime * moveDirection;
            unitAnimator.SetBool("IsWalking", true);

            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed) ;
        }
        else
        {
            unitAnimator.SetBool("IsWalking", false);
        }
        
    }

    public void Move(Vector3 targetPosition)
    {
        //Debug.Log("Going to " + targetPosition.ToString());
        this.targetPosition = MouseWorld.GetPosition();
    }
    

}
