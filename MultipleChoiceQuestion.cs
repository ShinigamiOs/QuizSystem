namespace QuizSystem
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Representa una pregunta de opción múltiple.
    /// </summary>
    public class MultipleChoiceQuestion
    {
        /// <summary>
        /// El texto de la pregunta.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Lista de opciones disponibles para esta pregunta.
        /// </summary>
        public List<AnswerOption> Options { get; }

        /// <summary>
        /// Crea una nueva pregunta de opción múltiple.
        /// </summary>
        /// <param name="text">Texto de la pregunta.</param>
        /// <param name="options">Lista de opciones para la pregunta.</param>
        /// <exception cref="ArgumentNullException">Lanza una excepción si el texto o las opciones son nulos.</exception>
        /// <exception cref="ArgumentException">Lanza una excepción si no hay al menos dos opciones.</exception>
        public MultipleChoiceQuestion(string text, List<AnswerOption> options)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text), "El texto de la pregunta no puede ser nulo.");
            Options = options ?? throw new ArgumentNullException(nameof(options), "Las opciones no pueden ser nulas.");

            if (options.Count < 2) 
                throw new ArgumentException("Se necesitan al menos dos opciones para la pregunta.", nameof(options));
        }

        /// <summary>
        /// Evalúa la respuesta dada por el usuario.
        /// </summary>
        /// <param name="userAnswer">Lista de índices seleccionados por el usuario.</param>
        /// <returns>El resultado de la evaluación.</returns>
        /// <exception cref="ArgumentException">Lanza una excepción si los índices en userAnswer son inválidos.</exception>
        public AnswerResult EvaluateAnswer(List<int> userAnswer)
        {
            if (userAnswer == null || userAnswer.Count == 0) 
                return AnswerResult.NotAnswered;

            bool isCorrect = true;
            foreach (var index in userAnswer)
            {
                if (index < 0 || index >= Options.Count)
                    throw new ArgumentException($"El índice {index} está fuera del rango de opciones disponibles.", nameof(userAnswer));
                    
                if (!Options[index].IsCorrect)
                {
                    isCorrect = false;
                    break;
                }
            }

            return isCorrect ? AnswerResult.Correct : AnswerResult.Incorrect;
        }
    }
}