# 🧠 QuizSystem

**QuizSystem** es una librería en C# para crear y evaluar cuestionarios de opción múltiple de forma simple, robusta y reutilizable. Diseñada para ser utilizada tanto en aplicaciones de consola como en proyectos Unity mediante `using QuizSystem`.

---

## ✨ Características

- ✅ Soporte para preguntas de opción múltiple.
- 🧪 Evaluación automática de respuestas.
- ⚠️ Control robusto de errores de uso.
- 🔌 Fácil integración en cualquier proyecto C# o Unity.
- 🧱 Arquitectura clara y profesional lista para ampliaciones futuras.

---

## 📦 Instalación

Clona este repositorio o descarga la carpeta `QuizSystem` y colócala dentro de tu proyecto.

```bash
git clone https://github.com/ShinigamiOs/QuizSystem.git
```

Luego simplemente importa el namespace en tu código:

```csharp
using QuizSystem;
```

---

## 🚀 Cómo usarlo

### Ejemplo básico

```csharp
using QuizSystem;

var opciones = new List<AnswerOption>{
    new AnswerOption("Tokio", false),
    new AnswerOption("París", true),
    new AnswerOption("Roma", false),
    new AnswerOption("Madrid", false)
};

var pregunta = new MultipleChoiceQuestion("¿Cuál es la capital de Francia?", opciones);

var quiz = new Quiz("Cuestionario de geografía");
quiz.AddQuestion(pregunta);

var respuestasUsuario = new List<List<int>>{
    new List<int>{ 1 } // París
};

var resultados = quiz.EvaluateAll(respuestasUsuario);
Console.WriteLine("Resultado: " + resultados[0]); // Output: Correct
```

---

## 🔍 Clases principales

### `AnswerOption`
Representa una opción de respuesta.

```csharp
new AnswerOption("Texto de la opción", esCorrecta: true/false);
```

---

### `MultipleChoiceQuestion`
Una pregunta con múltiples opciones.

```csharp
var pregunta = new MultipleChoiceQuestion("¿Pregunta?", listaDeOpciones);
```

Método:

```csharp
EvaluateAnswer(List<int> respuestasUsuario)
```

Devuelve un `AnswerResult` (`Correct`, `Incorrect` o `NotAnswered`).

---

### `Quiz`
Cuestionario completo con varias preguntas.

```csharp
var quiz = new Quiz("Título");
quiz.AddQuestion(pregunta);
quiz.EvaluateAll(listaDeRespuestas); // Devuelve List<AnswerResult>
```

---

## 📊 Enum `AnswerResult`

```csharp
Correct     // Todas las opciones correctas fueron seleccionadas
Incorrect   // Respuestas incorrectas o incompletas
NotAnswered // El usuario no respondió
```

---

## 🧪 Ejemplo práctico

```csharp
var quiz = new Quiz("Test de prueba");

quiz.AddQuestion(new MultipleChoiceQuestion("¿Capital de Japón?", new List<AnswerOption>{
    new AnswerOption("Tokio", true),
    new AnswerOption("Osaka", false)
}));

var respuestas = new List<List<int>> { new List<int> { 0 } };
var resultados = quiz.EvaluateAll(respuestas);

foreach (var r in resultados) {
    Console.WriteLine(r); // Correct
}
```

---

## 🧠 Pensado para extensión

Aunque esta versión incluye solo funcionalidad de preguntas de opción múltiple, el diseño favorece la extensibilidad para:

- Escalas personalizadas (porcentaje, puntuación).
- Métodos de resultado más avanzados.
- Formatos de entrada variados.
- Integración visual directa con Unity.

---

## 🎮 Uso en Unity

Coloca los scripts de `QuizSystem` en una carpeta de tu proyecto Unity (por ejemplo: `Assets/Scripts/QuizSystem/`) y simplemente usa:

```csharp
using QuizSystem;
```

Puedes luego crear tus cuestionarios en un `MonoBehaviour`, editor, o cargarlos desde JSON/XML si deseas serializarlos.

---

## 📄 Licencia

Este proyecto está licenciado bajo la Licencia GNU.

---

## 🤝 Contribuciones

Las contribuciones son bienvenidas. Si tienes ideas para mejorar esta librería, abrir un issue o un pull request será más que apreciado.

---
