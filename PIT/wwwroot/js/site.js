$(document).ready(function () {
    if ($("#mostraModal").val() == "mostrar") {
        $(".modal").modal("show");
    }

    $("#menos").on("click", () => $("#qtd").val(parseInt($(this).val()) - 1));
    $("#mais").on("click", () => $("#qtd").val(parseInt($(this).val()) + 1));
});

function adicionarProduto(count) {
    var qtd = $("#qtd_" + count).val();
    var produto = $("#produto_" + count).val();
    var contagem = $("#contagem").val();

    $.ajax({
        method: "GET",
        url: "/Vendas/AdicionarProduto",
        data: { produto: produto },
        success: function (resp) {
            $("#listKart").append("<li class='list-group-item'>" + qtd + "x " + resp.descricao + " R$" + (resp.preco * qtd));
            $("#total").val($("#total").val() + (resp.preco * qtd));
            $("#formKart").append(`<input type='hidden' name='Carrinho.Compras[${contagem}].ProdutoID' value='` + produto + "' />");
            $("#formKart").append(`<input type='hidden' name='Carrinho.Compras[${contagem}].Produto.Descricao' value='` + resp.descricao + "' />");
            $("#formKart").append(`<input type='hidden' name='Carrinho.Compras[${contagem}].Produto.Preco' value='` + resp.preco + "' />");
            $("#formKart").append(`<input type='hidden' name='Carrinho.Compras[${contagem}].Quantidade' value='` + qtd + "' />");
            $("#contagem").val(parseInt(contagem) + 1);
            $("#kart").modal("show");
        }
    });
}