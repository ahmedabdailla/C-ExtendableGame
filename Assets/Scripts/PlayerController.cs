using System;
using DefaultNamespace;
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
    private CharacterController controller;
    private GameObject _useableActor;
    private IUse _use;
    private IState _state;
    private Player _player;
    private bool _interacting = false;

    public IState[] States;
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        _player = Player.Instance;
        _state = _player.GetState();
    }

    private void ChangeState(IState NewState)
    {
        _player.ChangeState(NewState);
        _state = NewState;
    }

    private void Update()
    {
        var horizontalInput = Input.GetAxis ("Horizontal");
        var verticalInput = Input.GetAxis ("Vertical");
        if (horizontalInput != 0f || verticalInput != 0f)
        {
            float[] array = {horizontalInput, verticalInput};
            _state.HoldState(array);
        }

        var jumping = Input.GetButton("Jump");    
        if (jumping)
        {
            _player.ChangeState(new Jumping());
        }
        
        var ducking = Input.GetButton("Fire3");
        if (ducking)
        {
            // _player.ChangeState(new ducking());

        }
        var charging = Input.GetButton("Fire1");
        if (charging)
        {
           // _player.ChangeState(new charging());

        }
        
        var use = Input.GetButton("Fire2");
        if (use && _interacting == false && _useableActor != null)
        {
            _interacting = true;
            _use = _useableActor.GetComponent<IUse>();
            _use.Use();
            _interacting = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Useable")
        {
            _useableActor = other.gameObject;
        }
    }
} }
