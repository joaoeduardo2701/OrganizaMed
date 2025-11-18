namespace OrganizaMed.Dominio.Compartilhado;

public abstract class EntidadeBase
{
    public Guid id { get; set; }

    protected EntidadeBase()
    {
        id = Guid.NewGuid();
    }
}
        