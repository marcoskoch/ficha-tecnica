membros.forEach(function (membro) {
    var model = (membro.LinksGithub);
    var commitList = [];

    model.Links.forEach(function (l) {
        var localStorageCommits = localStorage.getItem('latestCommits'.concat(membro.Id.toString()));

        if (localStorageCommits == null || localStorageCommits == '[]') {
            $.get(model.URLBaseAPI + l.URL + 'commits')
                .done(function (response) {
                    response.forEach(function (i) {
                        commitList.push({ sha: i.sha.slice(0, 7), date: new Date(i.commit.author.date).getTime(), message: i.commit.message, link: i.html_url })

                    })
                })
            .always(function () {
                atribuiValoresGitHubAoMembro(commitList, membro);
            });
        }
        else {
            commitList = JSON.parse(localStorageCommits);
            atribuiValoresGitHubAoMembro(commitList, membro);
        }
    });
});

function atribuiValoresGitHubAoMembro(commitList, membro) {
    commitList.sort(function (left, right) { return left.date < right.date })
    commitList = commitList.slice(0, 3);
    localStorage.setItem('latestCommits'.concat(membro.Id), JSON.stringify(commitList));
    commitList.forEach(function (commit) {
        var timeStamp = new Date(commit.date);
        membro.DataUltimoCommit = Date.parse(timeStamp);

        membro.CommitSHA = commit.sha;
        membro.CommitLink = commit.link;
        membro.Commitmenssage = commit.message;
    })
};

setTimeout(function () {
    membros.sort(compare);
}, 1000);


function compare(a, b) {
    if (a.DataUltimoCommit > b.DataUltimoCommit) {
        return -1;
    }
    if (a.DataUltimoCommit < b.DataUltimoCommit) {
        return 1;
    }
    return 0;
};

function removeEspacos(membro) {

    membro.Nome = membro.Nome.replace(/\s/g, "XXXXXX");
}

function atribuiEspacos(membro) {
    membro.Nome = membro.Nome.replace(/XXXXXX/g, ' ');
}

setTimeout(function () {
    membros.forEach(function (membro) {
        removeEspacos(membro);
        $('<div><div/>').attr('id', ("Cartao" + membro.Nome))
        .addClass('Cartao hvr-push hvr-pulse:hover, .hvr-pulse:focus, .hvr-pulse:active')
        .appendTo('#membrosProjeto');
        var caminhodivCartao = "Cartao" + (membro.Nome);

        $('<div></div>').attr('id', "content" + membro.Nome)
        .addClass('content')
        .appendTo('#' + caminhodivCartao);

        var caminhodivContent = "content" + (membro.Nome);

        $('<div></div>').attr('id', "imagem" + membro.Nome)
        .addClass('imagem')
        .appendTo('#' + caminhodivContent);

        var caminhodivImagem = "imagem" + (membro.Nome);

        var fotoMembro = $('<img id="loading" src="/Upload/img/' + membro.Foto + '" alt="..." class="img-circle" />');

        $('#' + caminhodivImagem).append(fotoMembro);

        $('<div></div>').attr('id', "Cargo" + membro.Nome)
        .addClass('resumoMembro')
        .appendTo('#' + caminhodivContent);

        var caminhodivCargo = "Cargo" + (membro.Nome);

        atribuiEspacos(membro);
        $('<p></p>')
        .html('Nome: ' + membro.Nome)
        .appendTo('#' + caminhodivCargo);
        removeEspacos(membro);

        $('<p></p>')
       .html('Email: ' + membro.Email)
       .appendTo('#' + caminhodivCargo);

        $('<p></p>')
       .html('Cargo: ' + membro.cargo.Descricao)
       .appendTo('#' + caminhodivCargo);

        $('<div></div>').attr('id', "campos" + membro.Nome)
        .addClass('campos')
        .appendTo('#' + caminhodivContent);

        var caminhodivCampos = "campos" + (membro.Nome);

        $('<div></div>').attr('id', (membro.Nome))
        .html('Último commit:')
        .appendTo('#' + caminhodivCampos);

        $('<div></div>').attr('id', "dataUltimoCommit" + membro.Nome)
        .html('Data Último commit:')
        .appendTo('#' + caminhodivCampos);

        var caminhoDataUltimocommit = "dataUltimoCommi" + (membro.Nome);

        $('<div></div>').attr('id', "DataUltimoCommit" + membro.Nome)
        .appendTo('#' + caminhodivCampos);

        $('<p></p>').html('Comentarios')
        .appendTo('#' + caminhodivCampos);

        $('<div></div>').attr('id', "comentariosPositivos" + membro.Nome)
        .attr('style', 'float:left')
        .html('Positivos / ')
        .appendTo('#' + caminhodivCampos);

        var caminhoComentariosPositivos = "comentariosPositivos" + (membro.Nome);

        $('<div></div>').html(membro.TotalComentariosPosivo)
        .appendTo('#' + caminhoComentariosPositivos);

        $('<div></div>').attr('id', "comentariosNegativos" + membro.Nome)
        .html(' Negativos:')
        .appendTo('#' + caminhodivCampos);

        var caminhoComentariosNegativos = "comentariosNegativos" + (membro.Nome);

        $('<div></div>').html(membro.TotalComentarioNegativo)
        .appendTo('#' + caminhoComentariosNegativos);

        var form = $("<form/>", { action: '/Membro/FichaMembro' });
        form.append($("<input>", { type: 'hidden', name: 'id', value: membro.Id }));
        form.append($("<input>", { type: 'submit', value: 'Ficha Completa', name: 'enviar' }));
        $(form).appendTo('#' + caminhodivCampos);

        var caminhoComiits = (membro.Nome);
        $('#' + caminhoComiits)
            .append($('<div>')
                .append($('<p>')
                    .append($('<a>').html(membro.CommitSHA).attr('href', membro.CommitLink))
                    .append($('<p>').html(membro.Commitmenssage)))

        )
        var oneDay = 24 * 60 * 60 * 1000;
        var diaAtual = new Date();
        var diaUltimoCommit = new Date(membro.DataUltimoCommit);
        var diasDiferenca = Math.round(Math.abs((diaAtual.getTime() - diaUltimoCommit.getTime()) / (oneDay)));

        if (diasDiferenca > 1) {
            var caminhoParaFichaMembro = "Cartao" + (membro.Nome);
            $('#' + caminhoParaFichaMembro)
            .addClass('mudarCorFicha');
        }

        var dia = diaUltimoCommit.getUTCDay();
        var mes = diaUltimoCommit.getUTCMonth() + 1;
        var ano = diaUltimoCommit.getUTCFullYear();
        var hora = diaUltimoCommit.getUTCHours();
        var minutos = diaUltimoCommit.getUTCMinutes();

        var dataEHoraUltimoCommit = dia + '/' + mes + '/' + ano + ' - ' + hora + ':' + minutos;

        var caminhoDataUltimoCommit = "DataUltimoCommit" + (membro.Nome);
        $('#' + caminhoDataUltimoCommit)
        .append('<p>').html(dataEHoraUltimoCommit);
    })

}, 2000);


setInterval(function () {
    localStorage.clear();
}, 1000 * 60 * 10)