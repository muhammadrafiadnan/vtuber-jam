using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Echoes.Events;

using Random = UnityEngine.Random;

namespace Echoes.Entities
{
    public class MonsterAI : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField] private string monsterName;
        [SerializeField] private float moveSpeed;
        [SerializeField] private Transform[] pointTransforms;
        [SerializeField] private List<SurvivorAI> survivors;

        private readonly List<SurvivorAI> _tempSurvivors = new();

        private void OnEnable()
        {
            TimeEvents.OnTimerEnded += MoveMonster;
            TimeEvents.OnTimerReStarted += InitMonster;
        }
        
        private void OnDisable()
        {
            TimeEvents.OnTimerEnded -= MoveMonster;
            TimeEvents.OnTimerReStarted -= InitMonster;
        }
        
        private void Start()
        {
            InitMonster();
        }
        
        private void InitMonster()
        {
            gameObject.name = monsterName;
            transform.position = pointTransforms[0].position;
            foreach (var survivor in survivors)
            {
                survivor.gameObject.SetActive(true);
                _tempSurvivors.Add(survivor);
            }
        }
        
        private void MoveMonster() => StartCoroutine(MoveMonsterRoutine());
        
        private IEnumerator MoveMonsterRoutine()
        {
            var targetPos = pointTransforms[1].position;
            var survivor = _tempSurvivors[Random.Range(0,  _tempSurvivors.Count)];
            var survivorPos = new Vector2(survivor.transform.position.x, transform.position.y);
            
            while (Vector2.Distance(transform.position, pointTransforms[1].position) > 0.1f)
            {
                var t = moveSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, targetPos, t);
                if (Vector2.Distance(transform.position, survivorPos) <= 0.1f)
                {
                    survivor.gameObject.SetActive(false);
                    _tempSurvivors.Remove(survivor);
                }
                yield return null;
            }
            
            transform.position = pointTransforms[0].position;

            yield return new WaitForSeconds(1f);
            GameEvents.GameStartEvent();
            TimeEvents.TimerReStartedEvent();
        }
    }
}
