using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private AIMovement _aiMovement;
    private PlayerDetector _playerDetector;
    private AIShooting _aiShooting;
    void Start()
    {
        _aiMovement = GetComponent<AIMovement>();
        _playerDetector = GetComponent<PlayerDetector>();
        _aiShooting = GetComponent<AIShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerDetector.IsPlayerSeen())
        {
            _aiShooting.ShootingUpdate();
        }
        else
        {
            _aiMovement.MovementUpdate();
        }

    }
}
