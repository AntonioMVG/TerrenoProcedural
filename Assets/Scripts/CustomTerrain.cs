using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[ExecuteInEditMode]
public class CustomTerrain : MonoBehaviour
{
    public Terrain myTerrain;
    public TerrainData myTerrainData;

    public float scaleFactor;

    public Texture2D myTexture;
    public bool inverted;

    public Material colorBlue;
    public Material colorGreen;

    private void OnEnable()
    {
        myTerrain = this.GetComponent<Terrain>();
        myTerrainData = myTerrain.terrainData;
        //myTerrainData = Terrain.activeTerrain.terrainData;
    }

    public void RandomTerrain()
    {
        // Declaramos la matris de alturas
        float[,] heights = new float[myTerrainData.heightmapResolution, myTerrainData.heightmapResolution];

        // Generamos una matriz aleatoria de alturas
        for (int i = 0; i < myTerrainData.heightmapResolution; i++)
        {
            for (int j = 0; j < myTerrainData.heightmapResolution; j++)
            {
                heights[i, j] = Random.Range(0f,1f*scaleFactor);
            }
        }

        // Asignamos esas alturas a nuestro terreno
        myTerrainData.SetHeights(0, 0, heights);
    }

    public void LoadTextureToTerrain()
    {
        // Declaramos la matriz de alturas
        float[,] heights = new float[myTerrainData.heightmapResolution, myTerrainData.heightmapResolution];

        // Generamos una matriz aleatoria de alturas
        for (int i = 0; i < myTerrainData.heightmapResolution; i++)
        {
            for (int j = 0; j < myTerrainData.heightmapResolution; j++)
            {
                // Recorrer la textura a la par y convertir cada pixel en escala de grises
                heights[i, j] = inverted ? 1 - myTexture.GetPixel(i, j).grayscale * scaleFactor : myTexture.GetPixel(i, j).grayscale * scaleFactor;
            }
        }

        // Asignamos esas alturas a nuestro terreno
        myTerrainData.SetHeights(0, 0, heights);
    }

    public void ColorTerrain()
    {
        // Declaramos la matriz de alturas
        float[,] heights = new float[myTerrainData.heightmapResolution, myTerrainData.heightmapResolution];

        // Generamos una matriz aleatoria de alturas
        for (int i = 0; i < myTerrainData.heightmapResolution; i++)
        {
            for (int j = 0; j < myTerrainData.heightmapResolution; j++)
            {
                // Recorrer la textura a la par y convertir cada pixel en escala de grises
                heights[i, j] = inverted ? 1 - myTexture.GetPixel(i, j).grayscale * scaleFactor : myTexture.GetPixel(i, j).grayscale * scaleFactor;

                if (myTexture.GetPixel(i, j).grayscale == 0)
                {
                    Debug.Log("Agua");
                    myTerrainData.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                    //myTexture.GetComponent<Renderer>().material = colorBlue;
                }
                else if (myTexture.GetPixel(i, j).grayscale >= 0.5)
                {
                    Debug.Log("Cesped");
                    myTerrainData.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                    //myTexture.GetComponent<Renderer>().material = colorGreen;
                }
            }
        }
    }

    public void ResetTerrain()
    {
        // Declaramos la matris de alturas
        float[,] heights = new float[myTerrainData.heightmapResolution, myTerrainData.heightmapResolution];

        // Generamos una matriz aleatoria de alturas
        for (int i = 0; i < myTerrainData.heightmapResolution; i++)
        {
            for (int j = 0; j < myTerrainData.heightmapResolution; j++)
            {
                heights[i, j] = Random.Range(0f, 0f);
            }
        }

        // Asignamos esas alturas a nuestro terreno
        myTerrainData.SetHeights(0, 0, heights);
    }
}
