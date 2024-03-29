﻿

namespace FSM
{
    public interface IFsmState<TStateType>
    {
        public TStateType StateType { get; }
        public IFsmController<TStateType> Controller { get; set; }
        public bool Updatable { get; }
        public void OnInit();
        public void OnEnter(System.Object data = null);
        public void OnExit();
        public void OnUpdate(float deltaTime);
    }

    public abstract class FsmStateBase<TStateType> : IFsmState<TStateType>
    {
        public abstract TStateType StateType { get; }
        public IFsmController<TStateType> Controller{ get; set; }
        
        public virtual bool Updatable => false;

        
        public virtual void OnInit() { }
        public virtual void OnEnter(System.Object data = null) { }
        public virtual void OnExit() { }
        public virtual void OnUpdate(float deltaTime) { }

    }
}