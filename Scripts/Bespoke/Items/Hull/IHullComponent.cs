using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Bespoke.Items.Hull
{
    public interface IHullComponent
    {
        void Initialize();
        void UpdateComponent();
    }
}
