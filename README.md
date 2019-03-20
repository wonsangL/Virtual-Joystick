# Virtual Joystick

모바일에서 사용가능한 가상 조이스틱

## 사용 방법

1. 프로젝트 다운로드
2. Build 폴더에 있는 unityPackage를 원하는 unity project에 import
<p align="center">
   <img width="500" src="https://i.imgur.com/cyFNm8P.png">
</p>

3. Canvas에 JoystickBackground Prefab 추가
4. Joystick Object로부터 Vector값 읽어오기
```csharp
//움직이고 싶은 Object 스크립트

Joystick joystick;

private void Start(){
    joystick = FindObjectOfType<Joystick>();
}

// 생략
    
    joystick = joystick.GetInputVector(); //Vector2값을 리턴

// 생략
```

## [샘플 영상](http://www.youtube.com/watch?v=p9taRQ5LeYM)