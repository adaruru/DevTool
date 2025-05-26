# 2.1DbTool

 [_toc_]

[工具下載DbTool.exe](https://github.com/adaruru/DevTool/releases/download/1.1/DbTool.exe)

## 用途

僅支援 MS SQL，輸入連線字串之後可進行

1. 資料庫規格下載 Excel 檔案，可以自訂 Excel 樣式
2. 資料庫規格下載 Word 檔案
3. 資料庫規格下載 Word 檔案，一表一檔
4. Excel 匯入資料庫欄位描述、資料表描述
5. 下載 Model.cs 方便開發使用

## 使用說明

### 資料庫測試連線

所有功能都需要先測試連線之後才能順利進行

![image-20250526113906503](.attach/.readme/image-20250526113906503.png)

不確定連線字串怎麼輸入可以點選顯示範例參考，或是直接使用範例做連線修改

![image-20250526113924392](.attach/.readme/image-20250526113924392.png)

雙擊清空提示訊息

![image-20250526114041244](.attach/.readme/image-20250526114041244.png)

連線成功會在連線歷程顯示

且連線歷程切換可以載入之前的連線字串

![image-20250526114646781](.attach/.readme/image-20250526114646781.png)

進入設定可以把暫存的連線字串清除

![image-20250526114743670](.attach/.readme/image-20250526114743670.png)

### 資料庫規格下載 Excel

下載後會顯示檔案位置，並且打開下載檔案

![image-20250526114111712](.attach/.readme/image-20250526114111712.png)

![image-20250526114309824](.attach/.readme/image-20250526114309824.png)

excel 的樣式，有主題可以挑選

![image-20240629144930146](.attach/.readme/image-20240629144930146.png)

預設有5種可以選擇

![image-20240629145009978](.attach/.readme/image-20240629145009978.png)

![image-20240629145338860](.attach/.readme/image-20240629145338860.png)

套過樣式的excel

![image-20240629145904294](.attach/.readme/image-20240629145904294.png)

也可以下載檔案自訂樣式，檔案會存在CustomTheme

![image-20240629145437071](.attach/.readme/image-20240629145437071.png)

編輯好後雙擊 "自訂義Excel樣式 "，編輯好的樣式就會出現在選單供選擇

![image-20240629145808632](.attach/.readme/image-20240629145808632.png)

點選設定，檔案會依照使用者勾選的類別顯示欄位 

![image-20240629144851732](.attach/.readme/image-20240629144851732.png)



### 資料庫規格下載 Word

![image-20240629150042599](.attach/.readme/image-20240629150042599.png)

可以選擇顯示的欄位，以及要不要目錄

![image-20240629223445045](.attach/.readme/image-20240629223445045.png)

![image-20240629223548969](.attach/.readme/image-20240629223548969.png)

也可以產製表一個word檔

![image-20240629223715832](.attach/.readme/image-20240629223715832.png)

#### 要注意

1. 如果本機已經開啟描述範本檔案，會影響範本下載
2. 描述範本，輸入好後不可修改欄位名、檔案名，才能有效匯入範本

匯入資料庫欄位描述、表描述，必須先下載匯入描述範本

![image-20240524114828866](.attach/.readme/image-20240524114828866-171967194290215.png)

範本內容會只有表名稱、描述名稱，以及欄位名稱、描述名稱的對應excel

![image-20240524115046551](.attach/.readme/image-20240524115046551-171967194290213.png)

![image-20240524115056591](.attach/.readme/image-20240524115056591-171967194290214.png)

要注意如果本機已經開啟描述範本檔案，會影響範本下載

excel輸入好後點選匯入描述，注意檔案不可以改名

![image-20240524120626394](.attach/.readme/image-20240524120626394-171967194290212.png)

如有成功會提示匯入完成

![image-20240524120906722](.attach/.readme/image-20240524120906722-171967194290216.png)

可以再次下載規格或登入資料庫查看是否匯入正確

### Model產檔

點選所有model產檔，會存於工具位置Model資料夾

![image-20240524121023332](.attach/.readme/image-20240524121023332-171967194290319.png)

將會產置所有Table對應的物件.cs檔

![image-20240524121147570](.attach/.readme/image-20240524121147570-171967194290217.png)



如勾選Display、Required 等 annotation

summary 來自欄描述、表描述
display來自表描述、資料長度
key 的顯示會受限於 欄位名稱 是否是TableName+id 或者是 tableName去掉s+id 

![image-20240524121529666](.attach/.readme/image-20240524121529666-171967194290218.png)

![image-20240524121325718](.attach/.readme/image-20240524121325718-171967194290320.png)

### 設定

使用者設定在小工具裡的勾選值或輸入的連線字串

在關掉後再打開，都會保留所有填寫的設定

![image-20240629224032751](.attach/.readme/image-20240629224032751.png)

如果想回到初始設定可以點選重置設定

就會回到預設值，僅勾選大部分情況會需要的欄位顯示

![image-20250526114418994](.attach/.readme/image-20250526114418994.png)