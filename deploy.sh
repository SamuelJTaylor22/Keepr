dotnet publish -c Release
docker build -t keepr ./bin/Release/netcoreapp3.1/publish
docker tag keepr registry.heroku.com/sjtkeepr/web
docker push registry.heroku.com/sjtkeepr/web
heroku container:release web -a sjtkeepr