#!/bin/sh

SCRIPT_DIR=${0%/*}
SCRIPT_DIR=`realpath "$SCRIPT_DIR"`

RID="win7-x86"
CONFIGURATION="Release"

cd "$SCRIPT_DIR"

dotnet publish \
--framework net5.0 -r "$RID" \
--self-contained true \
-o "$SCRIPT_DIR/../../../publish/$RID"

#-c "$CONFIGURATION" \
#-p:PublishSingleFile=true \