$.ajax({
    url: '/Membro/ProjetoAutocomplete/',
    type: 'POST',
    dataType: 'json',
    data: { idMembro: model.Id },
}).done(function (response) {
    response.forEach(function (i) {
        projetos.push(i)
    })
}).always(function () {
    projetos.forEach(function (projeto) {
        $('#projetos')
            .append($('<option>').html(projeto.label).attr('value', projeto.value))
            .attr('name', 'idProjeto');

        $('#lista-projetos')
            .append($('<li>')
                .text(projeto.label))
    })
});

