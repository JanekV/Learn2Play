<h1>Learn2Play

Web application for beginners learning to play songs on guitar.

Joint project in ASP.NET Web applications and Building Distributed Systems at TalTech IT College.

To run backend you must add some type of database.

Installing or updating aspnet codegenerators:
~~~
dotnet tool install --global dotnet-aspnet-codegenerator

dotnet tool update --global dotnet-aspnet-codegenerator
~~~
In solution folder:

Add db migration:
~~~
dotnet ef migrations add InitialDbCreation --project DAL.App.EF --startup-project WebApp
~~~

Apply migration:
~~~
dotnet ef database update --project DAL.App.EF --startup-project WebApp
~~~

For restarting, delete Migrations folder in DAL.App.EF and drop db:
~~~
dotnet ef database drop --project DAL.App.EF --startup-project WebApp
~~~

Generating controllers should be done in WebApp directory.

<h2>Docker build

~~~
docker build -t webapp .
docker run --name webapp_docker --rm -it -p 8000:80 webapp
~~~

Tag or add version description for container.

~~~
docker tag webapp [docker username]/[webapp name]:[tag]
~~~
Push to docker.
~~~
docker login -u [username]

docker push [docker username]/[webapp name]:[tag]
~~~