//$(function () {
//    loadList();
   
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

//function AddItemPedido(id) {
//    var Itens = [];
//     $.ajax({
//        type: 'POST',
//        url: '/Pedido/AddItensPedido',
//        data: { produtoID: id }
//    }).done(function () {
//        loadList();
//    }).fail(function (error) {        
//    });

//}

function AddItemPedido() {       
    item.push($("#ProdutoID option:selected").val());
    loadList(item);
}

function RemoveItemPedido(id) {
    item.pop(id);
    loadList(item);
}