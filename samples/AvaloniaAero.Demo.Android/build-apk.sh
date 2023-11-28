#!/bin/sh

SCRIPT_DIR=${0%/*}
SCRIPT_DIR=`realpath "$SCRIPT_DIR"`
cd "$SCRIPT_DIR"
dotnet build -f net7.0-android -c Release -p:AndroidSdkDirectory="$HOME/Android/Sdk" -p:TestPublish=True