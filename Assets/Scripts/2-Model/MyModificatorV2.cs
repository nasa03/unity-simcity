﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace model.terrain
{
    public class Modificator
    {
        private MyTerrain terrain;
        private TerrainModificationStrategy currentStrategy;
        public float Intensity { get; private set; }
        public Modificator(MyTerrain terrain)
        {
            this.terrain = terrain;
            currentStrategy = null;
            Intensity = 0;
        }

        public void Modify(Ray ray, RaycastHit hit)
        {
            if(currentStrategy==null)
            {
                Debug.LogWarning("Current strategy está null, não fará modificação alguma!");
                return;
            }
            else
            {
                currentStrategy.Execute(terrain, Intensity, hit.point);
            }
        }

        public void SetModificationStrategy(TerrainModificationStrategy strat)
        {
            this.currentStrategy = strat;
        }

        public void IncreaseIntensity(float v)
        {
            Intensity += v;
        }

        public void ResetIntensity()
        {
            Intensity = 0;
        }
    }
}
