namespace QuizSystem
{
    /// <summary>
    /// Representa una opción de respuesta en una pregunta de opción múltiple.
    /// </summary>
    public class AnswerOption
    {
        /// <summary>
        /// El texto que aparece como opción.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Indica si esta opción es correcta.
        /// </summary>
        public bool IsCorrect { get; }

        /// <summary>
        /// Crea una nueva opción de respuesta para una pregunta de opción múltiple.
        /// </summary>
        /// <param name="text">Texto de la opción, por ejemplo "Tokio".</param>
        /// <param name="isCorrect">Indica si la opción es la respuesta correcta. Usualmente se debe asignar 'true' solo a una opción en cada pregunta.</param>
        /// <exception cref="ArgumentException">Lanza una excepción si el texto es vacío o nulo, o si no se asigna al menos una opción correcta en una pregunta.</exception>
        public AnswerOption(string text, bool isCorrect)
        {
            if (string.IsNullOrWhiteSpace(text)) // Validación del texto
            {
                throw new ArgumentException("El texto de la opción no puede ser nulo o vacío.", nameof(text));
            }
            
            Text = text;
            IsCorrect = isCorrect;
        }

        /// <summary>
        /// Verifica si esta opción es la respuesta correcta.
        /// </summary>
        /// <returns>Devuelve true si es la opción correcta, de lo contrario false.</returns>
        public bool CheckAnswer() => IsCorrect;
    }
}