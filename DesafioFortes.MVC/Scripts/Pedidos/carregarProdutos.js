//$(function () {
//    //loadList();
     
//});

var item = [];

function loadList(ids) {  

   $.ajax({
        type: 'POST',
        url: '/Pedido/ListaProdutos',
        data: {
            items: ids
        }
    }).done(function (data) {       
        $('#tabela').html(data);        
    }).fail(function (error) {
        $('#loader').transition('fade');
    });
}

function AddIPedido() {
    var itens = [];

    $('#tabelaBanco tbody tr').each(function () {
        var colunas = $(this).children();

        var produto = {
            'ProdutoID': $(colunas[0]).text(),
            'Nome': $(colunas[1]).text(),
            'Valor': $(colunas[2]).text(),
            'Disponivel': true,
            'FornecedorID': $(colunas[3]).text(),
            'Fornecedor': null
            
        }

        var id = $(colunas[0]).text();
        itens.push(produto);
    });

    var pedido = {
        'PedidoID': 0,
        'DataPedido': $('#DataPedido').val(),
        'ValorTotal': $('#ValorTotal').val(),
        'QuantidadeProdutos': $('#QuantidadeProdutos').val(),
        'ProdutoID': $('#ProdutoID').val(),
        'FornecedorID': $('#FornecedorID').val(),
        'Produtos': itens
    }

     $.ajax({
        type: 'POST',
        url: '/Pedido/Create',
        data: {
            pedido: pedido            
        }
    }).done(function () {
        //
    }).fail(function (error) {        
    });

}

function AddItemPedido() {       
    item.push($("#ProdutoID option:selected").val());
    loadList(item);   

}

function RemoveItemPedido(id) {
    item.pop(id);
    if (item.length <= 0) {
        location.reload();
    }
    loadList(item);
}


