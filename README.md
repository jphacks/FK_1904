# ばとるうぇーぶ

[![ばとるうぇーぶ](image.png)](https://www.youtube.com/watch?v=G5rULR53uMk)

## 製品概要
### コミュニケーション ×  Tech

### 背景
現在、スマホを中心とした生活が当たり前になってきている。多くの店舗ではスマホ決済が導入され支払いが手軽になったり、専用アプリを入れることで、お得なクーポンを取得できるようになるなど、スマホが欠かせない時代になった。
しかし、スマホで便利な世の中になると同時に、人とコミュニケーションを取る機会も少なくなったといえるのではないだろうか？
道に迷えば地図アプリを開き、旅行をしたときには何がおすすめかをスマホで調べ、一人のときは、アプリで音楽を聴いたり、漫画を読んだり、動画を見るなど一人でも時間をつぶせるようになった。このようにスマホが普及する前と比べて一人の時間が増え、人と接する時間が少なくなった。その結果、他人はもちろん家族間でのコミュニケーションも以前より少なくなっている。このような理由もあり、スマホの扱いに不慣れで、家族と遠く離れて暮らす高齢者は、以前よりも家族と直接コミュニケーションを取ることが難しい。<br>
そこで、遠く離れて暮らす高齢者とその家族を対象に「遊び」を介してコミュニケーションを取ろうと考えた。「遊び」は基本的に二人以上でやるため、コミュニケーションが必須である。また遊んでいると思わぬハプニングがあった場合や、気持ちが高ぶった場合などに自然と声を出すことがある。そのため、常に会話をしながら遊ぶため、円滑なコミュニケーションを取ることができ、スマホ普及によるコミュニケーション不足をなくすことが出来る。

### 製品説明
「遊び」はコミュニケーションが必須である。また、スマホ操作に不慣れな高齢者でも簡単に操作できるものである必要がある。そこで、IoTデバイスを用いることで、直感的にアプリを操作でき、またアプリとして開発することで遠く離れた家族とも「遊び」を介しながらコミュニケーションを取ることが可能である。


### 特長

#### 1. 普段は遠く離れて暮らす家族と、「遊び」を介しながら会話ができるため、隣にいるような感覚で楽しむことができる。

#### 2. スマホの扱いに不慣れな人でも直感的に操作可能なIoTデバイスを使用している。そのため、「スマホ操作は難しい」という認識を変えることができ、スマホに対するハードルを下げることができる。



### 解決出来ること
* 遊びを通して遠く離れて暮らす家族間でも楽しみながら遊べるため、スマホ普及による家族間のコミュニケーション不足の解消



### 今後の展望
* AR技術との組み合わせ
* オリジナルキャラクタの作成 
* 家族全員でも対戦可能にすること、また、そのためのルール設定:


## 開発内容・開発技術
### 活用した技術
#### API・データ
* infineonの音圧計とXMCボード

#### フレームワーク・ライブラリ・モジュール
* Unity(Photon, Vuforia) 
* Raspberry Pi

#### デバイス
* iOS

### 独自開発技術（Hack Dayで開発したもの）
#### 2日間に開発した独自の機能・技術
* serialポートを用いたセンサー情報取得と他デバイスへの送信<br>
　infineon microphoneからの取得をXMCボードによってserialポートへ出力。その出力をRaspberry Piで取得し、IFTTT, IntegromatにPOST送信を可能にした。<br>
　※従来技術はserialポートからの取得、描画までであった
  commit 17245be6117899276485972265320a862da41917
* Unityによるモーション作成<br>
　本プロダクトで用いるモーションがかなり特殊な姿勢を含むものであったであったため、配布asset等を用いるのではなく自作した。
