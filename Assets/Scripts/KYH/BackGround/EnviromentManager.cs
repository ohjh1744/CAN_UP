using Enviroment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentManager : MonoBehaviour
{
    [Header("Directional Light(Sun) From Scene")]
    [SerializeField] private Light _mDirectionalLight;

    [Header("Skybox Rotate Speed")]
    [SerializeField] private float _mSkyboxRotSpeed;

    [Space(30)]
    [Header("Preload Enviroment Preset")]
    [SerializeField] private EnviromentPreset[] _mEnviromentPresets;

    private Dictionary<string, EnviromentPreset> _mPreloadEnviromentPresets = new Dictionary<string, EnviromentPreset>();
    private EnviromentPreset? mCurrentPreset = null, _mPrevPreset = null; // Current & Prev preset

    private Material _mSkyboxMat; // Scene's skybox material
    private float _mCurrentSkyboxRot; // Store the current rotation angle
    private Coroutine _mCoBlendEnviroment; // Control blend coroutine

    private void Awake()
    {
        // Instance skybox material
        _mSkyboxMat = new Material(RenderSettings.skybox);
        RenderSettings.skybox = _mSkyboxMat;

        // Get skybox rotation
        _mCurrentSkyboxRot = _mSkyboxMat.GetFloat("_Rotation");

        // Load preload presets
        foreach (EnviromentPreset preset in _mEnviromentPresets)
            _mPreloadEnviromentPresets.Add(preset.name, preset);


        // Set "mCurrentPreset" from initial scene options
        EnviromentPreset currentPreset = ScriptableObject.CreateInstance<EnviromentPreset>();
        currentPreset.LoadCurrentSettings();
        mCurrentPreset = currentPreset;
    }

    private void Update()
    {
        _mCurrentSkyboxRot += Time.deltaTime * _mSkyboxRotSpeed;

        if (_mCurrentSkyboxRot > 360f)
            _mCurrentSkyboxRot -= 360f;

        _mSkyboxMat.SetFloat("_Rotation", _mCurrentSkyboxRot);
    }

    public bool TryInvertEnviromentPreset(float duration)
    {
        if (_mPrevPreset == null || mCurrentPreset == null)
        {
            Debug.LogWarning("Not Preset Loaded!");
            return false;
        }

        BlendEnviroment(_mPrevPreset, duration);

        return true;
    }

    public void BlendEnviroment(string key, float duration)
    {
        this.BlendEnviroment(_mPreloadEnviromentPresets[key], duration);
    }

    public void BlendEnviroment(EnviromentPreset preset, float duration)
    {
        if (_mCoBlendEnviroment is not null)
            StopCoroutine(_mCoBlendEnviroment);

        _mCoBlendEnviroment = StartCoroutine(CoBlendEnviroment(preset, duration));
    }

    private IEnumerator CoBlendEnviroment(EnviromentPreset preset, float duration)
    {
        // Store Current & Prev preset
        _mPrevPreset = mCurrentPreset;
        mCurrentPreset = preset;

        // Get current option state
        EnviromentPreset curState = ScriptableObject.CreateInstance<EnviromentPreset>();
        curState.LightningIntensityMultiplier = RenderSettings.ambientIntensity;
        curState.ReflectionsIntensityMultiplier = RenderSettings.reflectionIntensity;
        float currentBlendValue = _mSkyboxMat.GetFloat("_Blend");
        Color currentSunColor = _mDirectionalLight.color;
        float currentSunIntensity = _mDirectionalLight.intensity;
        Color currentFogColor = RenderSettings.fogColor;
        float currentFogStart = RenderSettings.fogStartDistance;
        float currentFogEnd = RenderSettings.fogEndDistance;

        // Load blend target textures to skybox mat
        _mSkyboxMat.SetTexture("_FrontTex2", preset.SidedSkyboxPreset.FrontTex);
        _mSkyboxMat.SetTexture("_BackTex2", preset.SidedSkyboxPreset.BackTex);
        _mSkyboxMat.SetTexture("_LeftTex2", preset.SidedSkyboxPreset.LeftTex);
        _mSkyboxMat.SetTexture("_RightTex2", preset.SidedSkyboxPreset.RightTex);
        _mSkyboxMat.SetTexture("_UpTex2", preset.SidedSkyboxPreset.UpTex);
        _mSkyboxMat.SetTexture("_DownTex2", preset.SidedSkyboxPreset.DownTex);

        // Blend processes
        float process = 0f;
        while (process < 1f)
        {
            process += Time.deltaTime / duration;

            // Enviroment Intensity Blend
            RenderSettings.ambientIntensity = Mathf.Lerp(curState.LightningIntensityMultiplier, preset.LightningIntensityMultiplier, process);
            RenderSettings.reflectionIntensity = Mathf.Lerp(curState.ReflectionsIntensityMultiplier, preset.ReflectionsIntensityMultiplier, process);

            // Fog Blend
            RenderSettings.fogColor = Color.Lerp(currentFogColor, preset.FogPreset.FogColor, process);
            RenderSettings.fogStartDistance = Mathf.Lerp(currentFogStart, preset.FogPreset.FogStart, process);
            RenderSettings.fogEndDistance = Mathf.Lerp(currentFogEnd, preset.FogPreset.FogEnd, process);

            // Directional Light(Sun) Blend
            _mDirectionalLight.color = Color.Lerp(currentSunColor, preset.SunPreset.SunColor, process);
            _mDirectionalLight.intensity = Mathf.Lerp(currentSunIntensity, preset.SunPreset.SunIntensity, process);

            // Skybox Blend
            _mSkyboxMat.SetFloat("_Blend", Mathf.Lerp(currentBlendValue, 1.0f, process));

            yield return null;
        }

        // Load blended preset textures to base texture
        _mSkyboxMat.SetTexture("_FrontTex", preset.SidedSkyboxPreset.FrontTex);
        _mSkyboxMat.SetTexture("_BackTex", preset.SidedSkyboxPreset.BackTex);
        _mSkyboxMat.SetTexture("_LeftTex", preset.SidedSkyboxPreset.LeftTex);
        _mSkyboxMat.SetTexture("_RightTex", preset.SidedSkyboxPreset.RightTex);
        _mSkyboxMat.SetTexture("_UpTex", preset.SidedSkyboxPreset.UpTex);
        _mSkyboxMat.SetTexture("_DownTex", preset.SidedSkyboxPreset.DownTex);
        _mSkyboxMat.SetFloat("_Blend", 0f);
    }
}
