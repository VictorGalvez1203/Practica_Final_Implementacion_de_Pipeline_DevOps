# 🛠️ Práctica Final: Diseño e Implementación de Pipeline DevOps

## 📖 Descripción del Proyecto
Este proyecto consiste en diseñar e implementar un pipeline DevOps completo para una **aplicación web simple**. Durante este ejercicio, se aplicaron los conceptos y herramientas aprendidos en el curso, incluyendo:

- Control de versiones.
- Integración y despliegue continuo (CI/CD).
- Pruebas automatizadas.
- Contenedores Docker.
- Monitoreo básico.

---

## 🎯 Objetivo
Desarrollar una solución funcional que integre:

![image](https://github.com/user-attachments/assets/e01e41c9-8e83-4fd1-8999-fe4519139b0c)
![image](https://github.com/user-attachments/assets/5a38dc79-541d-4056-95d4-ad534d3a4c1f)

1. **Aplicación web simple**: Frontend y backend básicos.
2. **Pipeline CI/CD**: Configurado para realizar despliegues automatizados.
3. **Pruebas automatizadas**: Garantizar la calidad del código.
4. **Monitoreo básico**: Evaluar el rendimiento de la aplicación.

🔗 **Accede al Action aquí:** [Ver Workflow CI/CD](https://github.com/VictorGalvez1203/Practica_Final_Implementacion_de_Pipeline_DevOps/actions)

---

## 🚀 Workflow CI/CD: Deploy WebApp
El archivo de configuración de **GitHub Actions** (`deploy.yml`) implementa un pipeline automatizado con los siguientes pasos:

1. **Clonar el Repositorio**  
   Utiliza `actions/checkout` para obtener el código fuente desde GitHub.

2. **Configurar el Entorno .NET**  
   Instala y configura el SDK de .NET (versión 8.0).

3. **Restaurar Dependencias**  
   Ejecuta `dotnet restore` para recuperar las dependencias del proyecto.

4. **Compilar el Proyecto**  
   Usa `dotnet build` en modo *Release* para generar el ejecutable.

5. **Publicar el Proyecto**  
   Empaqueta la aplicación con `dotnet publish` para el despliegue.

6. **Ejecutar la Aplicación Localmente**  
   Inicia la aplicación en el puerto 8080 para pruebas locales.

7. **Verificar la Aplicación**  
   Realiza un test de conectividad con `curl` para asegurar que responde correctamente.

8. **Detener la Aplicación (Opcional)**  
   Finaliza el proceso ejecutando `pkill`.

---

## ✅ Resultados del Pipeline
- **Clonado del repositorio y configuración del entorno .NET:** Completados con éxito.  
- **Restauración, compilación y publicación:** Sin errores.  
- **Verificación:** La aplicación inició correctamente, pero se encontró un error HTTP 500. Esto indica un problema en el backend que debe resolverse antes de avanzar al entorno de producción.  
- **Limpieza del entorno:** Finalizada correctamente.

---

## 🐳 Implementación con Docker, ASP.NET Core y SQL Server

En este proyecto se utilizó **Docker** para gestionar la base de datos, lo que permitió un entorno aislado y portable. A continuación, se detalla el proceso:

### 1️⃣ Configuración de la base de datos con Docker:
- Implementación de un contenedor SQL Server:
  - Descarga de la imagen oficial desde Docker Hub.
  - Ejecución del contenedor con credenciales, puertos y persistencia configurados.
  - Verificación de la conexión con **SQL Server Management Studio (SSMS)**.

### 2️⃣ Conexión de la aplicación a la base de datos:
- Desarrollo de una página web con **C# y ASP.NET Core**.
- Configuración de la conexión a la base de datos en `appsettings.json`.
- Uso de **Entity Framework Core** para manejar la interacción con la base de datos.

### 3️⃣ Creación del inventario:
- **Interfaz de usuario**: Tabla dinámica con las siguientes funcionalidades:
  - **Agregar:** Nuevos elementos con validaciones.
  - **Editar:** Actualización de datos.
  - **Eliminar:** Remoción de elementos tras confirmación.
- **DataTables**: Para paginación, búsqueda y ordenamiento.

### 4️⃣ Despliegue del proyecto completo en Docker:
- Creación de un contenedor adicional para la aplicación web.
- Configuración de una red Docker para comunicación entre servicios.
- Uso de `docker-compose.yml` para gestionar servicios.

🔗 **Archivos importantes:**  
- [Dockerfile](https://github.com/VictorGalvez1203/Practica_Final_Implementacion_de_Pipeline_DevOps/blob/master/CI_CD/Dockerfile)  
- [docker-compose.yml](https://github.com/VictorGalvez1203/Practica_Final_Implementacion_de_Pipeline_DevOps/blob/master/CI_CD/docker-compose.yml)  
- [Workflow CI/CD](https://github.com/VictorGalvez1203/Practica_Final_Implementacion_de_Pipeline_DevOps/blob/master/.github/workflows/deploy.yml)

---

## 🌟 Características adicionales
- **Validaciones:** Backend y frontend para consistencia de datos.
- **Manejo de excepciones:** Captura de problemas de conexión o entradas inválidas.
- **Interfaz intuitiva:** Uso de **Bootstrap** para diseño responsivo.

---

## 💡 Beneficios del enfoque:
- **Escalabilidad:** Docker facilita el despliegue en cualquier entorno.  
- **Mantenimiento:** Contenedores separados simplifican actualizaciones.  
- **Portabilidad:** La configuración puede replicarse fácilmente en otros equipos o servidores.

---

**¡Gracias por leer!** 🎉 Si tienes alguna duda, no dudes en abrir un issue en el repositorio.
