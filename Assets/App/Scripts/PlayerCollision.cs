using System.Collections;
using System.Collections.Generic;
using App.Scripts.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Entity _entity;
    private World _world;
    private DamageComponent _damageComponent;
    
    void Awake()
    {
        _world = World.Default;
        _entity = GetComponent<EntityProvider>().Entity;
        _damageComponent = _entity.GetComponent<DamageComponent>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("12312321321312312");
        var enemyEntityProvider = collision.GetComponent<EntityProvider>();
        if (enemyEntityProvider != null)
        {
            var enemyEntity = enemyEntityProvider.Entity;
            if (enemyEntity.Has<EnemyComponent>() && enemyEntity.Has<HealthComponent>())
            {
                ref var enemyHealth = ref enemyEntity.GetComponent<HealthComponent>();
                enemyHealth.currentHealth -= _damageComponent.Damage;
                Debug.Log(enemyHealth.currentHealth + "/" + enemyHealth.maxHealth);
            }
        }
    }
}
