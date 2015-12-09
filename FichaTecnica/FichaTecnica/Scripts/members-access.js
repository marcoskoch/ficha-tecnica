membros.forEach(function (membro) {
    var model = (membro.LinksGithub);
    var commitList = [];

    model.Links.forEach(function(l) {
        var localStorageCommits = localStorage.getItem('latestCommits_'.concat(membro.Id.toString()));

        if(localStorageCommits == null || localStorageCommits == '[]') {
            $.get(model.URLBaseAPI + l.URL + 'commits')
                .done(function (response) {
                    response.forEach(function (i) {
                        commitList.push({ sha: i.sha.slice(0, 7), date: new Date(i.commit.author.date).getTime(), message: i.commit.message, link: i.html_url })

                    })
                })
            .always(function() {
                atribuiValoresGitHubAoMembro(commitList,membro);
            });
        }
        else{
            commitList = JSON.parse(localStorageCommits);
            atribuiValoresGitHubAoMembro(commitList,membro);
        }
    });
});

function atribuiValoresGitHubAoMembro(commitList, membro){
    commitList.sort(function (left, right) { return left.date < right.date })
    commitList = commitList.slice(0, 3);
    localStorage.setItem('latestCommits_'.concat(membro.Id), JSON.stringify(commitList));
    commitList.forEach(function(commit) {
        var timeStamp  = new Date(commit.date);
        membro.DataUltimoCommit = Date.parse(timeStamp);

        membro.CommitSHA = commit.sha;
        membro.CommitLink = commit.link;
        membro.Commitmenssage = commit.message;
    })
};

setTimeout(function(){
    membros.sort(compare);
},1000);


function compare(a,b) {
    if (a.DataUltimoCommit > b.DataUltimoCommit){
        return -1;
    }
    if (a.DataUltimoCommit < b.DataUltimoCommit){
        return 1;
    }
    return 0;
};

function removeEspacos(membro){

    membro.Nome = membro.Nome.replace(/\s/g, "XZYXZY") ;
}

function atribuiEspacos(membro){
    membro.Nome = membro.Nome.replace(/XZYXZY/g, ' ');
}

setTimeout(function() {
    membros.forEach(function (membro) {
        removeEspacos(membro);
        $('<div><div/>').attr('id', ("Cartao"+ membro.Nome))
        .addClass('Cartao')
        .appendTo('#membrosProjeto');
        var caminhodivCartao = "Cartao" + (membro.Nome);

        $('<div></div>').attr('id',"content"+membro.Nome)
        .addClass('content')
        .appendTo('#'+caminhodivCartao);

        var caminhodivContent = "content" + (membro.Nome);

        $('<div></div>').attr('id', "imagem"+membro.Nome)
        .addClass('imagem')
        .appendTo('#'+caminhodivContent);

        var caminhodivImagem = "imagem" + (membro.Nome);

        var fotoMembro  = $('<img id="loading" src="/Upload/img/'+membro.Foto+'" alt="..." class="img-circle " />');

        $('#'+caminhodivImagem).append(fotoMembro);

        $('<div></div>').attr('id',"Cargo"+membro.Nome)
        .addClass('resumoMembro')
        .appendTo('#'+caminhodivContent);

        var caminhodivCargo = "Cargo" +  (membro.Nome);

        atribuiEspacos(membro);
        $('<p></p>')
        .attr('id','divNomeMembro' + membro.Nome)
        .html(membro.Nome)
        .addClass('resumoMembro-nomeMembro')
        .appendTo('#'+caminhodivCargo);
        removeEspacos(membro);

        $('<p></p>')
       .html('Email: '+ membro.Email)
       .appendTo('#'+caminhodivCargo);

        $('<p></p>')
       .html('Cargo: '+membro.cargo.Descricao)
       .appendTo('#'+caminhodivCargo);

        var caminhoDivNomeMmebro = "divNomeMembro" + membro.Nome;

        $('<div></div>').attr('id', "comentariosPositivos"+membro.Nome)
        .attr('style', 'float:left')
        .attr('style', 'background-repeat:no-repeat')
        .addClass('campos-Positivo positivo')
        .appendTo('#'+caminhodivContent);

        var caminhoComentariosPositivos =  "comentariosPositivos" + (membro.Nome);

        $('<div></div>').html(membro.TotalComentariosPosivo)

       .appendTo('#'+caminhoComentariosPositivos);

        $('<div></div>').attr('id', "comentariosNegativos"+membro.Nome)
        .attr('style', 'float:right')
        .attr('style', 'background-repeat:no-repeat')
        .addClass('campos-Negativo negativo')
        .appendTo('#'+caminhodivContent);


        var caminhoComentariosNegativos = "comentariosNegativos" + (membro.Nome);

        $('<div></div>')
        .attr('id', "TotalNegativos"+membro.Nome)
        .html(membro.TotalComentarioNegativo)
        .appendTo('#'+caminhoComentariosNegativos);

        var caminhoTotalNegativos =  "TotalNegativos" + (membro.Nome);

        $('<div></div>').html('')
        .attr('id', 'LinhaLateral'+membro.Nome)
        .attr('style', 'float:right')
        .addClass('linhaVertical')
        .appendTo('#'+caminhodivContent);

        var caminhoParaLinhaLateral = "LinhaLateral" + membro.Nome;

        $('<div></div>')
        .attr('id', 'divLateral' + membro.Nome)
        .addClass('divLateral')
        .appendTo('#'+caminhodivContent);

        var caminhoParaDivLateral = "divLateral" + membro.Nome;

        $('<div></div>')
        .addClass('mega-octicon octicon-mark-github corIconGitHub')
        .appendTo('#'+caminhoParaDivLateral)

        $('<div></div>').attr('id', "campos"+membro.Nome)
        .addClass('campos')
        .appendTo('#'+caminhodivContent);

        var caminhodivCampos = "campos" + (membro.Nome);

        $('<div></div>').attr('id', (membro.Nome))
        .html('Último commit no GitHub:')
        .addClass('divMenssagemUltimoCommit')
        .appendTo('#'+caminhoParaDivLateral);

        var caminhoComiits = (membro.Nome);
        $('#'+caminhoComiits)
        .attr('id', 'LinkUltimoCommit'+ membro.Nome)
        .append($('<div>')
        .append($('<p>')
        .append($('<a>').attr('style', 'color: #ff3333').html(membro.CommitSHA).attr('href', membro.CommitLink).attr('target', 'blank'))
        .append($('<p>').html(membro.Commitmenssage))))

        var caminhoLinkUltimoCommit = "LinkUltimoCommit" + membro.Nome;

        $('<div></div>').attr('id', "dataUltimoCommit"+membro.Nome)
        .html('Data Último commit:')
        .appendTo('#'+caminhoLinkUltimoCommit);

        var caminhoDataUltimocommit = "dataUltimoCommit" +(membro.Nome);

        $('<div></div>').attr('id', "DataUltimoCommit"+membro.Nome)
        .appendTo('#'+caminhoDataUltimocommit);

        var oneDay = 24*60*60*1000;
        var diaAtual = new Date();
        var diaUltimoCommit = new Date(membro.DataUltimoCommit);
        var diasDiferenca = Math.round(Math.abs((diaAtual.getTime() - diaUltimoCommit.getTime())/(oneDay)));

        if(diasDiferenca > 1){
            var warningIcon  = $('<img id="loadingIcon" src="/Content/Image/caution8.png" alt="..." class="warningIcon" title="Membro há mais de 1 dia sem commitar" />');

            $('#'+caminhoParaDivLateral)
            .append(warningIcon);
        }

        dataEHoraUltimoCommit = montaData(diaUltimoCommit);   

        var caminhoDataUltimoCommit = "DataUltimoCommit" + (membro.Nome);
        $('<p></p>')
            .attr('style', 'float:left')
        .html(dataEHoraUltimoCommit)
        .appendTo('#'+caminhoDataUltimoCommit);
        

        $(document).ready(function(){
            $('#Cargo'+ membro.Nome).click(function (){
                window.location = "/Membro/FichaMembro/" + membro.Id;
            });
        });

        $(document).ready(function(){
            $('#divLateral'+ membro.Nome).click(function (){
                window.location = membro.CommitLink
            });
        });

        $('#Carregando').hide();
    })

}, 2000);


setInterval(function() {
    localStorage.clear();
}, 1000 * 60 * 10)