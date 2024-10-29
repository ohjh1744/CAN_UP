using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResetObject
{
        // 스테이지 번호를 나타내는 속성
        int StageNum { get; }

        // 오브젝트를 리셋하는 메서드
        void Reset();
}