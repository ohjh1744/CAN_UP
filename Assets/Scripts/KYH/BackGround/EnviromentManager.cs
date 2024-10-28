using Enviroment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentManager : MonoBehaviour
{
    [Header("Directional Light(Sun) From Scene")]
    [SerializeField] private Light _mDirectionalLight;  // Directional Light

    [Header("Skybox Rotate Speed")]
    [SerializeField] private float _mSkyboxRotSpeed;    // 스카이박스 회전 속도

    [Space(30)]
    [Header("Preload Enviroment Preset")]
    [SerializeField] private EnviromentPreset[] _mEnviromentPresets;    // 스카이박스 프리셋

    private Dictionary<string, EnviromentPreset> _mPreloadEnviromentPresets = new Dictionary<string, EnviromentPreset>();
    private EnviromentPreset? mCurrentPreset = null, _mPrevPreset = null; // 현재 프리셋, 이전 프리셋

    private Material _mSkyboxMat; // 스카이박스 머티리얼
    private float _mCurrentSkyboxRot; // Store the current rotation angle
    private Coroutine _mCoBlendEnviroment; // Control blend coroutine

    private void Awake()
    {
        // 스카이박스 머티리얼 참조
        _mSkyboxMat = new Material(RenderSettings.skybox);
        RenderSettings.skybox = _mSkyboxMat;

        // 스카이박스 _Rotation 값 가져오기
        _mCurrentSkyboxRot = _mSkyboxMat.GetFloat("_Rotation");

        // 준비된 프리셋 가져오기
        foreach (EnviromentPreset preset in _mEnviromentPresets)
            _mPreloadEnviromentPresets.Add(preset.name, preset);


        // mCurrentPreset를 첫번째 스카이박스로 설정
        EnviromentPreset currentPreset = ScriptableObject.CreateInstance<EnviromentPreset>();
        currentPreset.LoadCurrentSettings();
        mCurrentPreset = currentPreset;
    }

    private void Update()
    {
        // 스카이박스 회전을 초당 _mSkyboxRotSpeed만큼 회전
        _mCurrentSkyboxRot += Time.deltaTime * _mSkyboxRotSpeed;

        // _mSkyboxRotSpeed가 360도를 초과할 경우, _mSkyboxRotSpeed를 초기화
        if (_mCurrentSkyboxRot > 360f)
            _mCurrentSkyboxRot -= 360f;

        // _Rotation값을 _mCurrentSkyboxRot로 변경
        _mSkyboxMat.SetFloat("_Rotation", _mCurrentSkyboxRot);
    }

    // EnviromentPreset 적용 시도
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

    // 스카이박스 블렌드 함수
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

    // 스카이박스 블렌드 코루틴
    private IEnumerator CoBlendEnviroment(EnviromentPreset preset, float duration)
    {
        // 현재/이전 프리셋 가져오기
        _mPrevPreset = mCurrentPreset;
        mCurrentPreset = preset;

        // 현재 설정 가져오기
        EnviromentPreset curState = ScriptableObject.CreateInstance<EnviromentPreset>();
        curState.LightningIntensityMultiplier = RenderSettings.ambientIntensity;
        curState.ReflectionsIntensityMultiplier = RenderSettings.reflectionIntensity;
        float currentBlendValue = _mSkyboxMat.GetFloat("_Blend");
        Color currentSunColor = _mDirectionalLight.color;
        float currentSunIntensity = _mDirectionalLight.intensity;
        Color currentFogColor = RenderSettings.fogColor;
        float currentFogStart = RenderSettings.fogStartDistance;
        float currentFogEnd = RenderSettings.fogEndDistance;

        // 지정한 텍스쳐를 스카이박스 머티리얼로 변경
        _mSkyboxMat.SetTexture("_FrontTex2", preset.SidedSkyboxPreset.FrontTex);
        _mSkyboxMat.SetTexture("_BackTex2", preset.SidedSkyboxPreset.BackTex);
        _mSkyboxMat.SetTexture("_LeftTex2", preset.SidedSkyboxPreset.LeftTex);
        _mSkyboxMat.SetTexture("_RightTex2", preset.SidedSkyboxPreset.RightTex);
        _mSkyboxMat.SetTexture("_UpTex2", preset.SidedSkyboxPreset.UpTex);
        _mSkyboxMat.SetTexture("_DownTex2", preset.SidedSkyboxPreset.DownTex);

        // 스카이박스 블렌드
        float process = 0f;
        while (process < 1f)
        {
            process += Time.deltaTime / duration;

            RenderSettings.ambientIntensity = Mathf.Lerp(curState.LightningIntensityMultiplier, preset.LightningIntensityMultiplier, process);
            RenderSettings.reflectionIntensity = Mathf.Lerp(curState.ReflectionsIntensityMultiplier, preset.ReflectionsIntensityMultiplier, process);

            // Fog 블렌드
            RenderSettings.fogColor = Color.Lerp(currentFogColor, preset.FogPreset.FogColor, process);
            RenderSettings.fogStartDistance = Mathf.Lerp(currentFogStart, preset.FogPreset.FogStart, process);
            RenderSettings.fogEndDistance = Mathf.Lerp(currentFogEnd, preset.FogPreset.FogEnd, process);

            // Directional Light 블렌드
            _mDirectionalLight.color = Color.Lerp(currentSunColor, preset.SunPreset.SunColor, process);
            _mDirectionalLight.intensity = Mathf.Lerp(currentSunIntensity, preset.SunPreset.SunIntensity, process);

            // 스카이박스 블렌드
            _mSkyboxMat.SetFloat("_Blend", Mathf.Lerp(currentBlendValue, 1.0f, process));

            yield return null;
        }

        // 블렌드된 텍스쳐를 기본 텍스쳐로 변경
        _mSkyboxMat.SetTexture("_FrontTex", preset.SidedSkyboxPreset.FrontTex);
        _mSkyboxMat.SetTexture("_BackTex", preset.SidedSkyboxPreset.BackTex);
        _mSkyboxMat.SetTexture("_LeftTex", preset.SidedSkyboxPreset.LeftTex);
        _mSkyboxMat.SetTexture("_RightTex", preset.SidedSkyboxPreset.RightTex);
        _mSkyboxMat.SetTexture("_UpTex", preset.SidedSkyboxPreset.UpTex);
        _mSkyboxMat.SetTexture("_DownTex", preset.SidedSkyboxPreset.DownTex);
        _mSkyboxMat.SetFloat("_Blend", 0f);
    }
}
