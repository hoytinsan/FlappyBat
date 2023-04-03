using UnityEngine;
using System.Collections;

public class Bat : Explosive
{
    public Animator animator;
    private float _acceleration = -0f;
    private float _gravity = 0f;
    private Vector3 _initialLocalPosition;
    private bool _hasCollided;

    private Rigidbody2D _rigidbody2D;
    private RectTransform _rectTransform;

    public GameObject hitTextPS;

    [SerializeField]
    private AudioSource _audioSource;

    #region Singleton Initialize

    private static Bat _current;
    public static Bat Current
    {
        get { return _current ?? (_current = (Bat)FindObjectOfType(typeof(Bat))); }
    }

    #endregion

    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _initialLocalPosition = _rectTransform.anchoredPosition;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void PLayAudio()
    {
        if (_audioSource != null) { _audioSource.Play(); }
    }

    public void InitializeFirstPass()
    {
        _rectTransform.anchoredPosition = _initialLocalPosition;
        _rigidbody2D.angularVelocity = 0;
        _rigidbody2D.MoveRotation(new Quaternion(0, 0, 0, 0));
        _gravity = 0f;
        hitTextPS.SetActive(false);
        hitTextPS.transform.localPosition = Vector3.zero;
        ExplodeAndAppear();
    }

    public void Initialize()
    {
        ExplotionPS.transform.parent = transform;
        ExplotionPS.transform.localPosition = Vector3.zero;
        _gravity = -17f;
        _hasCollided = false;
    }

    public void Fly()
    {
        animator.SetTrigger("Fly");
        _acceleration = 90;
    }

    void FixedUpdate()
    {
        if (!_hasCollided)
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + _gravity + _acceleration);

        if (_acceleration > 0)
        {
            _acceleration -= 15f;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (Game.Current.IsGameOn)
        {
            if (other.tag.Equals("Floor"))
            {
                Collide();
                _rigidbody2D.velocity = new Vector2(-2, 2);
            }
            else if (other.tag.Equals("TopObstacle") || other.tag.Equals("BottomObstacle"))
            {
                Collide();
                _rigidbody2D.velocity = new Vector2(-2, -2f);
                StartCoroutine("Rotate");
            }

        }
    }

    void OnBecameInvisible()
    {
        StopAllCoroutines();
        Disappear();
        Game.Current.End();
    }

    public void Collide()
    {
        if (!_hasCollided)
        {
            _hasCollided = true;
            hitTextPS.transform.position = transform.position;
            hitTextPS.SetActive(true);
        }
    }

    public IEnumerator Rotate()
    {
        yield return new WaitForSeconds(0.2f);
        _rigidbody2D.angularVelocity = 20;

        yield return new WaitForSeconds(0.6f);
    }


}
