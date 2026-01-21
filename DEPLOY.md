Ubuntu 24.04 поставил на mac через UTM;
postgresql поставил на ОС виртуалки через "apt install postgresql";
в postgresql.conf поставил "listen_addresses = '*'";
в "pg_hba.conf" разрешил подключения для docker подсети ("172.17.0.0/16");


чтобы приложение из docker контейнера подключить к бд на хосте использовал ip адрес шлюза
docker моста по умолчанию "172.17.0.1". Нужно чтобы контейнера выходилд из свой сети и мог 
обращаться к сервисам из сети на оси виртуалки. 


Dockerfile: две стадии - build (юзает dotnet/sdk:10.0), final (юзает dotnet/aspnet:10.0 для запуска (чтобы размер образа уменьшить))
CI/CD: github actions с собственным раннером, который стоит на виртуалке
Пайплайн: сборка образа + деплой контейнера при пуше на main ветку

Ручной запуск (чтобы вне пайплайна запустить): в терминале пишем:
docker run -d --name my-api \
  -p 8080:8080 \
  -e ConnectionStrings__DefaultConnection="Host=172.17.0.1;Port=5432;Database=project_db;Username=project_user;Password=secure_pass" \
  dotnet-app-prod