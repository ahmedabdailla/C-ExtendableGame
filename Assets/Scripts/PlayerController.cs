using System;
using Task.Player;
using States;
using States.Movements;
using Task.Player.States.Air;
using UnityEditor.VersionControl;
using UnityEngine.Assertions.Must;

namespace Task.Player.Controller
{ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{    
    private Use Use = new Use();
    private IState _state;
    private Player _player;
    public global::States.States States = new global::States.States();
    
    private void Start()
    {
        _player = this.gameObject.GetComponent<Player>();
        _state = States.MovingState;
        _state.StartState(_player);
        _player.ChangeState(_state);
    }

    public void ChangeState(IState NewState)
    {
        if(NewState.Doable()){
            _state.EndState();
            _state = NewState;
            _state.StartState(_player);
            _player.ChangeState(NewState);
        }
    }

    private void Update()
    {
        Use.HandleInput();
        _state.HandleInput();
    }

    private void FixedUpdate()
    {
        _state.HoldState();
    }

    private void OnTriggerEnter(Collider other)
    {
        Use.Trigger(true, other);
        _state.Trigger(true, other);
    } 
    
    private void OnTriggerExit(Collider other)
    {
        Use.Trigger(false, other);
        _state.Trigger(true, other);

    } 
    
} }
