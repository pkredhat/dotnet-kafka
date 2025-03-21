# Dotnet Kafka Producer / Consumer - App

Sample console application that connects to your local Kafka instance using Dotnet. Please note, you must have a kafka instance running for this to work. Follow the instructions below 
     
## Usage
```
Usage: dotnet run <produce|consume>
```

$~$ 


## Building Container Images 
From your Root Folder

#### With Podman
```
podman build -t <your image name> .
```
#### With Docker
```
docker build -t <your image name> .
```
 ##### *NOTE: Modify the 'ENV KAFKA_BOOTSTRAP_SERVERS=<server>' variable in the Dockerfile to set your Kafka Server

  $~$

## Setting Up Environment Variables

> Set the $**KAFKA_BOOTSTRAP_SERVERS** environment variable to change the kafka location

##### Linux
```
export KAFKA_BOOTSTRAP_SERVERS="localhost:9092"  
echo $PATH to verify
```  

##### Mac
```
export KAFKA_BOOTSTRAP_SERVERS="localhost:9092"
Or edit the .bash_profile
echo $PATH to verify
```

##### Windows
```
1. Open the Control Panel
2. Select System
3. Select System Properties / Advanced
4. Select Environment Variables button on the bottom
5. Add the KAFKA_BOOTSTRAP_SERVERS variable here
```

  $~$

