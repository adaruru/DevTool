# EncryptTool

 [_toc_]

[工具下載EncryptTool.exe](https://github.com/adaruru/DevTool/releases/download/1.1.EncryptTool/EncryptTool.exe)

## 用途

便攜加密工具，可加密、解密: AES、DES，只能加密: MD5、SHA256，可建key、Iv

## 使用說明

### 加解密

#### 點選設定

#### 重置輸入

### 建密鑰 Key 初始向量 IV

### 建置

dotnet publish EncryptTool/EncryptTool.csproj -c Release -r win-x64 --self-contained false -p:PublishSingleFile=true -p:PublishReadyToRun=true -p:IncludeAllContentForSelfExtract=true -o bin\Release\net6.0-windows\publish\win-x64\
