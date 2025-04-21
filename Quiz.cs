namespace QuizSystem
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Representa un cuestionario completo con preguntas de opción múltiple.
    /// </summary>
    public class Quiz
    {
        /// <summary>
        /// Título del cuestionario.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Lista de preguntas del cuestionario.
        /// </summary>
        public List<MultipleChoiceQuestion> Questions { get; }

        /// <summary>
        /// Crea un nuevo cuestionario con el título especificado.
        /// </summary>
        /// <param name="title">Título del cuestionario.</param>
        public Quiz(string title)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title), "El título del cuestionario no puede ser nulo.");
            Questions = new List<MultipleChoiceQuestion>();
        }

        /// <summary>
        /// Añade una nueva pregunta al cuestionario.
        /// </summary>
        /// <param name="question">Pregunta de opción múltiple.</param>
        /// <exception cref="ArgumentNullException">Lanza una excepción si la pregunta es nula.</exception>
        public void AddQuestion(MultipleChoiceQuestion question)
        {
            if (question == null)
                throw new ArgumentNullException(nameof(question), "La pregunta no puede ser nula.");

            // Evitar preguntas duplicadas (en caso de que quieras hacerlo)
            if (Questions.Contains(question))
            {
                Console.WriteLine("La pregunta ya existe en el cuestionario.");
                return;
            }

            Questions.Add(question);
        }

        /// <summary>
        /// Evalúa todas las respuestas dadas por el usuario.
        /// </summary>
        /// <param name="userAnswers">Lista de respuestas del usuario.</param>
        /// <returns>Lista de resultados de cada pregunta.</returns>
        /// <exception cref="ArgumentException">Lanza una excepción si el número de respuestas no coincide con el número de preguntas.</exception>
        public List<AnswerResult> EvaluateAll(List<List<int>> userAnswers)
        {
            if (userAnswers.Count != Questions.Count) 
                throw new ArgumentException("El número de respuestas no coincide con el número de preguntas.", nameof(userAnswers));

            List<AnswerResult> results = new List<AnswerResult>();
            for (int i = 0; i < Questions.Count; i++)
            {
                var result = Questions[i].EvaluateAnswer(userAnswers[i]);
                results.Add(result);
            }

            return results;
        }

        /// <summary>
        /// Obtiene el puntaje total del cuestionario.
        /// </summary>
        /// <param name="userAnswers">Lista de respuestas del usuario.</param>
        /// <returns>El puntaje total como un valor entre 0 y el número total de preguntas.</returns>
        public int GetTotalScore(List<List<int>> userAnswers)
        {
            var results = EvaluateAll(userAnswers);
            int score = 0;

            foreach (var result in results)
            {
                if (result == AnswerResult.Correct)
                {
                    score++;
                }
            }

            return score;
        }

        /// <summary>
        /// Calcula el porcentaje de respuestas correctas del cuestionario.
        /// </summary>
        /// <param name="userAnswers">Lista de respuestas del usuario.</param>
        /// <returns>El porcentaje de respuestas correctas (entre 0 y 100).</returns>
        public double GetScorePercentage(List<List<int>> userAnswers)
        {
            int score = GetTotalScore(userAnswers);
            double percentage = ((double)score / Questions.Count) * 100;
            return percentage;
        }
    }
}