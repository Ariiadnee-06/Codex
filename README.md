# 💻 Codex - Sistema Inteligente de Recomendación de Computadoras

**Codex** es una plataforma web desarrollada con **ASP.NET Core MVC (C#)** que ofrece recomendaciones personalizadas de computadoras. A través de un cuestionario simple e intuitivo, permite a usuarios sin conocimientos técnicos encontrar el equipo ideal según sus necesidades reales.

---

## 👥 Proyecto Académico

- **Materia:** Ingeniería de Software I  
- **Equipo:** Codex 
- **Integrantes:**
  - 👩‍💻 Lady Johana Torres Ríos 
  - 👩‍💻 Ariadne Castañeda  
  - 👨‍💻 Juan Pablo  

---

## ✨ Características Principales

- ✅ Recomendación basada en lógica real y perfiles de uso
- 🎯 Formulario interactivo, claro y personalizable
- 🧠 Algoritmo de emparejamiento según necesidades
- 📊 Datos semilla para 7 tipos de usuarios: básico, gamer, creativo, programador, editor multimedia, profesional y estudiante
- 💅 Interfaz con estética elegante, morada, y un toque tecnológico-gamer
- 🛠 Compatible con SQL Server y estructura MVC modular

---

## 🔍 ¿Cómo Funciona?

El sistema procesa las respuestas del formulario y filtra computadoras tomando en cuenta:

- Perfil de uso (ej. gamer, diseñador, estudiante, etc.)
- Presupuesto estimado (slider dinámico con separador de miles)
- Preferencias opcionales (marca, tipo de almacenamiento)
- Algoritmo que evalúa características técnicas y devuelve las opciones óptimas

---

## 🚫 Archivos que NO debes modificar

Estos archivos contienen la lógica crítica y están verificados:

- `ApplicationDbContext.cs`  
- `DbInitializer.cs`  
- `RecomendacionController.cs`  
- Modelos dentro del directorio `Models/`

---

## 🛠 Cómo Ejecutar el Proyecto

1. Clonar el repositorio:

   ```bash
   git clone https://github.com/Ariiadnee-06/Codex.git
