using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PLayerWalkScript : MonoBehaviour
{
    public GameObject footLeft;
    public GameObject footRight;
    public float leftDis;
    public float rightDis;
    private Rigidbody2D leftRb;
    private Rigidbody2D rightRb;
    private Vector2 leftDir;
    private Vector2 rightDir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftRb = footLeft.GetComponent<Rigidbody2D>();
        rightRb = footRight.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        leftDir = new Vector2(footLeft.transform.position.x, footLeft.transform.position.y) - new Vector2(this.transform.position.x - 0.5f, this.transform.position.y -1.5f);
        rightDir = new Vector2(footRight.transform.position.x, footRight.transform.position.y) - new Vector2(this.transform.position.x + 0.5f, this.transform.position.y - 1.5f);

        leftDis = Vector2.Distance(new Vector2(this.transform.position.x - 0.5f, this.transform.position.y -1.5f), new Vector2(footLeft.transform.position.x, footLeft.transform.position.y));
        rightDis = Vector2.Distance(new Vector2(this.transform.position.x + 0.5f, this.transform.position.y - 1.5f), new Vector2(footRight.transform.position.x, footRight.transform.position.y));

        leftRb.AddForce((leftDir * -(leftDis) * Time.deltaTime) * 100);
        rightRb.AddForce((rightDir * -(rightDis) * Time.deltaTime) * 100);
    }
}
