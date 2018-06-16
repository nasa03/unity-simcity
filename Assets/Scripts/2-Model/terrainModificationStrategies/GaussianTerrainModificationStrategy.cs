﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace model.terrain.terrainModificationStrategy
{
    public class GaussianTerrainModificationStrategy : TerrainModificationStrategy
    {
        

        public GaussianTerrainModificationStrategy(ElevationChange raiseOrLower) : base(raiseOrLower)
        {
        }
        
        private float EvaluateGaussian(int[] center, int[] position, float σx = 1, float σy = 1, float A = 1)
        {
            //Implementação BEEEM mastigada do gaussiano, focada em clareza e não velocidade
            float dX = Mathf.Pow(position[0] - center[0], 2); //o (x-x0)^2 da equação
            float dY = Mathf.Pow(position[1] - center[1], 2); //o (y-y0)^2 da equação

            float XdividedBySigma = dX / (2 * Mathf.Pow(σx, 2));
            float YdividedBySigma = dY / (2 * Mathf.Pow(σy, 2));

            float XPlusY = -1 * (XdividedBySigma + YdividedBySigma);

            float H = A * Mathf.Exp(XPlusY);

            return H;
        }
//        https://en.wikipedia.org/wiki/Gaussian_function
//        Olhar a sessão de gaussiano 2d
        public override void Execute(MyTerrain terrain, float intensity, Vector3 pointInWC)
        {
            int[] pointInImageCoordinate = WorldCoordinateToImageCoordinate(terrain, pointInWC);
            //pointInImageCoordinate é o centro da função gaussiana
            float[,] gaussianMask = new float[terrain.Heightmap.width, terrain.Heightmap.height];//Onde vou guardar os valores do gaussiano. 
            //Esses valores serão somados aos valores da imagem
            for (int i = 0, z = 0; z <= terrain.Heightmap.height; z++)
            {
                for (int x = 0; x <= terrain.Heightmap.width; x++, i++)
                {

                }
            }
            

        }
    }
}