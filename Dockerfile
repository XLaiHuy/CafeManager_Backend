# 1. Build Layer
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy mọi thứ và khôi phục thư viện
COPY . ./
RUN dotnet restore

# Build dự án ra thư mục 'out'
# Huy nhớ kiểm tra lại tên project API của mình có đúng là CafeManager.API không nhé
RUN dotnet publish CafeManager.API/CafeManager.API.csproj -c Release -o out

# 2. Run Layer
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Render yêu cầu chạy ở cổng 80 hoặc theo biến PORT của họ
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

# Chạy file dll của project API
ENTRYPOINT ["dotnet", "CafeManager.API.dll"]