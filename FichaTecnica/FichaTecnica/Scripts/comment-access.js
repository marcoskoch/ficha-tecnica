var positiveTotal = 0;
var negativeTotal = 0;
var converter = new showdown.Converter();

function extractDate(date) {
    return date.match(/\d+/)[0];
}

comments.sort(function(left, right) {
    return extractDate(left.DataCriacao) < extractDate(right.DataCriacao)
})

if (!user.Pefil === 'Lider Tecnico' && model.Cargo != 'Gerente' || model.Cargo != 'Lider Tecnico') {

    comments.forEach(function (comment) {

        if (comment.Estado != 0) {
            return;
        }
        var typeTag;
        var deleteOption = '';

        if (user != null) {
            deleteOption = user.Id == comment.IdUsuario || user.Perfil === 'Gerente' ? '<a href="../ExcluirComentario/' + comment.Id + '" class="excluir-comentario">&times;</a>' : '';
        }

        if (comment.Tipo == 0) {
            positiveTotal = positiveTotal + 1;
            $('#total-positivo').text(positiveTotal);
        }
        else {
            negativeTotal = negativeTotal + 1;
            $('#total-negativo').text(negativeTotal);
        }

        $('#comentarios')
              .append($('<div class="bloco-comentario ' + (comment.Tipo == 0 ? 'comentario-positivo' : 'comentario-negativo') + '">')
                .append($('<h4>').text(comment.Assunto + ' - ' + comment.Projeto.Nome))
                .append($(converter.makeHtml(comment.Texto)))
                .append($(deleteOption))
                )
    })
}