#!/bin/sh

SCRIPT_DIR="${0%/*}"
cd "$SCRIPT_DIR"
dotnet build -f net6.0-android -c Release -p:AndroidSdkDirectory="$HOME/Android/Sdk" -p:UseDotnet6SDK=True "$@"