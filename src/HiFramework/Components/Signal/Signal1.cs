﻿/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;

namespace HiFramework
{
    public class Signal<T>
    {
        private Action<T> _action;

        public void AddListener(Action<T> action)
        {
            _action += action;
        }

        public void RemoveListener(Action<T> action)
        {
            _action -= action;
        }

        public void Fire(T t)
        {
            AssertThat.IsNotNull(_action, "Action is null, add listener first");
            _action(t);
        }
    }
}
