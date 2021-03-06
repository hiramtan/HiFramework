﻿/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework
 * Author: hiramtan@live.com
 ****************************************************************************/
using System;

namespace HiFramework.Components
{
    public class Signal<T1, T2, T3, T4>
    {
        private Action<T1, T2, T3, T4> _action;

        public void AddListener(Action<T1, T2, T3, T4> action)
        {
            _action += action;
        }

        public void RemoveListener(Action<T1, T2, T3, T4> action)
        {
            _action -= action;
        }

        public void Fire(T1 t1, T2 t2, T3 t3, T4 t4)
        {
            AssertThat.IsNotNull(_action, "Action is null, add listener first");
            _action(t1, t2, t3, t4);
        }
    }
}
