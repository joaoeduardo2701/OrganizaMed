using OrganizaMed.Dominio.Compartilhado;

namespace OrganizaMed.Dominio.ModuloMedico;

public class Medico : EntidadeBase
{
    public string Nome { get; set; }
    public string CRM { get; set; }

    public Medico() { }

    public Medico(string nome, string crm)
    {
        Nome = nome;
        CRM = crm;
    }
}
