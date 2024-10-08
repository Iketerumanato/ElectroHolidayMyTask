# ElectroHolidayMyTask
![1_title](https://github.com/Iketerumanato/ElectroHolidayMyTask/assets/74332407/7ede7829-ff2e-4db7-bdd5-a19523806af7)

![3_seesaw](https://github.com/Iketerumanato/ElectroHolidayMyTask/assets/74332407/a480f7e4-e57b-4b3f-b3f8-b58b1a88a510)

----------------------------------------------------------------------------------------------------------------------------

<pdf資料>

[readme_EH.pdf](readme_EH.pdf)
※exeデータを起動する際はこちらを読んでください

<担当した箇所>(実際に使われなくなったものはボツと表記します)

<システム>

(サウンド)

・SE再生処理をまとめたもの

[SEManager.cs](System/SEManager.cs)

・BGM再生と切り替えの仕組み

[BGMManager.cs](System/BGMManager.cs)

(UI)

・キャラクターの会話イベントの仕組み

[TalkArea.cs](System/TalkArea.cs)

・画面のフェードイン,フェードアウトを行う仕組み

[CallFadeInOut.cs](System/CallFadeInOut.cs)

・表示されたUIを閉じるための円ゲージを増加させる仕組み

[SircleGage.cs](UI/SircleGage.cs)

・ムービーのスキップ機能

[MovieSkipGage.cs](UI/MovieSkipGage.cs)

・メニューの表示(PoseMenu.cs/UI)

[PoseMenu.cs](UI/PoseMenu.cs)

・メニューの各種ボタンの機能(ゲームに戻る、タイトルに戻る、リトライ)(/)

[PoseMenu.cs](UI/PoseMenu.cs)

・タイトル画面に戻るかの確認画面

[PoseMenu.cs](UI/PoseMenu.cs)

・チュートリアルなどのUI表示、非表示を行う仕組み

[TutorialZone.cs](UI/TutorialZone.cs)

・チュートリアルムービー再生と切り替えの仕組み

[TutorialVideo.cs](UI/TutorialVideo.cs)

・チュートリアル画像と切り替えの仕組み

[TutorialImage.cs](UI/TutorialImage.cs)

・各シーンのフェードインフェードアウトの仕組み

<システムの中で使われなくなったもの>

・ボスのフェーズ管理の仕組み ※ボツ

[BossPhaseSystem.cs](Chara/BossPhaseSystem.cs)

・ボスのフェーズ管理のためのインターフェース ※ボツ

[IBossPhase.cs](Chara/IBossPhase.cs)

・ボスのフェーズ01で行う処理 ※ボツ

[BossPhase01.cs](Chara/BossPhase01.cs)

・ボスのフェーズ02で行う処理 ※ボツ

[BossPhase02.cs](Chara/BossPhase02.cs)

・ボスのフェーズ03で行う処理 ※ボツ

[BossPhase03.cs](Chara/BossPhase03.cs)

<ギミック>

・振り子のギミック作成(unity内の機能のみで作成)

・振り子を吊るす線の描画処理

[FurikoRenderer.cs](Gimmick/FurikoRenderer.cs)

・最終ステージのレバー

[Lever.cs](Gimmick/Lever.cs)

<キャラ>

・アンドロイドの操作管理プログラム

[AndroidController.cs](Chara/AndroidController.cs)

・アンドロイドの操作(DenkiActions)作成

[PlayerMap.png](Other/PlayerMap.png)

・アンドロイドのアニメーション制御

[AndroidAnimation.png](Other/AndroidAnimation.png)

・アンドロイドのアニメーションコントローラーの作成(Android.controller)

・メニュー表示のInputActionMapの作成

[MenuMap.png](Other/MenuMap.png)

<シーン>

・タイトル画面構成

[Title.png](Other/Title.png)

・ポーズメニュー画面構成(Menu01.png/Other, Menu02.png/)

[Menu01.png](Other/Menu01.png)

[Menu02.png](Other/Menu02.png)

・チュートリアル画面構成(/Other, Tutorial02.png/Other, Tutorial03.png/Other)

[Tutorial01.png](Other/Tutorial01.png)

[Tutorial02.png](Other/Tutorial02.png)

[Tutorial02.png](Other/Tutorial03.png)

<シェーダー>

[Tenmetsu.shader](Shader/Tenmetsu.shader)

オブジェクトに付ける点滅するオブジェクトのシェーダー

<ビルドデータ>

ElectroHoliday.zip※本作品はUnityのver2021.3.23f1で制作しました

<本プロジェクトのGithubのURL>

[https://github.com/Iketerumanato/TakoashiHaisen.git](https://github.com/Nanachi9999/TakoashiHaisen.git)

----------------------------------------------------------------------------------------------------------------------------
