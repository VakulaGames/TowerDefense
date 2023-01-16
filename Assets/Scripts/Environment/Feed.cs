using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Feed : MonoBehaviour
{
    [SerializeField] private Image _bar;
    [SerializeField] private Transform _feedTransform;
    [SerializeField] private float _damageInterval;
    [SerializeField] private float _damage;
    [SerializeField] private TMP_Text _hpText;

    private float _hp = 100;
    private Coroutine _takeDamage;
    private WaitForSeconds _waitTime;
    private List<Enemy> _enemyList;

    private void OnEnable()
    {
        Events.OnEnemyDeadEvent += CheckDeadEnemy;
    }

    private void OnDisable()
    {
        Events.OnEnemyDeadEvent -= CheckDeadEnemy;
        if (_takeDamage != null) StopCoroutine(_takeDamage);
    }

    private void Start()
    {
        _waitTime = new WaitForSeconds(_damageInterval);
        _enemyList = new List<Enemy>();
        _hpText.text = _hp.ToString();
        _bar.fillAmount = 1;
    }

    public void Dead()
    {
        Debug.Log("Все съели");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.StarttEating();
            _enemyList.Add(enemy);

            if (_takeDamage == null) 
                _takeDamage = StartCoroutine(TakeDamage());
        }
    }

    private IEnumerator TakeDamage()
    {
        while (_enemyList.Count > 0)
        {
            _hp -= _damage;
            _hpText.text = _hp.ToString();
            float valuePersent = _hp / 100;
            _bar.fillAmount = valuePersent;

            _feedTransform.DOScale(valuePersent, _damageInterval);

            if (_hp <= 0) Dead();

            yield return _waitTime;
        }
    }

    private void CheckDeadEnemy(Enemy enemy)
    {
        if (_enemyList.Contains(enemy))
        {
            _enemyList.Remove(enemy);
        }
    }
}
