using System;
using System.Collections.Generic;
using System.Text;

namespace WiProLocadora.Domain.UseCases.DTO
{
    public class ResponseDTO
    {
        public ResponseDTO() { }
        public ResponseDTO(int statusCode, string mensagem, Object body)
        {
            StatusCode = statusCode;
            Mensagem = mensagem;
            Body = body;
        }

        public int StatusCode { get; set; }
        public string Mensagem { get; set; }
        public Object Body { get; set; }
    }
}
