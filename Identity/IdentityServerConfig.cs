using Duende.IdentityServer.Models;

namespace produtoCRUD.Identity
{
    public class IdentityServerConfig
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("produtoApi", "ProdutoAPI")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource ("produtosapi","Produto API")
                {
                    Scopes = {"produtosapi"}
                }
            };
    }
}
