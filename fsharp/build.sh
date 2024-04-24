# from Paket: http://fsprojects.github.io/Paket/get-started.html
dotnet tool restore
dotnet paket restore
# Your call to build comes after the restore calls, possibly with FAKE: https://fake.build/