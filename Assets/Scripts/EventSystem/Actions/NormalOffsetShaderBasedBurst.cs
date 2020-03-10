using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalOffsetShaderBasedBurst : Action
{
    private float normalOffsetModifier;
    private Vector4 specialVectorModifier;

    private Material mainMaterial;

    private void Awake()
    {
        mainMaterial = GetComponent<MeshRenderer>().material;

        mainMaterial.SetVector("_SpecialVector",
            new Vector4(
            Random.Range(-30f, 30f),
            Random.Range(-30f, 30f),
            0.0f,
            0.0f)
            );
    }

    private void OnEnable()
    {
        normalOffsetModifier = 0.001f;
        specialVectorModifier = new Vector4(0, 0, 0.12f, 0);
        mainMaterial.SetFloat("_NormalOffset", 0.0f);

        mainMaterial.SetVector("_SpecialVector",
            new Vector4(
            Random.Range(-30f, 30f),
            Random.Range(-30f, 30f),
            0.0f,
            0.0f)
            );
    }

    public override void Execute()
    {
        if (!IsInvoking("AddNormalOffset"))
        {
            for (int i = 0; i < 10; i++)
            {
                Invoke("AddNormalOffset", 0.05f * i);
            }
        }
        if (!IsInvoking("AddSpecialVector"))
        {
            for (int i = 0; i < 10; i++)
            {
                Invoke("AddSpecialVector", 0.05f * i);
            }

            Invoke("ChangeSpecialVectorModifier", 0.48f);

            for (int i = 10; i < 20; i++)
            {
                Invoke("AddSpecialVector", 0.05f * i);
            }
        }
    }

    private void AddNormalOffset()
    {
        float normalOffset = mainMaterial.GetFloat("_NormalOffset");
        mainMaterial.SetFloat("_NormalOffset", normalOffset + normalOffsetModifier);
    }

    private void AddSpecialVector()
    {
        Vector4 specialVector = mainMaterial.GetVector("_SpecialVector");
        mainMaterial.SetVector("_SpecialVector", specialVector + specialVectorModifier);
    }

    private void ChangeSpecialVectorModifier()
    {
        specialVectorModifier = new Vector4(0, 0, -1.012f, 0);
    }
}
