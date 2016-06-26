using System.Collections.Generic;
using System.Linq;
using UnityEngine;

    public class SimpleStateMachine<T> : BaseUI
    {
        T m_currentState;
        protected float stateStartTime;

        public float stateTime
        {
            get
            {
                return Time.time - stateStartTime;
            }
        }

        public T currentState
        {
            get
            {
                return m_currentState;
            }
            set
            {
                ExitState(m_currentState);

                m_currentState = value;
                stateStartTime = Time.time;
                EnterState(m_currentState);
            }
        }

        protected virtual void EnterState(T state)
        {
        }

        protected virtual void ExitState(T state)
        {
        }

        protected virtual void UpdateState(T state)
        {
        }

        public void Update()
        {
            UpdateState(m_currentState);
        }
    }

    public class OriginalStateMachine<T> : MonoBehaviour
    {
        T m_currentState;
        protected float stateStartTime;

        public float stateTime
        {
            get
            {
                return Time.time - stateStartTime;
            }
        }

        public T currentState
        {
            get
            {
                return m_currentState;
            }
            set
            {
                ExitState(m_currentState);

                m_currentState = value;
                stateStartTime = Time.time;
                EnterState(m_currentState);
            }
        }

        protected virtual void EnterState(T state)
        {
        }

        protected virtual void ExitState(T state)
        {
        }

        protected virtual void UpdateState(T state)
        {
        }

        public void Update()
        {
            UpdateState(m_currentState);
        }
    }
    public class Test : SimpleStateMachine<Test.TestState>
    {
        public enum TestState
        {
            Spawn,
            Idle,
            Run,
        }

        void Awake()
        {
            currentState = TestState.Spawn;
        }

        protected override void EnterState(TestState state)
        {
            switch (state)
            {
                case TestState.Idle:
                    GetComponent<Rigidbody>().velocity = Vector3.zero;
                    break;
                case TestState.Run:
                    GetComponent<Rigidbody>().velocity = new Vector3(10, 0, 0);
                    break;
            }
        }


        protected override void ExitState(TestState state)
        {
            switch (state)
            {
                case TestState.Idle:

                    break;
            }
        }


        protected override void UpdateState(TestState state)
        {
            switch (state)
            {
                case TestState.Run:
                    GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + new Vector3(10, 0, 0));
                    break;
            }
        }
    }
