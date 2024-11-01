using System;
using System.Collections.Generic;
using App.Scripts.Infrastructure.GameStateMachines.States;
using Zenject;

namespace App.Scripts.Infrastructure.GameStateMachines
{
    public class GameStateMachine: IGameStateMachine, IInitializable
    {
        private readonly IGameStateFactory _gameStateFactory;
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(IGameStateFactory gameStateFactory)
        {
            _gameStateFactory = gameStateFactory;
            _states = new Dictionary<Type, IExitableState>();
        }
        
        public void Initialize()
        {
            Enter<BootstrapState>();
        }

        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {   
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }
        
        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            var stateType = typeof(TState);

            if (_states.TryGetValue(stateType, out IExitableState state))
            {
                _activeState = state;
            }
            else
            {
                _activeState = _gameStateFactory.Create<TState>();
                _states.Add(stateType, _activeState);
            }
            
            return _activeState as TState;
        }
    }
}