SCRIPT_DIR=$( cd "$( dirname "$0" )" && pwd )
APP="$SCRIPT_DIR/bin/Editor_x64"
export LD_LIBRARY_PATH="$SCRIPT_DIR/bin:$LD_LIBRARY_PATH"
if [ -f "$APP" ]; then
	"$APP"  -video_app auto -video_vsync 0 -video_refresh 0 -video_mode 1 -video_resizable 1 -video_fullscreen 0 -video_debug 0 -video_gamma 1.000000 -sound_app auto -data_path "../data/"  -engine_config "../data/unigine.cfg" -extern_plugin "FbxImporter,GLTFImporter" -console_command "config_readonly 0"
else
	echo "$APP not found"
fi
