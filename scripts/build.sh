#!/bin/bash

# build the solution
dotnet build api/MedTrackDash.sln --configuration Release /p:AssemblyVersion=1.1.1.$BUILD_NUMBER