using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Echoes.Entities
{
    public class MonsterAI : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField] private string monsterName;
        [SerializeField] private float moveSpeed;
        [SerializeField] private Transform[] pointTransforms;

        [Header("Eater")] 
        [SerializeField] private List<SurvivorAI> survivors;
        
        private void Start()
        {
            gameObject.name = monsterName;
            transform.position = pointTransforms[0].position;
        }
        
        public IEnumerator MoveMonsterRoutine()
        {
            var targetPos = pointTransforms[1].position;
            var survivor = survivors[Random.Range(0,  survivors.Count)];
            var survivorPos = new Vector2(survivor.transform.position.x, transform.position.y);
            
            while (Vector2.Distance(transform.position, pointTransforms[1].position) > 0.1f)
            {
                var t = moveSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, targetPos, t);
                if (Vector2.Distance(transform.position, survivorPos) <= 0.1f)
                {
                    survivor.gameObject.SetActive(false);
                    survivors.Remove(survivor);
                }
                yield return null;
            }
            
            transform.position = pointTransforms[0].position;
        }
        
        
    }
}
