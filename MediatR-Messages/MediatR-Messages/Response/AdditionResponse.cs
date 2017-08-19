using System;

namespace MediatRMessages.Response
{
    public class AdditionResponse
    {
        public int Answer { get; }
        public string Equation { get; }

        public AdditionResponse(string equation, int answer)
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
