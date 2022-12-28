using System.Collections.Generic;
using Unity.VisualScripting;

namespace FSM
{
    public interface IFsmController<T>
    {
        public IFsmState<T> GetCurrentState();
        public void InitState();
        public IFsmState<T> GetState(T stateType);
        public bool SwitchState(T stateType, System.Object data = null);
        public void UpdateState(float deltaTime);
    }
    
    public class FsmControllerBase<T> : IFsmController<T>
    {
        protected IFsmState<T> LastState = null;
        protected IFsmState<T> CurrentState = null;
        protected IFsmState<T> DefaultState = null;

        protected Dictionary<T, IFsmState<T>> AllStates = null;

        public FsmControllerBase()
        {
            AllStates = new Dictionary<T, IFsmState<T>>(5);
        }

        public IFsmState<T> GetCurrentState()
        {
            return CurrentState;
        }

        /// <summary>
        /// 初始化state的地方
        /// </summary>
        public virtual void InitState()
        {
            
        }

        public bool AddState(IFsmState<T> state, bool isDefault = false)
        {
            if (state == null)
                return false;
            if (!AllStates.TryGetValue(state.StateType, out IFsmState<T> fsmState))
            {
                AllStates[state.StateType] = state;
                state.Controller = this;
                state.OnInit();

                if (isDefault)
                    DefaultState = state;
                return true;
            }
            else
            {
                GameDebug.LogError("Don't duplicate Add this StateType: " + state.StateType);
                return false;
            }
        }

        public bool SwitchState(T stateType, System.Object data = null)
        {
            if (AllStates.TryGetValue(stateType, out IFsmState<T> fsmState))
            {
                return InternalEnter(fsmState, data);
            }
            GameDebug.LogError("SwitchState not found: " + stateType);
            return false;
        }

        private bool InternalEnter(IFsmState<T> fsmState, System.Object data = null)
        {
            if (CurrentState == null || CurrentState.StateType.Equals(fsmState.StateType))
                return false;

            if (CurrentState != null)
            {
                LastState = CurrentState;
                CurrentState.OnExit();
            }

            CurrentState = fsmState;
            CurrentState.OnEnter(data);
            return true;
        }

        public IFsmState<T> GetState(T stateType)
        {
            if (AllStates.TryGetValue(stateType, out IFsmState<T> fsmState))
            {
                return fsmState;
            }
            return null;
        }

        public void UpdateState(float deltaTime)
        {
            if (CurrentState != null && CurrentState.Updatable)
            {
                CurrentState.OnUpdate(deltaTime);
            }
        }


    }
}