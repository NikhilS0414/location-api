sudo killall -9 dotnet
nohup dotnet /home/ec2-user/RegionApi/RegionBuild/build_output/RegionApi.dll &>/dev/null &
