# Skrypt dodający nową migrację.

# Niezbędne narzędzia:
# dotnet tool install --global dotnet-ef

if ($args[0]) {
    dotnet ef migrations add $args[0]
}
