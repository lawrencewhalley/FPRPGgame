using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSkinnedMeshes : MonoBehaviour
{

    [SerializeField] private Mesh skinnedMesheRendererPrefab;
    [SerializeField] private Mesh meshtoChangeTo;
    void Start()
    {
        skinnedMesheRendererPrefab = meshtoChangeTo;
    }

}
