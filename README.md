# DiscordWebhook
> Creado por AlejandroDeVV

DiscordWebhook es un pequeño programa de consola elaborado para poder enviar tareas con varia información como titulo, descripción, asignatura, y fecha de entrega
con texto enriquecido a un canala de un servidor de Discord mediante un Webhook, automitazando, facilitando, y mejorando la información de las tareas y su
contenido.

> Estado: Version 1.1

## Requisitos:
- .NET 10 o superior
- Fichero `.env`. Siga el ejemplo del fichero `.env.example`.
- Webhook en un canal de texto en Discord.
- Fichero JSON con el formato especificado en `assigment.json.example`. No es necesario que el fichero tenga un nombre específico, solamente que cumpla el formato.
- SO basado en 64 bits (Windows, Linux, MacOS).
  
## Compilar
### Windows
Para compilar el programa en Windows ejecute el siguiente comando `dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -o ./publish`
### Linux
Para compilar el programa en Linux, ejecute el siguiente comando `dotnet publish -c Release -r linux-x64 --self-contained -p:PublishSingleFile=true -o ./publish`
### MacOS
Para compilar el programa en MacOS, ejecute el siguiente comando `dotnet publish -c Release -r osx-arm64 --self-contained -p:PublishSingleFile=true -o ./publish`

Independientemente del sistema en el que compile la aplicación, se generara un fichero `Discord_Weboohk_Clase` o `Discord_Webhook_Clase.exe` (Windows) que debe renombrar a `PublicarTarea` o `PublicarTarea.exe` (Windows). Una vez lo tenga, debe ejecutar los siguientes comandos:

### Windows
Mueva el fichero `PublicarTarea.exe` a una carpeta fija, por ejemplo `C:\MisHerramientas` y añada al PATH la ruta al .exe.
### Linux & MacOS
Debe darle permisos de ejecución y moverlo al directorio bin, después, copiar el .env a la misma ruta y darle permisos de ejecución.
`chmod +x ./publish/PublicarTarea`
`sudo mv ./publish/PublicarTarea /usr/local/bin/`
`sudo cp .env /usr/local/bin/.env`
`sudo chmod 600 /usr/local/bin/.env`


## Forma de uso
Para poder hacer uso de la aplicación, una vez la tenga compilada y añadida al entorno global, debe ejecutar el siguiente comando. 
`PublicarTarea ruta/a/tarea.json` en Windows y `sudo PublicarTarea ruta/a/tarea.json` en Linux y MacOS