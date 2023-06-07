@ECHO OFF

REM 執行第一個命令
docker build -t alexblogmvc .

REM 執行第二個命令
docker tag alexblogmvc yuting09120310/alexblogmvc:latest

REM 執行第三個命令
docker push yuting09120310/alexblogmvc:latest

REM 暫停等待使用者按下任意鍵
PAUSE
