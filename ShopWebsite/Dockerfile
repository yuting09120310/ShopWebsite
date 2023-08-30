# �ϥΩx�誺 .NET SDK �@����¦�蹳
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# �]�w�u�@�ؿ�
WORKDIR /app

# �ƻs�M�פ���u�@�ؿ�
COPY . .

# ���� restore�Bbuild �M publish
RUN dotnet restore
RUN dotnet build --configuration Release --no-restore
RUN dotnet publish --configuration Release --no-build --output /app/publish

# �ϥΩx�誺 ASP.NET Core �蹳�@���B�������
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final

# �]�w�u�@�ؿ�
WORKDIR /app

# �q���e�� build ���q�ƻs�c�ئn���o������B����蹳
COPY --from=build /app/publish .

# ���w�e���ҰʮɹB�檺�R�O
ENTRYPOINT ["dotnet", "AlexBlogMVC.dll"]