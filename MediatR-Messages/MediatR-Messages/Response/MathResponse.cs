using System;

namespace MediatRMessages.Response
{
    public class MathResponse
    {
        public int Answer { get; }
        public string Equation { get; }

        public MathResponse(string equation, int answer)
        {
            if (string.IsNullOrWhiteSpace(equation))
            {
                throw new ArgumentException("Cannot be empty.", nameof(equation));
            }
            Equation = equation;
            Answer = answer;
        }
    }
}
