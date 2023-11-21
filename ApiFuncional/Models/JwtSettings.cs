namespace ApiFuncional.Models 
{
    public class JwtSettigns 
    {
        public string? Segredo { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string? Emissor { get; set; } //Qual aplicação emitiu o token.
        public string? Audiencia { get; set; } //Para onde esse token é válido.
    }
}