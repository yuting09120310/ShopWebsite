# 使用官方的 .NET SDK 作為基礎鏡像
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# 設定工作目錄
WORKDIR /app

# 複製專案文件到工作目錄
COPY . .

# 執行 restore、build 和 publish
RUN dotnet restore
RUN dotnet build --configuration Release --no-restore
RUN dotnet publish --configuration Release --no-build --output /app/publish

# 使用官方的 ASP.NET Core 鏡像作為運行時環境
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final

# 設定工作目錄
WORKDIR /app

# 從之前的 build 階段複製構建好的發布文件到運行時鏡像
COPY --from=build /app/publish .

# 指定容器啟動時運行的命令
ENTRYPOINT ["dotnet", "AlexBlogMVC.dll"]