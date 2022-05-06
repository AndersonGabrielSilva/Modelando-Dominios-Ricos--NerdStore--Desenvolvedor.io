using AutoMapper;
using NerdStore.Catalogo.Application.ViewModels;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Application.AutoMapper
{
    /// <summary>
    /// O AutoMapper pode ser utilizado para fazer o mapeamento de uma classe para outra classe.
    /// Utilizaremos para fazer o mapeamento entre a View Model e a Entidade de Dominio
    /// <para> Realiza o mesma função do GetBaseView do S.Agro</para>
    /// <para>Estou configurando um Perfil de Mapeamento para o AutoMapper</para>
    /// <para>Mapeando da View Model para o Dominio</para>
    /// </summary>
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProdutoViewModel, Produto>()
                .ConstructUsing(p =>
                    new Produto(p.Nome, p.Descricao, p.Ativo,
                        p.Valor, p.CategoriaId, p.DataCadastro,
                        p.Imagem, new Dimensoes(p.Altura, p.Largura, p.Profundidade)));

            CreateMap<CategoriaViewModel, Categoria>()
                .ConstructUsing(c => new Categoria(c.Nome, c.Codigo));
        }
    }
}